using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace programm
{
    public partial class Form1 : Form
    {

        bool opened_original; //if original file is opened
        bool opened_trTag; //if TreeTagger file is opened
        int level = 0; //define which buttons should be shown

        Button_Creates creates = new Button_Creates();
        UniteActions Actions = new UniteActions();

        Button dir_mode; 
        Button file_mode;
        Button back;
        Button file_original;
        Button file_for_insert1;
        Button do_action;

        string txt_file_mode_Tr = "Выберите файл TreeTagger";
        string txt_file_orig = "Выберите исходный файл";

        bool is_file_mode = true;
        string txt_cat_mode_Tr = "Выберите папку с файлами TreeTagger";
        string txt_cat_orig = "Выберите папку с исходными файлами";

        Graphics g;
        public Form1()
        {
            InitializeComponent();
            ShowStartPage();
        }


        //---------------------------------Работа с кнопками----------------------------


        //Создание стартовой страницы
        public void ShowStartPage()
        {
            //insert_original.Location = new Point(this.Width/2, this.Height/2)
            create_buttons();
            Image img = Image.FromFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "resources\\", "logo.jpg"));
            Bitmap bit = new Bitmap(img, pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bit);
            pictureBox1.Image = bit;
        }

        //Создание кнопок на форме
        private void create_buttons()
        {
            dir_mode = creates.create_button(this, insert_original, dir_mode_click, false,
                "dir_mode", "Режим \"Каталог\"\n(Будут обработаны все файлы из указанного каталога)", 0, -15);
            file_mode = creates.create_button(this, correct_tags, file_mode_click, false,
                "file_mode", "Режим \"Файл\"\n(Будет обработан отдельный файл)", 0, -100);
            back = creates.create_back_button(this, dir_mode, file_mode, back_click);

            file_for_insert1 = creates.create_button(this, insert_original, for_insert1_click, false,
                "file_for_insert1", txt_file_mode_Tr, 0, -25);
            file_original = creates.create_button(this, correct_tags, file_original_click, false,
                "file_original", txt_file_orig, 0, -110);
            do_action = creates.create_button(this, back, do_action_click, false,
                "file_for_insert1", "Применить", 0, -60);
        }

        

        private void insert_original_click(object sender, EventArgs e)
        {
            level += 1;
            openFileDialog_file_mode.Dispose();
            correct_tags.Visible = false;
            insert_original.Visible = false;
            dir_mode.Visible = true;
            file_mode.Visible = true;
            back.Visible = true;
        }

        private void back_click(object sender, EventArgs e)
        {
            switch(level)
            {
                case 1:
                    dir_mode.Visible = false;
                    file_mode.Visible = false;
                    correct_tags.Visible = true;
                    insert_original.Visible = true;
                    back.Visible = false;
                    break;
                case 2:
                    file_original.Visible = false;
                    file_for_insert1.Visible = false;
                    do_action.Visible = false;
                    dir_mode.Visible = true;
                    file_mode.Visible = true;

                    folder_TrTag.Dispose();
                    folder_original.Dispose();
                    openFileDialog_file_mode.Dispose();
                    openFile_original.Dispose();
                    opened_original = false;
                    opened_trTag = false;
                    break;
            }
            level -= 1;
        }

        private void file_mode_click(object sender, EventArgs e)
        {
            level += 1;
            dir_mode.Visible = false;
            file_mode.Visible = false;
            file_original.Text = txt_file_orig;
            file_for_insert1.Text = txt_file_mode_Tr;
            file_original.Visible = true;
            file_for_insert1.Visible = true;
            do_action.Visible = true;
            is_file_mode = true;
        }

        private void dir_mode_click(object sender, EventArgs e)
        {
            level += 1;
            dir_mode.Visible = false;
            file_mode.Visible = false;
            file_original.Text = txt_cat_orig;
            file_for_insert1.Text = txt_cat_mode_Tr;
            file_original.Visible = true;
            file_for_insert1.Visible = true;
            do_action.Visible = true;
            is_file_mode = false;
        }

        private void list_nove(object sender, MouseEventArgs e)
        {
            if (Cursor.Current != Cursors.Hand)
                Cursor.Current = Cursors.Hand;
        }

        private void New_list_click(object sender, EventArgs e)
        {

        }

        //-------------------Работа с объединением файлов-------------------------------


        private void file_original_click(object sender, EventArgs e)
        {
            if (is_file_mode)
            {
                if (openFile_original.ShowDialog() == DialogResult.Cancel)
                    return;
            }
            else
            {
                if (folder_original.ShowDialog() == DialogResult.Cancel)
                    return;
            }
            opened_original = true;
        }

        private void for_insert1_click(object sender, EventArgs e)
        {
            if (is_file_mode)
            {
                if (openFileDialog_file_mode.ShowDialog() == DialogResult.Cancel)
                    return;
            }
            else
            {
                if (folder_TrTag.ShowDialog() == DialogResult.Cancel)
                    return;
            }
            opened_trTag = true;
        }

        private void do_action_click(object sender, EventArgs e)
        {
            if (is_file_mode)
            {
                string error_original = "Выберите исходный файл";
                string error_TrTag = "Выберите файл TreeTagger";
                if (!opened_original && !opened_trTag)
                    MessageBox.Show(error_original + "\n\n" + error_TrTag);
                else if (!opened_original)
                    MessageBox.Show(error_original);
                else if (!opened_trTag)
                    MessageBox.Show(error_TrTag);
                else
                {
                    string res_file = "";
                    int error = Actions.insert_original_to_TreeTagger(openFile_original.FileName, openFileDialog_file_mode.FileName, ref res_file);
                    switch (error)
                    {
                        case 1:
                            MessageBox.Show("Файл с исходным текстом пуст!");
                            break;
                        case 2:
                            MessageBox.Show("Файл TreeTagger содержит меньше слов, чем файл с исходным текстом!");
                            break;
                        case 3:
                            MessageBox.Show("Файл с исходным текстом содержит меньше слов, чем файл TreeTagger!");
                            break;
                        default:
                            MessageBox.Show("Преобразованный файл успешно создан: " + res_file);
                            break;
                    }
                }
            }
            else
            {
                string error_original = "Выберите папку с исходными файлами";
                string error_TrTag = "Выберите папку с файлами TreeTagger";
                if (!opened_original && !opened_trTag)
                    MessageBox.Show(error_original + "\n\n" + error_TrTag);
                else if (!opened_original)
                    MessageBox.Show(error_original);
                else if (!opened_trTag)
                    MessageBox.Show(error_TrTag);
                else
                {
                    string res_dir = "";
                    int error = Actions.insert_original_to_TreeTagger_dirMode(folder_original.SelectedPath, folder_TrTag.SelectedPath, ref res_dir);
                    switch (error)
                    {
                        case 1:
                            MessageBox.Show("В папках разное количество файлов!");
                            break;
                        case 2:
                            MessageBox.Show("Некоторые файлы не соответсвуют формату.\n Обработанные файлы в папке: " + res_dir);
                            break;
                        default:
                            MessageBox.Show("Все файлы успешно преобразованы. Они в папке:" + res_dir);
                            break;
                    }
                }
            }
        }


        //--------------------------Работа с исправлением-------------------------

        //Correct file button click
        private void correct_tags_click(object sender, EventArgs e)
        {
            if (openFileDialog_file_mode.ShowDialog() == DialogResult.Cancel)
                return;
            FormEdit form_edit = new FormEdit(openFileDialog_file_mode.FileName);
            try
            {
                form_edit.ShowDialog();
                //this.Dispose();
                //Close();
            }
            catch
            {

            }
        }
    }
}