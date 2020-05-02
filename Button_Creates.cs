using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programm
{
    class Button_Creates
    {
        public Button create_button(Form1 f, Button example, EventHandler click, bool isVisible, string name, string text, int x_offset = 0, int y_offset = 0)
        {
            Button btn = new Button();
            btn.Width = example.Width;
            btn.Height = example.Height;
            btn.Location = new Point(example.Location.X + x_offset, example.Location.Y + y_offset);
            btn.Name = name;
            btn.Text = text;
            btn.Click += click;
            btn.Visible = isVisible;
            f.Controls.Add(btn);
            return btn;
        }

        public Button create_back_button(Form1 f, Button example1, Button example2, EventHandler click)
        {
            Button back = new Button();
            back.Width = example1.Width / 2 + 20;
            back.Height = example1.Height / 2;
            back.Name = "Back";
            back.Text = "Назад";
            back.Click += click;
            back.Visible = false;
            back.Location = new Point((example1.Location.X + example1.Width + example2.Location.X) / 2 - back.Width / 2, example2.Location.Y + back.Height + example2.Height + 35);
            f.Controls.Add(back);
            return back;
        }

        public Button ButtonEdit(int num, FormEdit form)
        {
            Button btn = new Button();
            btn.Click += form.EditButtonClick;
            btn.Dock = DockStyle.Fill;
            btn.Name = "Edit" + num.ToString();
            btn.Text = "Редактировать";
            return btn;
        }
    }
}
