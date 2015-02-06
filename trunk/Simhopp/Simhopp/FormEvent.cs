using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public partial class FormEvent : Form
    {

        private Event e;
        private List<Judge> judges;
        private Diver d1, d2, d3;
        public FormEvent()
        {
            InitializeComponent();

            #region testtävling
            judges = new List<Judge>();
            e = new Event(0, "Test", "Test", "Test", 1, 1, 5, 5);

            judges.Add(new Judge(0, "Mr. Test"));
            judges.Add(new Judge(1, "Mrs. Fest"));
            judges.Add(new Judge(2, "Konstapel Kuk"));
            judges.Add(new Judge(3, "Domherre"));
            judges.Add(new Judge(4, "McFlash"));

            e.AddJudges(judges);

            d1 = new Diver(0, "Kalle");
            d2 = new Diver(0, "Greger");
            d3 = new Diver(0, "Skitunge");

            e.AddDiver(d1);
            e.AddDiver(d2);
            e.AddDiver(d3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Dive dive = new Dive(0, null, j + 1, e);
                    e.GetDivers()[i].AddDive(dive);

                    for (int k = 0; k < 5; k++)
                    {
                        Score s = new Score(0, null, judges[k], (k + j) % 11);
                        dive.AddScore(s);
                    }
                }
            }
            #endregion

            tabControl1.TabPages.Clear();
            groupBox1.Height = 55 + e.GetDivers().Count * 80;
            tabControl1.Height = 30 + e.GetDivers().Count * 80;

            for (int i = 0; i < e.diveCount; i++)
            {
                tabControl1.TabPages.Add("Round " + (i + 1));
                
                for (int j = 0; j < e.GetDivers().Count(); j++)
                {
                    Panel p = DivePanel(e.GetDivers()[j], i);
                    p.Top = (p.Height + 2) * j;
                    tabControl1.TabPages[i].Controls.Add(p);
                }
            }


        }

        public FormEvent(Event e)
        {
            InitializeComponent();
        }

        private void FormEvent_Load(object sender, EventArgs e)
        {

        }

        Panel DivePanel(Diver diver, int round)
        {

            Dive dive = diver.dives[round];

            FontFamily fontFamily = new FontFamily("Cambria");

            Font fontName = new Font(
               fontFamily,
               18,
               FontStyle.Bold,
               GraphicsUnit.Pixel);

            Font fontScore = new Font(
               fontFamily,
               16,
               FontStyle.Bold,
               GraphicsUnit.Pixel);

            int pWidth = 360;
            Panel p = new Panel();
            p.BorderStyle = BorderStyle.Fixed3D;
            p.Width = pWidth;
            p.Height = 80;
            p.BackColor = Color.FromArgb(50, 50, 50);

            Label name = new Label();
            name.Text = diver.name;
            name.Top = 2;
            name.Left = 20;
            name.Font = fontName;
            name.ForeColor = Color.White;

            p.Controls.Add(name);


            Label difficulty = new Label();
            difficulty.Text = "Difficulty: " + dive.difficulty.ToString();// "Difficulty 3"; //dive.difficulty;
            difficulty.Top = 26;
            difficulty.Left = 20;
            difficulty.ForeColor = Color.DarkGray;

            p.Controls.Add(difficulty);


            Panel scorePanel = new Panel();
            scorePanel.Width = pWidth;
            scorePanel.Height = 30;
            scorePanel.Left = 0;
            scorePanel.Top = 50;
            scorePanel.BackColor = Color.Transparent;

            for (int i = 0; i < dive.GetScores().Count; i++)
            {
                TextBox tb = new TextBox();
                tb.Text = diver.dives[round].GetScores()[i].points.ToString();
                tb.Left = 25 + i * 40;
                tb.Width = 25;
                tb.TextAlign = HorizontalAlignment.Center;
                tb.BorderStyle = BorderStyle.None;
                //tb.BackColor = Color.Transparent;
                tb.Height = 25;
                tb.Font = fontScore;
                tb.ForeColor = Color.Black;

                scorePanel.Controls.Add(tb);
            }

            p.Controls.Add(scorePanel);

            return p;
        }
    }
}
