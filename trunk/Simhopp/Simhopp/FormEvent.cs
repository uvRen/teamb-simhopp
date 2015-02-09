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
        private List<List<Panel>> panels;
        private int currentDiverIndex;
        private int currentRoundIndex;
        private int currentJudgeIndex;

        private List<Color> colors;

        private Event ev;
        private List<Diver> divers;
        private List<Judge> judges;
        public FormEvent()
        {
            InitializeComponent();
            colors = new List<Color>();

            colors.Add(Color.FromArgb(113, 119, 128));
            colors.Add(Color.FromArgb(76, 95, 120));
            colors.Add(Color.FromArgb(44, 72, 112));
            colors.Add(Color.FromArgb(15, 52, 104));
            colors.Add(Color.FromArgb(3, 42, 93));

            #region testtävling
            
            ev = new Event(0, "Test", "Test", "Test", 1, 1, 5, 5);

            ev.AddJudge(new Judge(0, "Mr. Test"));
            ev.AddJudge(new Judge(1, "Mrs. Fest"));
            ev.AddJudge(new Judge(2, "Mr. Mega"));
            ev.AddJudge(new Judge(3, "Mr. Domherre"));
            ev.AddJudge(new Judge(4, "Mr. McFlash"));
            /*
            ev.AddJudge(new Judge(5, "Mr. Dunder"));
            ev.AddJudge(new Judge(6, "Mr. Mega"));
            ev.AddJudge(new Judge(7, "Mr. Bleh bleh"));
            ev.AddJudge(new Judge(8, "Mr. Tjalala"));
             * */

            ev.AddDiver(new Diver(0, "Kalle"));
            ev.AddDiver(new Diver(0, "Greger"));
            ev.AddDiver(new Diver(0, "Hopptjej"));
            ev.AddDiver(new Diver(0, "Annika"));

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Dive dive = new Dive(0, null, j + 1, ev);
                    ev.GetDivers()[i].AddDive(dive);

                    for (int k = 0; k < 5; k++)
                    {
                        //Score s = new Score(0, null, ev.GetJudges()[k], (k + j) % 11);
                        //dive.AddScore(s);
                    }
                }
            }
            #endregion

            panels = new List<List<Panel>>();

            currentDiverIndex = currentRoundIndex = currentJudgeIndex = 0;

            tabControl1.TabPages.Clear();
            tabControl1.Height = 30 + ev.GetDivers().Count * 80;

            for (int i = 0; i < ev.diveCount; i++)
            {
                panels.Add(new List<Panel>());
                tabControl1.TabPages.Add("Runda " + (i + 1));
                tabControl1.SelectedTab.BorderStyle = BorderStyle.None;
                tabControl1.SelectedTab.BackColor = colors[0];
                tabControl1.SelectedTab.ForeColor = colors[0];
                for (int j = 0; j < ev.GetDivers().Count(); j++)
                {
                    Panel p = DivePanel(ev.GetDivers()[j], i);
                    panels[i].Add(p);
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
            judges = ev.GetJudges();
            divers = ev.GetDivers();
            this.BackColor = colors[0];
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

            int pWidth = 402;
            Panel p = new Panel();
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Width = pWidth;
            p.Height = 80;
            p.BackColor = colors[0];

            Label name = new Label();
            name.Text = diver.name;
            name.Top = 2;
            name.Left = 20;
            name.Font = fontName;
            name.ForeColor = Color.White;

            p.Controls.Add(name);


            Label difficulty = new Label();
            difficulty.Text = "Svårighetsgrad: " + dive.difficulty.ToString();
            difficulty.Top = 26;
            difficulty.Left = 20;
            difficulty.Width = p.Width / 2;
            difficulty.ForeColor = Color.White;
            difficulty.Font = new Font(FontFamily.GenericSerif, 10, FontStyle.Bold);

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
            scorePanel.Top = 50;
            scorePanel.BackColor = Color.Transparent;
            scorePanel.Tag = points;

            for (int i = 0; i < ev.GetJudges().Count; i++)
            {
                TextBox tb = new TextBox();
                tb.Text = " ";//diver.dives[round].GetScores()[i].points.ToString();
                tb.Left = 25 + i * 40;
                tb.Width = 25;
                tb.TextAlign = HorizontalAlignment.Center;
                tb.BorderStyle = BorderStyle.None;
                //tb.BackColor = Color.Transparent;
                tb.Height = 25;
                tb.Font = fontScore;
                tb.ForeColor = Color.Black;
                tb.Name = "Score";
                tb.TextChanged += UpdateScore;

                scorePanel.Controls.Add(tb);
            }

            p.Controls.Add(scorePanel);

            return p;
        }

        void UpdateScore(object sender, EventArgs e)
        {
            TextBox tb = ((TextBox)sender);
            double newScorePoint;
            if (tb.Tag == null || !Double.TryParse(tb.Text, out newScorePoint))
                return;

            Score score = (Score)(tb.Tag);
            score.points = newScorePoint;

            Panel scorePanel = (Panel)(tb.Parent);
            Label points = (Label)(scorePanel.Tag);
            points.Text = score.dive.score.ToString();
        }

        private void btnDoDive_Click(object sender, EventArgs e)
        {
            ScoreDive();
        }

        private void btnNextRound_Click(object sender, EventArgs e)
        {
            btnDoDive.Enabled = true;
            btnNextRound.Enabled = false;
            tabControl1.SelectedIndex++;
        }

        private void ScoreDive()
        {
            panels[currentRoundIndex][currentDiverIndex].BackColor = colors[2];
            Panel p = PanelScoring();
            this.Controls.Add(p);
            p.BringToFront();
        }

        private string ScoreTitle()
        {
            string str = "";
            str += divers[currentDiverIndex].name;
            str += ", hopp " + (currentRoundIndex + 1).ToString();
            str += "    Domare: " + judges[currentJudgeIndex].name;
            return str;
        }

        private Panel PanelScoring()
        {
            Panel p = new Panel();
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Width = 730;
            p.Height = 200;
            p.BackColor = colors[1];

            Label judgeName = new Label();
            judgeName.Text = ScoreTitle();
            judgeName.Width = p.Width;
            judgeName.TextAlign = ContentAlignment.MiddleCenter;
            judgeName.Font = new Font(new Font(new FontFamily("Cambria"), 16), FontStyle.Bold);
            judgeName.ForeColor = colors[3];
            judgeName.Top = 10;
            judgeName.Name = "Judge";
            p.Controls.Add(judgeName);

            for (int i = 0; i < 21; i++)
            {
                Button btn = new Button();
                btn.Width = 60;
                btn.Height = 60;
                btn.Text = (i * 0.5).ToString();
                btn.Left = 10 + 32 * i - (i % 2) * 32 + ((i % 2))*32; 
                btn.Top = 45 + (i % 2) * 65; //Varannan uppe / nere
                btn.BackColor = colors[0];
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;

                btn.Font = new Font(new Font(FontFamily.GenericSerif, 20), FontStyle.Bold);
                btn.Tag = p;
                btn.Click += btnScoreClick;
                p.Controls.Add(btn);
            }

            p.Left = (this.Width / 2) - (p.Width / 2);
            p.Top = (this.Height / 2) - (p.Height / 2);

            return p;
        }

        private void btnScoreClick(object sender, EventArgs e)
        {

            Panel p = (Panel)((Button)sender).Tag;
            
            Score score = new Score(-1, divers[currentDiverIndex].dives[currentRoundIndex], judges[currentJudgeIndex], Double.Parse(((Button)sender).Text));
            divers[currentDiverIndex].dives[currentRoundIndex].AddScore(score);
            
            panels[currentRoundIndex][currentDiverIndex].Controls.Find("Score", true)[currentJudgeIndex].Text = ((Button)sender).Text;
            panels[currentRoundIndex][currentDiverIndex].Controls.Find("Score", true)[currentJudgeIndex].Tag = score;
            currentJudgeIndex++;


            if (currentJudgeIndex >= judges.Count)
            {
                p.Dispose();
                currentJudgeIndex = 0;

                panels[currentRoundIndex][currentDiverIndex].BackColor = colors[1];

                //Visa hoppets totala poäng
                panels[currentRoundIndex][currentDiverIndex].Controls.Find("Points", true)[0].Text = divers[currentDiverIndex].dives[currentRoundIndex].score.ToString();

                //Nästa hoppare
                currentDiverIndex++;
                if (currentDiverIndex >= divers.Count)
                {
                    currentDiverIndex = 0;
                    btnDoDive.Enabled = false;
                    btnNextRound.Enabled = true;
                    currentRoundIndex++;
                }
            }
            else
            {
                //Visa nästa domare
                p.Controls.Find("Judge", false)[0].Text = ScoreTitle();
            }
        }
    }
}
