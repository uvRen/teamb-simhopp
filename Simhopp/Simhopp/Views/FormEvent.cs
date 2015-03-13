using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public partial class FormEvent : Form, IFormEvent
    {
        #region Variables
        public EventPresenter Presenter
        {
            get
            {
                return _presenter;
            }
            set
            {
                _presenter = value;
                if (value._view == null)
                    value._view = this;
            }
        }
        public double CurrentDiveScore
        {
            set
            {
                //CurrentDive.Score = value;
                //CurrentDivePanel.Controls.Find("Points", true)[0].Text = value.ToString();
            }
            get
            {
                return Double.Parse(CurrentDivePanel.Controls.Find("Points", true)[0].Text);
            }
        }

        private EventPresenter _presenter;
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
        private Diver CurrentDiver { get { return _presenter.CurrentDiver; } }
        private Judge CurrentJudge { get { return _presenter.CurrentJudge; } }
        private Dive CurrentDive { get { return _presenter.CurrentDive; } }
        private Panel CurrentDivePanel
        {
            get
            {
                return _divePanels[CurrentRoundIndex][CurrentDiverIndex];
            }
        }
        private List<Judge> Judges
        {
            get
            {
                return _presenter.Judges;
            }
        }
        private List<Diver> Divers
        {
            get
            {
                return _presenter.Divers;
            }
        }

        //Panels
        private List<List<Panel>> _divePanels;
        private List<Panel> _pagePanels;
        private Panel _panelScoring;
        #endregion

        public FormEvent(EventPresenter presenter = null)
        {
            if (presenter == null)
            {
                Presenter = new EventPresenter(this);
                Presenter.CreateTestEvent();
            }
            else
            {
                Presenter = presenter;
            }

            InitializeComponent();

            //Initiera objekt
            _divePanels = new List<List<Panel>>();
            _pagePanels = new List<Panel>();
            CurrentDiverIndex = CurrentRoundIndex = CurrentJudgeIndex = 0;
            tabsRounds.SelectedIndexChanged += tabsRounds_TabIndexChanged;

            DrawPanels();
        }

        private void FormEvent_Load(object sender, EventArgs e)
        {
            btnDoDive.Focus();
            btnDoDive.Select();
        }

        delegate void LogToServerCallback(string text);
        public void LogToServer(string message)
        {
            if (this.textBoxSeverLog.InvokeRequired)
            {
                LogToServerCallback d = new LogToServerCallback(LogToServer);
                this.Invoke(d, new object[] { message });
            }
            else
            {
                this.textBoxSeverLog.Text = message + "\r\n" + textBoxSeverLog.Text;
            }
        }

        private void DrawPanels()
        {
            //Applicera färgtema
            PanelDrawer.Colorize(this);

            //Skapa poäng-panelen
            _panelScoring = PanelDrawer.ScoringPanel(panelControls, new EventHandler(btnScoreClick));
            panelControls.Controls.Add(_panelScoring);

            //Måla upp alla hopp och skapa tabs
            for (int i = 0; i < CurrentDiver.Dives.Count; i++) //Rundor
            {
                tabsRounds.TabPages.Add("Runda " + (i + 1));

                _divePanels.Add(new List<Panel>());

                /* Formattera */
                Panel page = new Panel();
                page.Width = pagePanelContainer.Width - 5;
                page.Height = pagePanelContainer.Height;
                page.Top = page.Left = 3;
                page.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
                page.AutoScroll = true;

                /* Lägg till i form och i lista */
                pagePanelContainer.Controls.Add(page);
                _pagePanels.Add(page);

                for (int j = 0; j < Divers.Count(); j++) //Hoppare
                {
                    Panel p = PanelDrawer.DivePanel(Divers[j], i, Judges.Count, UpdateScore);
                    _divePanels[i].Add(p);
                    p.Top = (p.Height + 2) * j;
                    _pagePanels[i].Controls.Add(p);
                }
            }

            //Populera tävlande och domare
            RedrawContestInfo();
        }


        delegate void RedrawDelegate(bool highlightDivePanel = false);
        

        public void RedrawContestInfo(bool highlightDivePanel = false)
        {
            if (this.listViewLeaderboard.InvokeRequired)
            {
                RedrawDelegate d = new RedrawDelegate(RedrawContestInfo);
                this.Invoke(d, highlightDivePanel);
                return;
            }

            UpdateLeaderboard();
            UpdateJudgeList();
            UpdateJudgeScores();
            PrintEventStatus();

            tabsRounds.SelectedIndex = CurrentRoundIndex;

            if (highlightDivePanel)
                HighlightCurrentDive();
        }

        #region Printa data för tävling
        public void PrintEventStatus()
        {
            List<string> necessaryInfo = Presenter.CurrentEvent.GetCollectedContestInfo();
            labelTitle.Text = Presenter.CurrentEvent.Name;
            labelSummary.Text = Presenter.CurrentEvent.Location + "\n" + necessaryInfo[1] + "\n" + necessaryInfo[2];
            labelRound.Text = "Runda\n" + (CurrentRoundIndex + 1) + " av " + Presenter.CurrentEvent.diveCount;
            labelDiver.Text = "Hoppare\n" + (CurrentDiverIndex + 1) + " av " + Divers.Count;
        }

        public void UpdateLeaderboard()
        {
            listViewLeaderboard.Items.Clear();
            var sortedDivers = Divers.OrderBy(x => x.TotalScore).Reverse();
            foreach (Diver diver in sortedDivers)
            { 
                ListViewItem tItem = new ListViewItem();
                tItem.Text = diver.Name;
                tItem.SubItems.Add(diver.TotalScore.ToString());

                listViewLeaderboard.Items.Add(tItem);
            }
        }

        /// <summary>
        /// Uppdatera input-rutor med domar-poäng från Diver.Dive.Score-objekten
        /// </summary>
        public void UpdateJudgeScores()
        {
            int iDiver, iDive;
            iDiver = iDive = 0;
            foreach (Diver diver in _presenter.Divers)
            {
                iDive = 0;
                foreach (Dive dive in diver.Dives)
                {
                    foreach (Score score in dive.Scores)
                    {
                        score.dive = dive;

                        List<Panel> diverPanels = _divePanels[iDive];
                        Control[] scoreTextBoxes = diverPanels[iDiver].Controls.Find("Score", true);
                        int scoringJudgeIndex = score.judge.Index(_presenter.Judges); //Hämta index på domare för detta poäng

                        TextBox scoreInput = (TextBox)scoreTextBoxes[scoringJudgeIndex];

                        scoreInput.Tag = score;
                        scoreInput.Text = score.Points.ToString();

                        if (dive.Scores.Count < Judges.Count)
                            break;

                        //Uppdatera hopptes total-poäng
                        Panel scorePanel = (Panel)(scoreInput.Parent);
                        Label points = (Label)diverPanels[iDiver].Controls.Find("Points", true)[0];
                        points.Text = score.dive.Score.ToString();
                    }
                    iDive++;
                }
                iDiver++;
            }

        }

        private void UpdateJudgeList()
        {
            listViewJudges.Items.Clear();
            listViewJudges.Columns[0].Width = listViewJudges.Width - 30;
            
            foreach (Judge judge in Judges)
            {
                ListViewItem tItem = new ListViewItem();
                tItem.Text = judge.Name;
                listViewJudges.Items.Add(tItem);

                if (judge == CurrentJudge && _panelScoring.Enabled)
                {
                    tItem.Text = "» " + tItem.Text;
                    //tItem.Font = new Font(tItem.Font, FontStyle.Bold);
                    tItem.BackColor = PanelDrawer.Colors[2];
                    tItem.EnsureVisible();
                }
            }
        }

        #endregion


        void tabsRounds_TabIndexChanged(object sender, EventArgs e)
        {
            _pagePanels[tabsRounds.SelectedIndex].BringToFront();
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
            score.Points = newScorePoint;

            Panel scorePanel = (Panel)(tb.Parent);
            Label points = (Label)(scorePanel.Tag);
            points.Text = score.dive.Score.ToString();
        }


        private void btnDoDive_Click(object sender, EventArgs e)
        {
            _presenter.RequestScoreFromClients();
            ScoreDive();
        }

        delegate void ToggleControlsDelegate(bool enable, bool hideControls = false);


        public void EnableControls(bool enable, bool hideControls = false)
        {
            if (this._panelScoring.InvokeRequired)
            {
                ToggleControlsDelegate d = new ToggleControlsDelegate(EnableControls);
                this.Invoke(d, new object[] {enable, hideControls});
                return;
            }
            _panelScoring.Enabled = enable;
            if (_presenter.Mode == EventPresenter.ViewMode.Client)
            {
                btnDoDive.Enabled = false;
                btnNextRound.Enabled = false;
            }
            else
            {
                btnDoDive.Enabled = enable;
                btnNextRound.Enabled = enable;
            }

            if (hideControls)
            {
                btnDoDive.Visible = false;
                btnNextRound.Visible = false;
            }
        }

        private void btnNextRound_Click(object sender, EventArgs e)
        {
            btnDoDive.Enabled = true;
            btnNextRound.Enabled = false;
            tabsRounds.SelectedIndex++;
            btnDoDive.Focus();
            _presenter.SendStatusToClient();
        }

        private void HighlightCurrentDive()
        {
            CurrentDivePanel.BackColor = PanelDrawer.Colors[2];
        }

        private void ScoreDive()
        {
            HighlightCurrentDive();
            _panelScoring.Enabled = true;
            btnDoDive.Enabled = false;
            UpdateJudgeList();
        }

        
        /// <summary>
        /// Knapptryck för poängsättning senaste det hoppet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScoreClick(object sender, EventArgs e)
        {
            ScoreCurrentDive(Double.Parse(((Button)sender).Text));
        }

        private void ScoreCurrentDive(double points)
        {
            Score score = Presenter.ScoreDive(points);
            UpdateJudgeList();
            UpdateJudgeScores();
        }

        private delegate void PopulateScoreInputDelegate(Score score, int judgeIndex);
        public void PopulateScoreInput(Score score, int judgeIndex)
        {
            if (CurrentDivePanel.InvokeRequired)
            {
                PopulateScoreInputDelegate d = new PopulateScoreInputDelegate(PopulateScoreInput);
                this.Invoke(d, new object[] {score, judgeIndex});
                return;
            }
            TextBox scoreInput = (TextBox)CurrentDivePanel.Controls.Find("Score", true)[judgeIndex];
            scoreInput.Text = score.Points.ToString();
            scoreInput.Tag = score;
        }

        
        delegate void CompleteDiveDelegate();
        
        public void CompleteDive()
        {
            if (_panelScoring.InvokeRequired)
            {
                CompleteDiveDelegate d = new CompleteDiveDelegate(CompleteDive);
                this.Invoke(d);
                return;
            }
            _panelScoring.Enabled = false;

            //CurrentDivePanel.BackColor = PanelDrawer.Colors[1];

            //Nästa runda (hopp)
            if (CurrentDiverIndex == 0)
            {
                btnDoDive.Enabled = false;
                btnNextRound.Enabled = true;
            }
            else
            {
                btnDoDive.Enabled = true;
            }

            //Sista hoppet - avsluta tävling
            if (CurrentRoundIndex == _presenter.CurrentEvent.diveCount)
            {
                btnDoDive.Enabled = false;
                btnNextRound.Enabled = false;
            }

            UpdateJudgeScores();
            UpdateLeaderboard();
            PrintEventStatus();
        }


        private void btnStartServer_Click(object sender, EventArgs e)
        {
            labelServerStatus.Text = "Klientinloggning startad";

            btnStopServer.Location = btnStartServer.Location;

            btnStartServer.Visible = false;
            btnStopServer.Visible = true;

            _presenter.StartServer();
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {

        }

        public void SetClientLogin()
        {
            foreach (Control c in panelServer.Controls)
            {
                c.Visible = false;
            }

            labelClientServerTitle.Visible = true;
            labelClientServerTitle.Text = "Inloggad som: " + CurrentJudge.Name;
            labelClientServerTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelClientServerTitle.Top = (panelServer.Height/2) - (labelClientServerTitle.Height/2);
        }

        private void FormEvent_FormClosing(object sender, FormClosingEventArgs e)
        {
            _presenter.Close();
        }

        private void FormEvent_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FormEvent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && btnDoDive.Enabled)
            {
                e.SuppressKeyPress = true;
                btnDoDive_Click(btnDoDive, null);
            }

            if (e.KeyCode == Keys.Space && btnNextRound.Enabled)
            {
                e.SuppressKeyPress = true;
                btnNextRound_Click(btnNextRound, null);
            }

            if (!_panelScoring.Enabled)
                return;

            if ((e.KeyValue < 48 || e.KeyValue > 58) && e.KeyValue != 220)
            {
                e.SuppressKeyPress = true;
                return;
            }

            double points = e.KeyValue - 48;

            if (points == 0)
                points = 10;

            if (e.KeyValue == 220)
                points = 0;

            if (e.Shift && points < 10)
                points += 0.5;

            ScoreCurrentDive(points);
        }
    }
}
