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
    public class Table
    {
        public TableLayoutPanel table;
        protected void set_col_span(int row, int col, int ColumnCount)
        {
            Control sentence_table = table.GetControlFromPosition(col, row);
            table.SetColumnSpan(sentence_table, ColumnCount);
        }

        protected void set_row_span(int row, int col, int RowCount)
        {
            Control sentence_table = table.GetControlFromPosition(col, row);
            table.SetColumnSpan(sentence_table, RowCount);
        }
    }

    class ExternalTable: Table
    {
        private int RowCount = 2;
        private int ColumnCount = 5;
        public static int sentence_height = 40;

        public ExternalTable(int height)
        {
            //незадаваемые параметры
            int width = 950;
            
            //--------------------
            table = new TableLayoutPanel();
            table.RowCount = RowCount;
            table.ColumnCount = ColumnCount;
            table.Width = width;
            table.Height = height;
            //table.Location = location;
            table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            table.AutoScroll = true;


            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
            //Редактирование стиля строк и столбцов
            List<int> sizes = new List<int>(ColumnCount - 1) {17, 17, 49, 17 };
            for (int i = 1; i < ColumnCount; ++i)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, sizes[i-1]));
            }

            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, sentence_height));
        }

        public ExternalTable() { table = new TableLayoutPanel(); }

        
        public void set_text_to_cell(string word, Color color)
        {
            Label lb = Labels.create_label_with_size(word.Replace("\r", ""), 11);
            lb.ForeColor = color;
            table.Controls.Add(lb);
        }

        private void set_tags_description(string description, int row, int col, List<Color> colours)
        {
            int columns = 2;
            string[] rows = description.Split('\n');
            Internal_tags_table tags_table = new Internal_tags_table(rows.Length, columns);
            for(int i = 0; i < rows.Length; ++i)
            {
                string[] cur_feature = rows[i].Split('=');
                Label lb = Labels.create_label_with_size(cur_feature[0], 9);
                if (colours.Count() == 2 * i)
                    colours.Add(Color.Black);
                lb.ForeColor = colours[2 * i];
                tags_table.table.Controls.Add(lb, 0, i);
                Label lb2 = Labels.create_label_with_size(cur_feature[1].Replace("\n","").Replace("\r", ""), 10);
                if (colours.Count() == 2 * i + 1)
                    colours.Add(Color.Black);
                lb2.ForeColor = colours[2 * i + 1];
                tags_table.table.Controls.Add(lb2, 1, i);
            }
            table.Controls.Add(tags_table.table, col, row);
            //table.Controls.Add(Labels.create_label(description));
            //set_col_span(row, col, ColumnCount);
        }

        private void add_edit_button(int num, Button_Creates btnCreator, FormEdit form)
        {
            EditTable et = new EditTable();
            et.table.Controls.Add(btnCreator.ButtonEdit(num, form));
            //et.create_question_cell();
            table.Controls.Add(et.table);
        }

        public void set_text_to_table(Pair<string, List<Color>> line_colors, EditActions action, int num, Button_Creates btnCreator, FormEdit form)
        {
            string line = line_colors.Item1;
            string[] words = line.Split('\t');
            if (words.Length < 3)
                return;
            words[1] = action.swap_tags(words[1]);
            set_text_to_cell(words[0], Color.Black);
            set_text_to_cell(words[2], line_colors.Item2.Last());
            set_tags_description(words[1], 0, 3, line_colors.Item2);
            add_edit_button(num, btnCreator, form);
        }

        public static void get_part_sentence(ref string text, int begin, ref int end, ref int finish,  ref List<string> words)
        {
            for (int cur_num = begin; cur_num < end; ++cur_num)
            {
                if (Char.IsLetter(words[cur_num][0]))
                {
                    text += " ";
                }
                else if (finish < words.Count() - 1)
                    finish++;
                text += words[cur_num];
            }
        }

        public void Add_sentence(List<string> words, int num, int window = 5)
        {
            int start = Math.Max(0, num - window);
            int finish = Math.Min(words.Count() - 1, num + window);
            //==========================================

            string text_start;
            if (num == start)
                text_start = "";
            else
                text_start = words[start];
            get_part_sentence(ref text_start, start + 1, ref num, ref finish, ref words);

            Label lb1 = Labels.create_sentence_label(text_start, ContentAlignment.MiddleRight, FontStyle.Italic);
            //==================================================

            Label lb2 = Labels.create_sentence_label(words[num], ContentAlignment.MiddleCenter, FontStyle.Bold);
            lb2.AutoSize = true;
            //====================================================

            string text_finish = "";
            get_part_sentence(ref text_finish, num + 1, ref finish, ref finish, ref words);

            Label lb3 = Labels.create_sentence_label(text_finish, ContentAlignment.MiddleLeft, FontStyle.Italic);
            //====================================================

            SentenceTable s_table = new SentenceTable();
            s_table.table.Controls.Add(lb1, 0, 0);
            s_table.table.Controls.Add(lb2, 1, 0);
            s_table.table.Controls.Add(lb3, 2, 0);
            table.Controls.Add(s_table.table, 0, 1);
            /*Panel p_sentence = Panels.create_sentence_panel();

            lb2.Location = new Point(0, 0);
            lb1.Location = new Point(lb2.Location.X - 10, p_sentence.Height / 2);
            lb3.Location = new Point(lb2.Location.X + 10, p_sentence.Height / 2);

            p_sentence.Controls.Add(lb1);
            p_sentence.Controls.Add(lb2);
            p_sentence.Controls.Add(lb3);
            table.Controls.Add(p_sentence, 0, 1);*/

            //растягиваем на все колонки
            set_col_span(1, 0, ColumnCount);
        }
    }

    public class SentenceTable: Table
    {
        private int RowCount = 1;
        private int ColumnCount = 3;
        public SentenceTable()
        {
            table = new TableLayoutPanel();
            table.RowCount = RowCount;
            table.ColumnCount = ColumnCount;
            table.Dock = DockStyle.Fill;

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        }
    }

    public class Internal_tags_table : Table
    {

        public Internal_tags_table(int RowCount, int ColumnCount=2)
        {
            table = new TableLayoutPanel();
            table.RowCount = RowCount;
            table.ColumnCount = ColumnCount;
            table.Dock = DockStyle.Fill;
            table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;

            //Редактирование стиля строк и столбцов
            int percent_col = 100 / ColumnCount;
            for (int i = 0; i < ColumnCount; ++i)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent_col));
            }

            int percent_row = (int)(100 / (RowCount+1));
            for (int i = 0; i < RowCount-1; ++i)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, percent_row));
            }
            table.RowStyles.Add(new RowStyle(SizeType.Percent, percent_row+3));
        }
    }

    public class EditTable : Table
    {
        public EditTable(int RowCount = 2, int ColumnCount = 1)
        {
            table = new TableLayoutPanel();
            table.RowCount = RowCount;
            table.ColumnCount = ColumnCount;
            table.Dock = DockStyle.Fill;
            table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;

            
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
        }

        public void create_question_cell()
        {
            PictureBox picture = new PictureBox();
            picture.Dock = DockStyle.Fill;
            Image img = Image.FromFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "question.jpg"));
            picture.Image = new Bitmap(img, picture.Width, picture.Height);
            table.Controls.Add(picture);
        }
    }

    public class SentenceEditTable : Table
    {
        private int RowCount = 1;
        private int ColumnCount = 3;
        public SentenceEditTable(int width=700, int height=50)
        {

            table = new TableLayoutPanel();
            table.RowCount = RowCount;
            table.ColumnCount = ColumnCount;
            //table.Dock = DockStyle.Fill;
            table.Width = width;
            table.Height = height;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        }
    }
}
