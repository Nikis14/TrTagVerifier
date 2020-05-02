using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace programm
{
    public partial class FormEdit : Form
    {
        private int countShown;
        private int start;
        private int numStart;
        private int realShown;

        Dictionary<int, int> num_table_list;

        private int words_count;

        private string fileName;

        static EditActions action;
        List<Pair<string, List<Color>>> all_lines;
        List<string> all_words;
        List<string> all_tags;
        public static List<TableLayoutPanel> all_tables;

        bool countOK = true;
        bool pagesOK = true;

        bool success;


        private void initialize_vars()
        {
            countShown = 20;
            start = 0;
            numStart = 0;
            realShown = 20;

            success = false;
            num_table_list = new Dictionary<int, int>();

            words_count = 0;

            fileName = "";

            action = new EditActions();
            all_lines = new List<Pair<string, List<Color>>>();
            all_words = new List<string>();
            all_tags = new List<string>();
            all_tables = new List<TableLayoutPanel>();
        }



        public FormEdit(string file_name)
        {
            InitializeComponent();
            initialize_vars();

            this.WindowState = FormWindowState.Maximized;
            fileName = file_name;
            action.read_specification();
            download_content(file_name);

            setPossiblePages();
            create_all_tables();

            show_file_content();
        }

        public static Label create_basic_label(string text)
        {
            Label label = new Label();
            label.Text = text;
            label.Dock = DockStyle.Fill;
            return label;
        }

        public static Label create_label(string text)
        {
            Label label = create_basic_label(text);
            label.TextAlign = ContentAlignment.MiddleCenter;
            return label;
        }


        private List<Color> set_color_toList(string tags)
        {
            List<Color> res = new List<Color>();
            for (int i = 0; i < tags.Length * 2 + 1; ++i)
                res.Add(Color.Black);
            return res;
        }


        private bool isWord(string word)
        {
            return word != "" && Char.IsLetter(word[0]);
        }


        private void download_content(string file_name)
        {
            StreamReader str_TrTag = new StreamReader(file_name, System.Text.Encoding.UTF8);
            string line;
            int real_num = 0;
            int list_num = 0;
            while ((line = str_TrTag.ReadLine()) != null)
            {
                try
                {
                    string[] words = line.Split('\t');
                    if (words.Count() > 0)
                    {
                        if (Char.IsLetter(words[0][0]))
                        {
                            words_count++;
                            if (words[1].Trim() == "-")
                            {
                                words[1] = "N";
                            }
                        }
                        all_words.Add(words[0].Trim());
                        List<Color> colours = set_color_toList(words[1].Trim());
                        all_lines.Add(new Pair<string, List<Color>>(words[0].Trim() + "\t" + words[1].Trim() + "\t" + words[2].Trim(), colours));
                        all_tags.Add(words[1].Trim());
                        if (isWord(words[0].Trim()))
                        {
                            num_table_list[real_num] = list_num;
                            real_num++;
                        }
                        list_num++;
                    }
                }
                catch
                {
                    MessageBox.Show("Проверьте, наличие русской буквы \"С\" в тегах, пробела вместо табуляции и наличия лишних строк в конце файла.", "Что-то не так с файлом",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    str_TrTag.Close();
                    return;
                }

            }
            str_TrTag.Close();
            success = true;
        }


        private void create_all_tables()
        {
            int cur_num = 1;
            int height_for_one = 30;
            Button_Creates btnCreator = new Button_Creates();
            for (int num = num_table_list[numStart]; num < all_lines.Count(); ++num)
            {
                if (isWord(all_words[num]))
                {
                    var bb = all_tags[num][0];
                    int height = 0;
                    try
                    {
                        height = Math.Max(height_for_one * action.cat_tagsCount[bb], height_for_one * 2);
                    }
                    catch
                    {
                        MessageBox.Show("\"" + all_tags[num] + "\" не может быть тегом\n\n" + "Не расстраивайтесь, Вы можете сохранить внесенные изменения перед закрытием программы;)", "Ошибка с тегом", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SaveAsToolStripMenuItem_Click(null, null);
                        success = false;
                        Close();
                        return;
                    }
                    ExternalTable ex_table = new ExternalTable(50 + height); //создаем таблицу
                    Label number = create_label((numStart + cur_num).ToString());

                    ex_table.table.Controls.Add(number);
                    ex_table.set_text_to_table(all_lines[num], action, cur_num, btnCreator, this);

                    //ex_table.table.Controls.Add(Button_Creates.ButtonEdit(num));
                    ex_table.Add_sentence(all_words, num);

                    all_tables.Add(ex_table.table);
                    
                    cur_num++;
                    if (cur_num > countShown)
                    {
                        break;
                    }
                }
            }
        }

        //отображение таблицы
        private void show_file_content()
        {
            ScrollUp(MainPanel);
            int y = 90;
            int interval_y = 0;
            for (int num = 0; num < all_tables.Count(); ++num)
            {
                all_tables[num].Location = new Point(70, y);
                MainPanel.Controls.Add(all_tables[num]);
                y += all_tables[num].Height + interval_y; //обновляем координату y Location
            }
            realShown = all_tables.Count();
            //numStart += realShown;
            panel2.Location = new Point(panel2.Location.X, y);
            panel2.Visible = true;
        }


        //-------------------переходы между страницами--------------

        private void ScrollUp(Panel p)
        {
            //pos passed in should be negative
            using (Control c = new Control() { Parent = p, Dock = DockStyle.Top })
            {
                p.ScrollControlIntoView(c);
                c.Parent = null;
                c.Dispose();
            }
        }

        private void clearControls()
        { 
            int full_cnt = MainPanel.Controls.Count-1;
            for (int i = 0; i < realShown; ++i)
            {
                MainPanel.Controls[full_cnt - i].Dispose();
                //MainPanel.Controls[full_cnt - i].Enabled = false;
                //MainPanel.Controls.RemoveAt(full_cnt - i);
            }
            all_tables.Clear();
        }

        private void PrevLabel_Click(object sender, EventArgs e)
        {
            pagesOK = false;
            comboBoxTo.Text = "";
            comboBoxTo2.Text = "";
            pagesOK = true;
            clearControls();
            numStart = Math.Max(0, numStart - countShown);
            create_all_tables();
            show_file_content();
        }


        private void NextLabel_Click(object sender, EventArgs e)
        {
            pagesOK = false;
            comboBoxTo.Text = "";
            comboBoxTo2.Text = "";
            pagesOK = true;
            clearControls();
            numStart += realShown;
            if (numStart >= words_count)
            {
                numStart -= realShown;
                MessageBox.Show("Поздравляю! Вы проверили весь файл:)", "УРА", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            create_all_tables();
            show_file_content();
        }


        private void setPossiblePages()
        {
            int row_count = words_count / countShown;
            for (int i = 0; i < row_count; ++i)
            {
                string cur_row = (i * countShown + 1).ToString() + "-" + ((i + 1) * countShown).ToString();
                comboBoxTo.Items.Add((cur_row));
                comboBoxTo2.Items.Add((cur_row));
            }
            if(row_count * countShown < words_count)
            {
                string cur_row = (row_count * countShown + 1).ToString() + "-" + words_count.ToString();
                comboBoxTo.Items.Add((cur_row));
                comboBoxTo2.Items.Add((cur_row));
            }
        }

        private void comboBoxCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!countOK)
                return;
            countOK = false;
            ComboBox cmb = (ComboBox)sender;
            comboBoxTo.Text = "";
            comboBoxTo2.Text = "";
            clearControls();
            int.TryParse(cmb.Text, out countShown);
            realShown = countShown;
            start = 0;
            numStart = 0;
            pagesOK = false;
            comboBoxTo.Items.Clear();
            comboBoxTo2.Items.Clear();
            comboBoxCount.Text = cmb.Text;
            comboBoxCount2.Text = cmb.Text;
            setPossiblePages();
            pagesOK = true;

            create_all_tables();
            show_file_content();
            countOK = true;
        }


        private void comboBoxTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pagesOK)
                return;
            ComboBox cmb = (ComboBox)sender;
            if (cmb.Text == "")
                return;
            pagesOK = false;
            comboBoxTo.Text = cmb.Text;
            comboBoxTo2.Text = cmb.Text;
            pagesOK = true;
            clearControls();
            int.TryParse(cmb.Text.Split('-')[0], out numStart);
            numStart--;
            updateStartFrom_0();

            create_all_tables();
            show_file_content();
            
        }


        private void updateStartFrom_0()
        {
            start = 0;
            int countWatched = 0;
            while(countWatched < numStart)
            {
                if (Char.IsLetter(all_words[start][0]))
                    countWatched++;
                start++;
            }
        }

        //--------------------------Работа с исправлением-------------------------

        public void EditButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int num;
            int.TryParse(btn.Name.Substring(4), out num);
            FormEditTags form_edit_tags = new FormEditTags(all_tables[num-1], ref action);
            if (form_edit_tags.ShowDialog() == DialogResult.OK)
            {
                string lemma = ((Label)all_tables[num - 1].GetControlFromPosition(2, 0)).Text.Replace("\r", "");
                TableLayoutPanel tag_table = (TableLayoutPanel)all_tables[num - 1].GetControlFromPosition(3, 0);
                string tags = get_tags_by_table(ref tag_table, num-1);

                int list_num = num_table_list[numStart + num - 1];

                all_lines[list_num].Item2[all_lines[list_num].Item2.Count()-1] = ((Label)all_tables[num - 1].GetControlFromPosition(2, 0)).ForeColor;
                var old_tags = all_lines[list_num].Item1.Split('\t');
                all_lines[list_num].Item1 = old_tags[0] + "\t" + tags + "\t" + lemma;

                comboBoxTo.Text = "";
                comboBoxTo2.Text = "";
                clearControls();
                //numStart = Math.Max(0, numStart - realShown);

                create_all_tables();
                show_file_content();

                MainPanel.ScrollControlIntoView(all_tables[num - 1]);
            }
            //form_edit_tags.Show();
        }


        //---------------------------Сохранение-----------------------------

        
        private string get_tags_by_table(ref TableLayoutPanel tag_table, int num)
        {
            int list_num = num_table_list[numStart + num];
            List<Color> cur_colors = all_lines[list_num].Item2;
            cur_colors.Clear();
            cur_colors.Add(((Label)tag_table.GetControlFromPosition(0, 0)).ForeColor);
            cur_colors.Add(((Label)tag_table.GetControlFromPosition(1, 0)).ForeColor);

            string category_name = ((Label)tag_table.GetControlFromPosition(1, 0)).Text.Replace("\r", "");

            char category_tag = action.propName_propTag[category_name];
            string result_tags = category_tag.ToString();
            string help_Zerotags = "";
            for (int row = 1; row < tag_table.RowCount; ++row)
            {
                string prop_name = ((Label)tag_table.GetControlFromPosition(0, row)).Text.Replace("\r", "");
                cur_colors.Add(((Label)tag_table.GetControlFromPosition(0, row)).ForeColor);
                if ((Label)tag_table.GetControlFromPosition(1, row) == null)
                {
                    cur_colors.Add(Color.Black);
                    help_Zerotags += "-";
                    continue;
                }
                string prop_val = ((Label)tag_table.GetControlFromPosition(1, row)).Text.Replace("\r", "");
                cur_colors.Add(((Label)tag_table.GetControlFromPosition(1, row)).ForeColor);
                if (prop_val == "" || prop_val == " ")
                {
                    help_Zerotags += "-";
                }
                else
                {
                    result_tags += help_Zerotags + action.propName_propTag[category_tag + "_" + prop_name + "_" + prop_val].ToString();
                    help_Zerotags = "";
                }
            }
            return result_tags;
        }


        private void save_data_to_file(string filename)
        {
            StreamWriter result_file = new StreamWriter(filename);
            int wordNum = 0;
            for (int i = 0; i < all_lines.Count; ++i)
            {
                string result_line = all_lines[i].Item1.Replace("\n", "").Replace("\r", "");

                if (i != all_lines.Count - 1)
                    result_file.WriteLine(result_line);
                else
                    result_file.Write(result_line);

            }
            result_file.Close();
        }


        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "changed_" + fileName.Split('\\').Last();
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            save_data_to_file(saveFileDialog1.FileName);
            fileName = saveFileDialog1.FileName;
            SuccessInfo();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_data_to_file(fileName);
            SuccessInfo();
        }

        //------------------------Info-------------------------------

        private void FileInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Файл содержит " + words_count.ToString() + " слов для редактирования", "Информация о файле", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SuccessInfo()
        {
            MessageBox.Show("Изменения успешно сохранены в файл " + fileName.Split('\\').Last(), "Успешное сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //-----------------Closing---------------------




        private void FormEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!success)
            {
                this.Dispose();
                Close();
                return;
            }

            string title = "Закрыть";
            string question = "Вы уверены, что хотите закрыть форму?" + System.Environment.NewLine + "Несохраненные изменения не будут применены.";

            if (new ConfirmForm(title, question).ShowDialog() == DialogResult.OK)
            {
                this.Dispose();
                Close();
            }
            else
                e.Cancel = true;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
