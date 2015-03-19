using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Simhopp
{
    public partial class FormEvent : Form, IFormEvent
    {
        #region Attributes
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
        public bool Closing { get; set; }
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
            Closing = false;
            if (presenter == null)
            {
                Exception ex = new Exception("Ingen presenter");
                ExceptionHandler.Handle(ex);
            }
            else
            {
                Presenter = presenter;
            }

            if (_presenter.CurrentEvent.Divers.Count > 0)
            {
                if (_presenter.CurrentEvent.Divers[0].Dives.Count != _presenter.CurrentEvent.diveCount)
                {
                    Exception ex = new Exception("Antal hopp i tävlingen matchar inte deltagares hopp!");
                    ExceptionHandler.Handle(ex);
                }
            }

            InitializeComponent();

            //Initiera objekt
            _divePanels = new List<List<Panel>>();
            _pagePanels = new List<Panel>();

            CurrentDiverIndex = CurrentRoundIndex = CurrentJudgeIndex = 0;
            tabsRounds.SelectedIndexChanged += tabsRounds_TabIndexChanged;

            DrawPanels();
        }

        public void SetIcon(Icon icon)
        {
            this.Icon = icon;
        }

        private void FormEvent_Load(object sender, EventArgs e)
        {
            this.Text += " - " + _presenter.CurrentEvent.Name;
        }

        delegate void LogToServerCallback(string text);
        /// <summary>
        /// Logga nätverkskommunikation till domarfönstret. Användas ej i release.
        /// </summary>
        /// <param name="message"></param>
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


        /// <summary>
        /// Målar upp tabs och hopp-rutor för alla dykare i eventet
        /// </summary>
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
        /// <summary>
        /// Tävlingsinfo
        /// Sammanfattning
        /// Hopp Runda
        /// </summary>
        public void PrintEventStatus()
        {
            List<string> necessaryInfo = Presenter.CurrentEvent.GetCollectedContestInfo();
            labelTitle.Text = Presenter.CurrentEvent.Name;
            labelSummary.Text = Presenter.CurrentEvent.Location + "\n" + necessaryInfo[1] + "\n" + necessaryInfo[2] + "\n" + necessaryInfo[0];
            labelRound.Text = "Runda\n" + (CurrentRoundIndex + 1) + " av " + Presenter.CurrentEvent.diveCount;
            labelDiver.Text = "Hoppare\n" + (CurrentDiverIndex + 1) + " av " + Divers.Count;
        }

        /// <summary>
        /// Leaderboard
        /// Tävlande och poäng
        /// </summary>
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

                        TextBox scoreInput = (TextBox)scoreTextBoxes[scoringJudgeIndex]; //Poängruta för en domare på ett hopp

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

                if (judge.isClient)
                {
                    tItem.ImageIndex = 2;
                }
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

        /// <summary>
        /// Använder tabbarna för att måla upp egna panels (tabpages var fula)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tabsRounds_TabIndexChanged(object sender, EventArgs e)
        {
            _pagePanels[tabsRounds.SelectedIndex].BringToFront();
        }

        delegate void ToggleControlsDelegate(bool enable, bool hideControls = false);
        /// <summary>
        /// (Av)Aktivera knappar beroende på skede i tävlingen (bedömning/mellan hopp)
        /// </summary>
        /// <param name="enable"></param>
        /// <param name="hideControls"></param>
        public void ToggleControls(bool enable, bool hideControls = false)
        {
            if (this._panelScoring.InvokeRequired)
            {
                ToggleControlsDelegate d = new ToggleControlsDelegate(ToggleControls);
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

        /// <summary>
        /// Bedöm ett hopp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDoDive_Click(object sender, EventArgs e)
        {
            _presenter.RequestScoreFromClients();
            HighlightCurrentDive();
            _panelScoring.Enabled = true;
            btnDoDive.Enabled = false;
            UpdateJudgeList();
        }

        private void HighlightCurrentDive()
        {
            CurrentDivePanel.BackColor = PanelDrawer.Colors[2];
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

        /// <summary>
        /// Poängsätt senaste hoppet
        /// </summary>
        /// <param name="points"></param>
        private void ScoreCurrentDive(double points)
        {
            Score score = Presenter.ScoreDive(points);
            UpdateJudgeList();
            UpdateJudgeScores();
        }

        /// <summary>
        /// Starta nästa runda med hopp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextRound_Click(object sender, EventArgs e)
        {
            btnDoDive.Enabled = true;
            btnNextRound.Enabled = false;
            tabsRounds.SelectedIndex++;
            _presenter.SendStatusToClient();
        }

        /// <summary>
        /// Skriv ut domarpoäng på respektive poängruta
        /// Anropas när poäng kommer från/till en domarklient
        /// </summary>
        /// <param name="score"></param>
        /// <param name="judgeIndex"></param>
        private delegate void PopulateScoreInputDelegate(Score score, int judgeIndex, int diverIndex = -1, int roundIndex = -1);
        public void PopulateScoreInput(Score score, int judgeIndex, int diverIndex = -1, int roundIndex = -1)
        {
            if (diverIndex == -1)
                diverIndex = CurrentDiverIndex;

            if (roundIndex == -1)
                roundIndex = CurrentRoundIndex;

            Panel divePanel = _divePanels[roundIndex][diverIndex];
            if (divePanel.InvokeRequired)
            {
                PopulateScoreInputDelegate d = new PopulateScoreInputDelegate(PopulateScoreInput);
                this.Invoke(d, new object[] {score, judgeIndex, diverIndex, roundIndex});
                return;
            }
            TextBox scoreInput = (TextBox)divePanel.Controls.Find("Score", true)[judgeIndex];
            scoreInput.Text = score.Points.ToString();
            scoreInput.Tag = score;
        }
        
        delegate void CompleteDiveDelegate();
        /// <summary>
        /// Hopp genomfört - dölj poängsättning och räkna ut poäng
        /// </summary>
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

        /// <summary>
        /// Manuell redigering av domarpoäng på ett hopp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            _presenter.StopServer();

            labelServerStatus.Text = "Klientinloggning avstängd";

            btnStartServer.Visible = true;
            btnStopServer.Visible = false;
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
            listViewJudges.ContextMenuStrip.Items.Clear();
        }

        public void AssignJudgeAsClient(int judgeIndex)
        {
            Judges[judgeIndex].isClient = true;
            RedrawContestInfo();
        }

        private void FormEvent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Closing)
            {
                e.Cancel = true;
                _presenter.Close(false);
            }
        }
        delegate void CloseInvokeDelegate();
        /// <summary>
        /// Hopp genomfört - dölj poängsättning och räkna ut poäng
        /// </summary>
        public void CloseInvoke()
        {
            if (this.InvokeRequired)
            {
                CloseInvokeDelegate d = new CloseInvokeDelegate(CloseInvoke);
                this.Invoke(d);
                return;
            }
            Closing = true;
            if (_presenter.Mode == EventPresenter.ViewMode.Client)
            {
                MessageBox.Show("Servern stängde anslutningen.\n\nProgrammet avslutas.", "Avslutas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            this.Close();
        }

        /// <summary>
        /// Kortkomamndon för poängsättning och stegande genom tävlingen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormEvent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.FormEventHelp_label.Visible = true;
            }

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

        private void FormEvent_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.FormEventHelp_label.Visible = false;
            }
        }

        private void judgeMenuKick_Click(object sender, EventArgs e)
        {
            _presenter.KickJudges(listViewJudges.SelectedIndices);
        }

        private void judgeMenuRequest_Click(object sender, EventArgs e)
        {

        }
    }
}
