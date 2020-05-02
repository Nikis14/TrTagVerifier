using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programm
{
    public partial class FormEditTags : Form
    {
        TableLayoutPanel table;
        Dictionary<string, List<string>> cat_features;
        static Dictionary<string, MyTuple<List<string>, int>> catFatures_val;
        static string cur_category = "";
        static string cur_feature = "";
        bool first_time = true;
        bool programm_feature_changed = false;

        Dictionary<string, int> category_num = new Dictionary<string, int>();

        public FormEditTags(TableLayoutPanel _table, ref EditActions action)
        {
            InitializeComponent();

            table = _table;
            cat_features = action.cat_features;
            catFatures_val = SpecialActions.copy_dictionaries(ref action.catFeatures_val);
            get_category_num();
            Create_form();
        }


        //----------------------Создание------------------------

        private void get_category_num()
        {
            for(int i = 0; i < listBoxCategories.Items.Count; ++i)
            {
                category_num[listBoxCategories.Items[i].ToString()] = i;
            }
        }


        private void Set_lemma()
        {
            textBoxLemma.Text = ((Label)table.GetControlFromPosition(2, 0)).Text;
        }


        private void Set_word()
        {

            Label L_word = new Label();
            L_word.Text = ((Label)table.GetControlFromPosition(1, 0)).Text;

            L_word.AutoSize = true;
            L_word.Font = new Font(L_word.Font.FontFamily, 11, FontStyle.Bold);
            L_word.Location = new Point(label_word.Location.X + label_word.Width, label_word.Location.Y);
            this.Controls.Add(L_word);
        }


        private Label get_part_sentence(ref TableLayoutPanel sentence_table, int ind_col, int X, int Y, ContentAlignment ca)
        {
            Label L_part = new Label();
            Label L_curent = (Label)sentence_table.GetControlFromPosition(ind_col, 0);
            L_part.Text = L_curent.Text;
            L_part.TextAlign = ca;
            
            L_part.AutoSize = true;
            L_part.Font = new Font(L_part.Font.FontFamily, 9, L_curent.Font.Style);
            L_part.Location = new Point(X, Y);
            return L_part;
        }


        private void Set_sentence()
        {
            TableLayoutPanel sentence_table = ((TableLayoutPanel)table.GetControlFromPosition(0, 1));
            Label lb1 = Labels.create_sentence_label(((Label)sentence_table.GetControlFromPosition(0, 0)).Text, ContentAlignment.TopRight, FontStyle.Italic);
            Label lb2 = Labels.create_sentence_label(((Label)sentence_table.GetControlFromPosition(1, 0)).Text, ContentAlignment.TopCenter, FontStyle.Bold);
            lb2.AutoSize = true;
            Label lb3 = Labels.create_sentence_label(((Label)sentence_table.GetControlFromPosition(2, 0)).Text, ContentAlignment.TopLeft, FontStyle.Italic);

            SentenceEditTable s_table = new SentenceEditTable();
            s_table.table.Controls.Add(lb1, 0, 0);
            s_table.table.Controls.Add(lb2, 1, 0);
            s_table.table.Controls.Add(lb3, 2, 0);

            int X = listBoxCategories.Location.X - 170;
            int Y = listBoxCategories.Location.Y + listBoxCategories.Height + 30;

            s_table.table.Location = new Point(X, Y);
            this.Controls.Add(s_table.table);
        }

        private void Set_cur_category(ref TableLayoutPanel table_tags)
        {
            cur_category = ((Label)table_tags.GetControlFromPosition(1, 0)).Text.Replace("\r", "");
            listBoxCategories.SetSelected(category_num[cur_category], true);
            first_time = false;
        }


        private void Add_features()
        {
            listBoxFeatures.Items.Clear();
            foreach (string feature in cat_features[cur_category])
                listBoxFeatures.Items.Add(feature);
            if (listBoxFeatures.Items.Count > 0)
            {
                programm_feature_changed = true;
                listBoxFeatures.SetSelected(0, true);
                programm_feature_changed = false;
                cur_feature = listBoxFeatures.Items[0].ToString();
            }
            else
                cur_feature = "";
        }


        private void Set_features_vals()
        {
            TableLayoutPanel table_tags = ((TableLayoutPanel)table.GetControlFromPosition(3, 0));
            Set_cur_category(ref table_tags);

            Add_features();

            for (int i = 1; i < table_tags.RowCount; ++i)
            {
                string cur_feature = ((Label)table_tags.GetControlFromPosition(0, i)).Text.Replace("\r", "");
                string val = ((Label)table_tags.GetControlFromPosition(1, i)).Text.Replace("\r", "");
                catFatures_val[cur_category + "_" + cur_feature].Item2 = Math.Max(0, catFatures_val[cur_category + "_" + cur_feature].Item1.FindIndex(x => x == val));
            }

            if (listBoxFeatures.Items.Count > 0)
                Set_Value_Panel();
        }

        private void Create_form()
        {
            Set_word();
            Set_lemma();
            Set_sentence();
            Set_features_vals();
        }

        //-----------------Изменения и отрисовка----------------------

        private void Set_Value_Panel()
        {
            first_time = true;
            panelValues.Controls.Clear();
            MyTuple<List<string>, int> cur_vals = catFatures_val[cur_category + "_" + cur_feature];

            int x = 3;
            int y = 5;
            for (int i = 0; i < cur_vals.Item2; ++i)
            {
                RadioButton rb = RadioButton_val(cur_vals.Item1[i], x, y, i);
                y += 25;
                panelValues.Controls.Add(rb);
            }

            RadioButton rb_cur = RadioButton_val(cur_vals.Item1[cur_vals.Item2], x, y, cur_vals.Item2);
            rb_cur.Checked = true;
            panelValues.Controls.Add(rb_cur);
            

            for (int i = cur_vals.Item2 + 1; i < cur_vals.Item1.Count; ++i)
            {
                y += 25;
                RadioButton rb = RadioButton_val(cur_vals.Item1[i], x, y, i);
                panelValues.Controls.Add(rb);
            }
            first_time = false;
        }

        private RadioButton get_checked_RadioButton()
        {
            for(int i = 0; i < panelValues.Controls.Count; ++i)
            {
                RadioButton rb = (RadioButton)panelValues.Controls[i];
                if (rb.Checked)
                    return rb;
            }
            return null;
        }

        public void SelectedValueChanged(object sender, EventArgs e)
        {
            if (!first_time)
            {
                RadioButton rb = get_checked_RadioButton();
                int num;
                int.TryParse(rb.Name.Substring(5), out num);
                catFatures_val[cur_category + "_" + cur_feature].Item2 = num;
            }
        }

        public void FeatureSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!programm_feature_changed)
            {
                ListBox lb = (ListBox)sender;
                cur_feature = lb.SelectedItem.ToString();
                Set_Value_Panel();
            }
        }


        public void CategorySelectedIndexChanged(object sender, EventArgs e)
        {
            string chosen = ((ListBox)sender).SelectedItem.ToString();
            if (!first_time && chosen != cur_category)
            {
                string title = "Изменение категории";
                string question = "Вы уверены, что хотите изменить категорию?" + System.Environment.NewLine + "Текущие данные будут полностью изменены.";

                if (new ConfirmForm(title, question).ShowDialog() == DialogResult.OK)
                {
                    cur_category = chosen;
                    Add_features();
                    if (listBoxFeatures.Items.Count > 0)
                        Set_Value_Panel();
                    else
                        panelValues.Controls.Clear();
                }

                else
                {
                    first_time = true;
                    listBoxCategories.SetSelected(category_num[cur_category], true);
                    first_time = false;
                }
                    
            }
            
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            DialogResult = DialogResult.Cancel;
            Close();
        }


        private void delete_elem(ref TableLayoutPanel table_tags, int row, int col)
        {
            Control c = table_tags.GetControlFromPosition(col, row);
            table_tags.Controls.Remove(c);
            if(c != null)
                c.Dispose();
        }


        private void change_vals_in_label(ref TableLayoutPanel table_tags, int col, int row, string val)
        {
            Label cur_val = (Label)table_tags.GetControlFromPosition(col, row);
            if(cur_val == null)
            {
                if (val != "не выбрано")
                {
                    cur_val = Labels.create_label_with_size(val, 10);
                    cur_val.ForeColor = Color.Green;
                }
            }
            else if (cur_val.Text.Replace("\r", "") != val)
            {
                if (val == "не выбрано")
                    val = "";
                cur_val.Text = val;
                cur_val.ForeColor = Color.Green;
            }
        }


        private void add_features_in_label(ref TableLayoutPanel table_tags, int row, string val)
        {
            Label cur_val = Labels.create_label_with_size(val, 9);
            cur_val.ForeColor = Color.Green;
            table_tags.Controls.Add(cur_val);
        }


        private void add_vals_in_label(ref TableLayoutPanel table_tags, int row, string val)
        {
            if (val == "не выбрано")
                val = "";
            Label cur_val = Labels.create_label_with_size(val, 10);
            cur_val.ForeColor = Color.Green;
            table_tags.Controls.Add(cur_val);
        }


        private void Update_tags()
        {
            TableLayoutPanel table_tags = ((TableLayoutPanel)table.GetControlFromPosition(3, 0));
            Label cur_val = (Label)table_tags.GetControlFromPosition(1, 0);
            bool cat_changed = false;
            if (cur_val.Text.Replace("\r","") != cur_category)
            {
                cur_val.Text = cur_category;
                cur_val.ForeColor = Color.Orange;
                cat_changed = true;
                int height_for_one = 30;
                table.Height = 50 + Math.Max(height_for_one * (listBoxFeatures.Items.Count + 1), height_for_one * 2);
            }
            List<string> cur_features = cat_features[cur_category];
            int cnt = Math.Min(cur_features.Count, table_tags.RowCount);

            for (int i = 0; i < cnt; ++i)
            {
                string feature = cur_features[i];
                MyTuple<List<string>, int> vals = catFatures_val[cur_category + "_" + feature];
                string val = vals.Item1[vals.Item2];
                change_vals_in_label(ref table_tags, 1, i+1, val);
                if(cat_changed)
                {
                    change_vals_in_label(ref table_tags, 0, i + 1, feature);
                }
            }

            if (cur_features.Count + 1 < table_tags.RowCount)
            {
                for (int i = table_tags.RowCount-1; i > cnt; i--)
                {
                    delete_elem(ref table_tags, i, 0);
                    delete_elem(ref table_tags, i, 1);
                    table_tags.RowStyles.RemoveAt(i);
                    table_tags.RowCount--;
                }
                //table_tags.RowCount = cur_features.Count;
            }

            else if(cur_features.Count + 1 > table_tags.RowCount)
            {
                for (int i = table_tags.RowCount; i < cur_features.Count; i++)
                {
                    table_tags.RowCount++;
                    table_tags.RowStyles.Add(new RowStyle(SizeType.Percent, table_tags.RowStyles[0].Height));
                    string feature = cur_features[i];
                    MyTuple<List<string>, int> vals = catFatures_val[cur_category + "_" + feature];
                    string val = vals.Item1[vals.Item2];
                    add_features_in_label(ref table_tags, i, feature);
                    add_vals_in_label(ref table_tags, i, val);
                }
            }
        }


        private void Update_lemma()
        {
            Label lemma = ((Label)table.GetControlFromPosition(2, 0));
            if(lemma.Text != textBoxLemma.Text)
            {
                lemma.Text = textBoxLemma.Text;
                lemma.ForeColor = Color.Blue;
            }
        }


        //Обновить значения в таблице согласно выбранной части речи
        private void buttonOK_Click(object sender, EventArgs e)
        {
            Update_tags();
            Update_lemma();
            //this.Dispose();
            DialogResult = DialogResult.OK;
            Close();
        }


        private RadioButton RadioButton_val(string info, int x, int y, int num)
        {
            RadioButton rb = new RadioButton();
            rb.AutoSize = true;
            rb.Name = "Value" + num.ToString();
            rb.Text = info;
            rb.Font = new Font(rb.Font.FontFamily, 9, rb.Font.Style);
            rb.Location = new Point(x, y);
            rb.CheckedChanged += SelectedValueChanged;
            return rb;
        }
    }


}
