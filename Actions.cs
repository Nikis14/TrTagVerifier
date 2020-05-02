using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programm
{
    class UniteActions
    {
        public int insert_original_to_TreeTagger(string FileName_original, string FileName_TreeTagger, ref string res_file)
        {
            StreamReader sr_orig = new StreamReader(FileName_original, System.Text.Encoding.UTF8);
            Regex regex = new Regex(@"\w+|[^\w\s]");
            MatchCollection matches = regex.Matches(sr_orig.ReadToEnd());
            sr_orig.Close();
            if (matches.Count == 0)
                return 3;
            string[] splitted = FileName_TreeTagger.Split('\\');
            string dir = String.Join("\\", splitted.Take(FileName_TreeTagger.Split('\\').Length - 1)) + "\\";
            StreamReader sr_TrTag = new StreamReader(FileName_TreeTagger, System.Text.Encoding.UTF8);
            string line = "";
            List<string> new_lines = new List<string>();
            bool okay = true;
            foreach(Match match in matches)
            {
                if (okay)
                {
                    line = sr_TrTag.ReadLine();
                    while (line == "")
                        line = sr_TrTag.ReadLine();
                    if (line == null)
                        return 1;
                    if (!Char.IsLetter(match.Value[0]) && match.Value[0] != line[0])
                    {
                        okay = false;
                        continue;
                    }
                    new_lines.Add(match.Value + "\t" + String.Join("\t", line.Split(' ', '\t').Skip(1)));
                }
                else
                {
                    if (match.Value[0] == line[0])
                    {
                        new_lines.Add(match.Value + "\t" + String.Join("\t", line.Split(' ', '\t').Skip(1)));
                        okay = true;
                    }
                }
            }
            line = sr_TrTag.ReadLine();
            if (line != null && line != "")
                return 2;

            sr_TrTag.Close();
            string new_dir = dir + "transformed" + "\\";
            DirectoryInfo dirInfo = new DirectoryInfo(new_dir);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            res_file = new_dir + splitted.Last().Substring(0, splitted.Last().Length - 4) + "_external.txt";
            StreamWriter result_file = new StreamWriter(res_file);
            foreach (string s in new_lines)
                result_file.WriteLine(s);
            result_file.Close();
            return 0;
        }

        public int insert_original_to_TreeTagger_dirMode(string dir_original, string dir_TreeTagger, ref string res_dir)
        {
            string[] splitted_orig = dir_original.Split('\\');
            string[] splitted_TrTag = dir_TreeTagger.Split('\\');

            DirectoryInfo orig = new DirectoryInfo(dir_original);
            DirectoryInfo trTag = new DirectoryInfo(dir_TreeTagger);

            List<FileInfo> orig_files = orig.GetFiles().OrderBy(fileinfo => fileinfo.FullName).ToList();
            List<FileInfo> trTag_files = trTag.GetFiles().OrderBy(fileinfo => fileinfo.FullName).ToList();

            if (orig_files.Count() != trTag_files.Count())
                return 1;

            int score = 0;
            for (int i = 0; i < orig_files.Count(); ++i)
            {
                string res_info = "";
                int error = insert_original_to_TreeTagger(orig_files[i].FullName, trTag_files[i].FullName, ref res_info);
                if (res_info != "")
                    res_dir = res_info;
                if (error != 0)
                    score = 2;
            }
            return score;
        }
    }

    public class EditActions
    {
        public Dictionary<string, string> specification;
        public Dictionary<string, List<string>> cat_features = new Dictionary<string, List<string>>();
        public Dictionary<string, MyTuple<List<string>, int>> catFeatures_val = new Dictionary<string, MyTuple<List<string>, int>>();
        public Dictionary<string, char> propName_propTag = new Dictionary<string, char>();
        public Dictionary<char, int> cat_tagsCount = new Dictionary<char, int>();

        public void read_specification()
        {
            string spec_name = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "resources\\", "specification.txt");
            StreamReader sr_spec = new StreamReader(spec_name, System.Text.Encoding.UTF8);
            string full_spec = sr_spec.ReadToEnd();
            sr_spec.Close();

            string[] categories = full_spec.Split('0');//.Skip(1).ToArray();
            specification = new Dictionary<string, string>();
            for (int category_ind = 1; category_ind < categories.Length; category_ind++)
            {
                string[] properties = categories[category_ind].Split('%');
                string cur_category = "";
                char cur_category_tag = '1';
                for (int property_ind = 0; property_ind < properties.Length; property_ind++)
                {
                    string[] vals = Regex.Split(properties[property_ind], "\r?\n");
                    string[] val_1 = Regex.Split(vals[0].Trim(), "\t+");
                    string cat_name = val_1[0];
                    specification[val_1[2] + category_ind.ToString() + property_ind.ToString()] = cat_name + "=" + val_1[1];
                    //cat_features[cat_name] = new List<string>();
                    if (property_ind == 0)
                    {
                        cur_category = val_1[1];
                        cat_features[cur_category] = new List<string>();
                        cur_category_tag = val_1[2][0];
                        cat_tagsCount[cur_category_tag] = 1;
                        propName_propTag[cur_category] = cur_category_tag;
                    }
                    else
                    {
                        catFeatures_val[cur_category + "_" + cat_name] = new MyTuple<List<string>, int>(new List<string>()  { "не выбрано", val_1[1] }, 0);
                        cat_features[cur_category].Add(cat_name);
                        cat_tagsCount[cur_category_tag]++;
                        propName_propTag[cur_category_tag + "_" + val_1[0] + "_" + val_1[1]] = val_1[2][0];
                    }


                    foreach (string other_vals in vals.Skip(1))
                    {
                        string[] val_other = Regex.Split(other_vals.Trim(), "\t+");
                        if (val_other.Length > 1)
                        {
                            specification[val_other[1] + category_ind.ToString() + property_ind.ToString()] = cat_name + "=" + val_other[0];
                            catFeatures_val[cur_category + "_" + cat_name].Item1.Add(val_other[0]);
                            propName_propTag[cur_category_tag + "_" + val_1[0] + "_" + val_other[0]] = val_other[1][0];
                        }
                    }
                    specification['-' + category_ind.ToString() + property_ind.ToString()] = cat_name + "= ";
                }
            }
            cat_tagsCount['-'] = 0;
            //return specification;
        }

        public Dictionary<char, int> cat_number = new Dictionary<char, int>()
        {
            { 'N', 1 },
            { 'V', 2 },
            { 'A', 3 },
            { 'P', 4 },
            { 'R', 5 },
            { 'S', 6 },
            { 'C', 7 },
            { 'M', 8 },
            { 'Q', 9 },
            { 'I', 10 },
            { 'Y', 11 },
            { 'X', 12 }
        };

        public string swap_tags(string tag_line)
        {
            tag_line = tag_line.Trim();
            
            if(tag_line == "-" || tag_line == "SENT" || !Char.IsLetter(tag_line[0]))
                return tag_line;

            string description = "";

            try
            {
                int category_ind = cat_number[tag_line[0]];
                for (int tag_ind = 0; tag_ind < tag_line.Count() - 1; ++tag_ind)
                {
                    string key1 = tag_line[tag_ind].ToString() + category_ind.ToString() + tag_ind.ToString();
                    description += specification[key1] + System.Environment.NewLine;
                }
                string key = tag_line[tag_line.Count() - 1].ToString() + category_ind.ToString() + (tag_line.Count() - 1).ToString();
                description += specification[key];
                for (int i = tag_line.Count(); i < cat_tagsCount[tag_line[0]]; ++i)
                    description += System.Environment.NewLine + specification["-" + category_ind.ToString() + i.ToString()];
            }
            catch
            {
                string new_tags = tag_line[0].ToString();
                int cnt = cat_tagsCount[tag_line[0]];
                for (int i = 1; i < cnt; ++i)
                    new_tags += "-";
                return swap_tags(new_tags);
            }

            return description;
        }
    }
}
