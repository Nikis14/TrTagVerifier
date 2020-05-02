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
    class Labels
    {
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

        public static Label create_sentence_label(string text, ContentAlignment ca, FontStyle fstyle)
        {
            Label label = create_basic_label(text);
            label.TextAlign = ca;
            label.Font = new Font(label.Font.FontFamily, label.Font.Size, fstyle);
            return label;
        }

        public static Label create_label_with_size(string text, int size)
        {
            Label label = create_label(text);
            label.Font = new Font(label.Font.FontFamily, size, label.Font.Style);
            return label;
        }
    }

    class Panels
    {
        public static Panel create_sentence_panel()
        {
            Panel p = new Panel();
            p.Dock = DockStyle.Fill;
            return p;
        }
    }


    class Pair<T1, T2>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }

        public Pair(T1 t1, T2 t2)
        {
            Item1 = t1;
            Item2 = t2;
        }
    }


}
