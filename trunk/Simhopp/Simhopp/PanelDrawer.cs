using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    /// <summary>
    /// Class för att rita custom-paneler för simhopp
    /// </summary>
    public class PanelDrawer
    {
        private static List<Color> _colors;

        private static void Init()
        {
            if (_colors == null)
            {
                _colors = new List<Color>();
                _colors.Add(Color.FromArgb(113, 119, 128));
                _colors.Add(Color.FromArgb(76, 95, 120));
                _colors.Add(Color.FromArgb(44, 72, 112));
                _colors.Add(Color.FromArgb(15, 52, 104));
                _colors.Add(Color.FromArgb(3, 42, 93));
            }
        }

        public static void Colorize(Control f, bool isForm = true)
        {
            Init();

            if (isForm)
                f.BackColor = _colors[0];

            foreach (Control c in f.Controls)
            {
                // MessageBox.Show(c.GetType().ToString());
                if (c.HasChildren)
                {
                    Colorize(c, false);
                }

                if (c is Label || c is GroupBox || c is RadioButton)
                {
                    c.ForeColor = Color.White;
                }

                if (c is Button)
                {
                    Button tmp = (Button)c;
                    tmp.BackColor = _colors[2];
                    tmp.ForeColor = Color.White;
                    tmp.FlatStyle = FlatStyle.Flat;
                    tmp.FlatAppearance.BorderSize = 0;
                    tmp.FlatAppearance.BorderColor = Color.White;
                    tmp.FlatAppearance.CheckedBackColor = _colors[3];
                }

                if (c is Panel)
                {
                    Panel tmp = (Panel)c;
                    tmp.BackColor = _colors[1];
                    tmp.ForeColor = Color.White;
                }

                if (c is ListView)
                {
                    ListView tmp = (ListView)c;
                    tmp.BackColor = _colors[1];
                    tmp.ForeColor = Color.White;
                    tmp.BorderStyle = BorderStyle.None;
                    tmp.GridLines = false;
                }

                if (c is ListBox)
                {
                    ListBox tmp = (ListBox)c;
                    tmp.BackColor = _colors[1];
                    tmp.ForeColor = Color.White;
                    tmp.BorderStyle = BorderStyle.None;
                }

                if (c is TextBox)
                {
                    TextBox tmp = (TextBox)c;
                    tmp.BackColor = _colors[1];
                    tmp.ForeColor = Color.White;
                    tmp.BorderStyle = BorderStyle.None;
                }
            }
        }

        /// <summary>
        /// Ritar upp en panel med poängalternativ för bedömning av hopp
        /// </summary>
        /// <returns></returns>
        public static Panel ScoringPanel(Panel container, EventHandler handler)
        {
            Init();
            Panel p = new Panel();
            p.Width = container.Width - 200;
            p.Height = container.Height;
            p.Left = 100;
            p.Anchor = AnchorStyles.Top;

            p.BackColor = _colors[1];

            for (int i = 0; i < 21; i++)
            {
                Button btn = new Button();
                btn.Width = 60;
                btn.Height = 60;
                btn.Text = (i * 0.5).ToString();
                btn.Left = 10 + 32 * i - (i % 2) * 32 + ((i % 2)) * 32;
                btn.Top = 20 + (i % 2) * 65; //Varannan uppe / nere
                btn.BackColor = _colors[0];
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;

                btn.Font = new Font(new Font(FontFamily.GenericSerif, 20), FontStyle.Bold);
                btn.Click += handler;
                p.Controls.Add(btn);
            }

            p.Enabled = false;
            return p;
        }
    }
}
