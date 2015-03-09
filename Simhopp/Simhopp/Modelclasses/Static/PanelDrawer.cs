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
        public static List<Color> Colors
        {
            get
            {
                if (_colors == null)
                    Init();
                return _colors;
            }
        }
        private static List<Color> _colors;

        /// <summary>
        /// Skapar färg-tema. Måste anropas innan någon uppmålning
        /// </summary>
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

                if (c is TableLayoutPanel)
                {
                    TableLayoutPanel tmp = (TableLayoutPanel)c;
                    tmp.BackColor = _colors[0];
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
                    tmp.BorderStyle = BorderStyle.FixedSingle;
                    
                }

                if (c is ComboBox)
                {
                    ComboBox tmp = (ComboBox)c;
                    tmp.BackColor = _colors[1];
                    tmp.ForeColor = Color.White;
                    

                }

                if (c is DataGridView)
                {
                    DataGridView tmp = (DataGridView)c;
                    tmp.BackgroundColor = _colors[1];
                    for (int i = 0; i < tmp.RowCount; i++)
                    {
                        tmp.Rows[i].DefaultCellStyle.BackColor = _colors[1];
                        tmp.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }

        /// <summary>
        /// Ritar upp en panel med information om ett hopp.
        /// Layout-sketch:
        /// 
        ///     [Namn]
        ///     ([DD])  [Hopp-typ]      [Hopp-poäng]
        ///     [] [] [] [] [] < Domarpoäng
        /// 
        /// </summary>
        /// <param name="diver">Hoppare</param>
        /// <param name="round">Vilket hopp i ordningen</param>
        /// <returns></returns>
        public static Panel DivePanel(Diver diver, int round, int judgeCount, EventHandler UpdateScoreDelegate)
        {
            Init();

            Dive dive = diver.Dives[round];

            FontFamily fontFamily = new FontFamily("Cambria");

            Font fontName = new Font(
               fontFamily,
               15,
               FontStyle.Bold,
               GraphicsUnit.Pixel);

            Font fontScore = new Font(
               fontFamily,
               18,
               FontStyle.Bold,
               GraphicsUnit.Pixel);

            int pWidth = 402;
            Panel p = new Panel();
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Width = pWidth;
            p.Height = 74;
            p.BackColor = _colors[1];

            Label name = new Label();
            name.Text = diver.Name;
            name.Top = 2;
            name.Left = 20;
            name.Font = fontName;
            name.ForeColor = Color.White;

            p.Controls.Add(name);


            Label difficulty = new Label();
            difficulty.Text = "[" + dive.Difficulty + "] " + dive.Name;
            difficulty.Top = 22;
            difficulty.Left = 20;
            difficulty.AutoSize = true;
            difficulty.MaximumSize = new Size(p.Width - 60, 22);
            difficulty.ForeColor = Color.White;
            difficulty.Font = new Font(fontName, FontStyle.Regular);

            p.Controls.Add(difficulty);


            Label points = new Label();
            points.Text = "";
            points.Left = p.Width - points.Width - 10;
            points.Top = 10;
            points.Font = fontName;
            points.TextAlign = ContentAlignment.MiddleRight;
            points.ForeColor = Color.White;
            points.Name = "Points";

            p.Controls.Add(points);

            Panel scorePanel = new Panel();
            scorePanel.Width = pWidth;
            scorePanel.Height = 30;
            scorePanel.Left = 0;
            scorePanel.Top = 45;
            scorePanel.BackColor = Color.Transparent;
            scorePanel.Tag = points;

            for (int i = 0; i < judgeCount; i++)
            {
                TextBox tb = new TextBox();
                tb.Text = " ";
                tb.Left = 24 + i * 40;
                tb.Width = 32;
                tb.Height = 22;
                tb.TextAlign = HorizontalAlignment.Center;
                tb.BorderStyle = BorderStyle.None;
                tb.BackColor = _colors[1];
                tb.ForeColor = Color.White;
                tb.Font = fontScore;
                tb.Name = "Score";
                tb.TextChanged += UpdateScoreDelegate;

                scorePanel.Controls.Add(tb);
            }

            p.Controls.Add(scorePanel);

            return p;
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

                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = _colors[0];

                btn.Font = new Font(new Font(FontFamily.GenericSerif, 20), FontStyle.Bold);
                btn.Click += handler;
                p.Controls.Add(btn);
            }

            p.Enabled = false;
            return p;
        }
    }
}
