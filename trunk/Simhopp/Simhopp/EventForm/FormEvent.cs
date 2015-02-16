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
    public partial class FormEvent : Form, IFormEvent
    {

        private EventPresenter _presenter;

        public EventPresenter Presenter
        {
            get
            {
                return _presenter;
            }
            set
            {
                _presenter = value;
                if (value.view == null)
                    value.view = this;
            }
        }


        private List<List<Panel>> divePanels;
        private List<Panel> pagePanels;
        private Panel panelScoring;


        private int CurrentDiverIndex
        {
            get
            {
                return _presenter.CurrentDiverIndex;
            }
            set
            {
                _presenter.CurrentDiverIndex = value;
            }
        }
        private int CurrentRoundIndex
        {
            get
            {
                return _presenter.CurrentRoundIndex;
            }
            set
            {
                _presenter.CurrentRoundIndex = value;
            }
        }
        private int CurrentJudgeIndex
        {
            get
            {
                return _presenter.CurrentJudgeIndex;
            }
            set
            {
                _presenter.CurrentJudgeIndex = value;
            }
        }

        private Diver currentDiver { get { return _presenter.CurrentDiver; } }
        private Judge CurrentJudge { get { return _presenter.CurrentJudge; } }
        private Dive CurrentDive { get { return _presenter.CurrentDive; } }

        private Panel CurrentDivePanel
        {
            get
            {
                return divePanels[CurrentRoundIndex][CurrentDiverIndex];
            }
        }

        public double CurrentDiveScore
        {
            set
            {
                CurrentDivePanel.Controls.Find("Points", true)[0].Text = value.ToString();
            }
            get
            {
                return Double.Parse(CurrentDivePanel.Controls.Find("Points", true)[0].Text);
            }
        }

        private List<Color> colors;

        private Event ev;
        //private List<Diver> divers;
        private List<Judge> judges;
        private List<Diver> divers;

        public FormEvent()
        {
            Presenter = new EventPresenter(this);
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
            ev.AddDiver(new Diver(0, "Annika2"));
            ev.AddDiver(new Diver(0, "Annika3"));

            for (int i = 0; i < ev.GetDivers().Count; i++)
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

            //Initiera objekt
            divePanels = new List<List<Panel>>();
            pagePanels = new List<Panel>();
            CurrentDiverIndex = CurrentRoundIndex = CurrentJudgeIndex = 0;
            tabsRounds.SelectedIndexChanged += tabsRounds_TabIndexChanged;

            //Ladda data från event
            judges = ev.GetJudges();
            //divers = ev.GetDivers();

            //Applicera färgtema
            this.BackColor = colors[0];
            pagePanelContainer.BackColor = colors[1];
            panelControls.BackColor = colors[1];
            listViewLeaderboard.BackColor = colors[1];
            listViewJudges.BackColor = colors[1];
            listViewLeaderboard.ForeColor = Color.White;

            //Skapa poäng-panelen
            panelScoring = ScoringPanel();
            panelControls.Controls.Add(panelScoring);


            //Måla upp alla hopp och skapa tabs
            for (int i = 0; i < ev.diveCount; i++) //Rundor
            {
                tabsRounds.TabPages.Add("Runda " + (i + 1));

                divePanels.Add(new List<Panel>());
                Panel page = new Panel();
                page.Width = pagePanelContainer.Width - 5;
                page.Height = pagePanelContainer.Height;
                page.Top = page.Left = 3;
                page.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
                page.AutoScroll = true;

                pagePanelContainer.Controls.Add(page);
                pagePanels.Add(page);

                for (int j = 0; j < ev.GetDivers().Count(); j++) //Hoppare
                {
                    Panel p = DivePanel(ev.GetDivers()[j], i);
                    divePanels[i].Add(p);
                    p.Top = (p.Height + 2) * j;
                    pagePanels[i].Controls.Add(p);
                }
            }

            //Populera tävlande och domare
            UpdateLeaderboard();
            UpdateJudgeList();
        }

        //Keyboardshortcuts
        private void FormEvent_Load(object sender, EventArgs e)
        {
            btnDoDive.Focus();
            btnDoDive.Select();
        }

        void FormEvent_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(e.KeyChar.ToString());
        }

        void tabsRounds_TabIndexChanged(object sender, EventArgs e)
        {
            pagePanels[tabsRounds.SelectedIndex].BringToFront();
        }

        public void UpdateLeaderboard()
        {
            listViewLeaderboard.Items.Clear();
            var sortedDivers = divers.OrderBy(x => x.TotalScore).Reverse();
            foreach (Diver diver in sortedDivers)
            { 
                ListViewItem tItem = new ListViewItem();
                tItem.Text = diver.name;
                tItem.SubItems.Add(diver.TotalScore.ToString());

                listViewLeaderboard.Items.Add(tItem);
            }
        }

        private void UpdateJudgeList()
        {
            listViewJudges.Items.Clear();
            listViewJudges.Columns[0].Width = listViewJudges.Width - 30;
            foreach (Judge judge in judges)
            {
                ListViewItem tItem = new ListViewItem();
                tItem.Text = judge.name;
                listViewJudges.Items.Add(tItem);

                if (judge == CurrentJudge && panelScoring.Enabled)
                {
                    tItem.BackColor = colors[2];
                    tItem.EnsureVisible();
                }
            }
        }

        void UpdateScore(object sender, EventArgs e)
        {
            TextBox tb = ((TextBox)sender);
            double newScorePoint;
            if (tb.Tag == null || !Double.TryParse(tb.Text, out newScorePoint))
                return;

            if (newScorePoint > 10)
                newScorePoint = 10;
            if (newScorePoint < 0)
                newScorePoint = 0;

            tb.Text = newScorePoint.ToString();

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
            tabsRounds.SelectedIndex++;
            btnDoDive.Focus();
        }

        private void ScoreDive()
        {
            CurrentDivePanel.BackColor = colors[2];
            panelScoring.Enabled = true;
            btnDoDive.Enabled = false;
            UpdateJudgeList();
        }

        /// <summary>
        /// Poängsätt senaste det hoppet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScoreClick(object sender, EventArgs e)
        {

            Score score = _presenter.ScoreDive(Double.Parse(((Button)sender).Text));

            Control scoreInput = CurrentDivePanel.Controls.Find("Score", true)[CurrentJudgeIndex];
            scoreInput.Text = ((Button)sender).Text;
            scoreInput.Tag = score;

            
            UpdateJudgeList();
        }

        public void CompleteDive()
        {
            
            panelScoring.Enabled = false;

            CurrentDivePanel.BackColor = colors[1];

            //Nästa hoppare
            

            //Nästa runda (hopp)
            if (CurrentDiverIndex == 0)
            {
                btnDoDive.Enabled = false;
                btnNextRound.Enabled = true;
                btnNextRound.Focus();
            }
            else
            {
                btnDoDive.Enabled = true;
                btnDoDive.Focus();
            }
        }

        /// <summary>
        /// Ritar upp en panel med information om ett hopp.
        /// Namn
        /// Svårighetsgrad      Hopp-poäng
        /// Domarpoäng
        /// </summary>
        /// <param name="diver">Hoppare</param>
        /// <param name="round">Vilket hopp i ordningen</param>
        /// <returns></returns>
        Panel DivePanel(Diver diver, int round)
        {

            Dive dive = diver.dives[round];

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
            p.Height = 70;
            p.BackColor = colors[1];

            Label name = new Label();
            name.Text = diver.name;
            name.Top = 2;
            name.Left = 20;
            name.Font = fontName;
            name.ForeColor = Color.White;

            p.Controls.Add(name);


            Label difficulty = new Label();
            difficulty.Text = "Svårighetsgrad: " + dive.difficulty.ToString();
            difficulty.Top = 22;
            difficulty.Left = 20;
            difficulty.Width = p.Width / 2;
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
            scorePanel.Top = 42;
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
                tb.BackColor = colors[1];
                tb.ForeColor = Color.White;
                tb.Height = 25;
                tb.Font = fontScore;
                tb.Name = "Score";
                tb.TextChanged += UpdateScore;

                scorePanel.Controls.Add(tb);
            }

            p.Controls.Add(scorePanel);

            return p;
        }

        /// <summary>
        /// Ritar upp en panel med poängalternativ för bedömning av hopp
        /// </summary>
        /// <returns></returns>
        private Panel ScoringPanel()
        {
            Panel p = new Panel();
            p.Width = panelControls.Width - 200;
            p.Height = panelControls.Height;
            p.Left = 100;
            p.Anchor = AnchorStyles.Top;
            
            p.BackColor = colors[1];

            for (int i = 0; i < 21; i++)
            {
                Button btn = new Button();
                btn.Width = 60;
                btn.Height = 60;
                btn.Text = (i * 0.5).ToString();
                btn.Left = 10 + 32 * i - (i % 2) * 32 + ((i % 2)) * 32;
                btn.Top = 20 + (i % 2) * 65; //Varannan uppe / nere
                btn.BackColor = colors[0];
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;

                btn.Font = new Font(new Font(FontFamily.GenericSerif, 20), FontStyle.Bold);
                btn.Click += btnScoreClick;
                p.Controls.Add(btn);
            }

            p.Enabled = false;
            return p;
        }
    }
}
