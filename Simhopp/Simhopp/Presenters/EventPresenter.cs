using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Simhopp
{
    public class EventPresenter
    {
        public enum ViewMode
        {
            Standalone,
            Client
        };

        private int _clientJudgeIndex;
        private int _currentJudgeIndex;
        #region Attributes
        private IJudgeClient _judgeClient;
        public IFormEvent _view;
        public ViewMode Mode { get; private set; }

        public Contest CurrentEvent { get; set; }

        public List<Diver> Divers
        {
            get { return CurrentEvent.Divers; }
            set { CurrentEvent.Divers = value; }
        }

        public List<Judge> Judges
        {
            get { return CurrentEvent.Judges; }
            set { CurrentEvent.Judges = value; }
        }
        public Diver CurrentDiver
        {
            get
            {
                if (CurrentDiverIndex >= Divers.Count)
                    CurrentDiverIndex = Divers.Count - 1;
                return Divers[CurrentDiverIndex];
            }
        }
        public Judge CurrentJudge
        {
            get
            {
                if (CurrentJudgeIndex >= Judges.Count)
                    CurrentJudgeIndex = Judges.Count - 1;

                return Judges[CurrentJudgeIndex];
            }
        }
        public Dive CurrentDive
        {
            get
            {
                return CurrentDiver.Dives[CurrentRoundIndex];
            }
        }
        public int CurrentDiverIndex
        {
            get { return CurrentEvent.CurrentDiverIndex; }
            set { CurrentEvent.CurrentDiverIndex = value; }
        }
        public int CurrentRoundIndex
        {
            get { return CurrentEvent.CurrentRoundIndex; }
            set { CurrentEvent.CurrentRoundIndex = value; }
        }
        public int CurrentJudgeIndex
        {
            get
            {
                if (Mode == ViewMode.Client)
                {
                    return _clientJudgeIndex;
                }
                else
                {
                    return _currentJudgeIndex;
                }
            }
            set { _currentJudgeIndex = value; }
        }
#endregion
        public EventPresenter(IFormEvent view = null, Contest contest = null)
        {
            CurrentEvent = contest;

            if (view == null)
            {
                view = new FormEvent(this);
            }
            _view = view;
            CurrentJudgeIndex = 0;
            JudgeServer.Presenter = this;
        }
        //public void CreateTestEvent()
        //{
        //    #region testtävling

        //    CurrentEvent = new Contest(0, "Hopp OS", "2013-03-15", "Test", 1, 1, 5, 5);

        //    CurrentEvent.AddJudge(new Judge(0, "Mr. Test"));
        //    CurrentEvent.AddJudge(new Judge(1, "Mrs. Fest"));
        //    CurrentEvent.AddJudge(new Judge(2, "Mr. Mega"));
        //    CurrentEvent.AddJudge(new Judge(3, "Mr. Domherre"));
        //    CurrentEvent.AddJudge(new Judge(4, "Mr. McFlash"));
        //    /*
        //    ev.AddJudge(new Judge(5, "Mr. Dunder"));
        //    ev.AddJudge(new Judge(6, "Mr. Mega"));
        //    ev.AddJudge(new Judge(7, "Mr. Bleh bleh"));
        //    ev.AddJudge(new Judge(8, "Mr. Tjalala"));
        //     * */

        //    CurrentEvent.AddDiver(new Diver(0, "Kalle"));
        //    CurrentEvent.AddDiver(new Diver(0, "Greger"));
        //    //CurrentEvent.AddDiver(new Diver(0, "Hopptjej"));
        //    //CurrentEvent.AddDiver(new Diver(0, "Annika 1"));
        //    //CurrentEvent.AddDiver(new Diver(0, "Annika 2"));
        //    //CurrentEvent.AddDiver(new Diver(0, "Annika 3"));

        //    for (int i = 0; i < CurrentEvent.Divers.Count; i++)
        //    {
        //        for (int j = 0; j < 5; j++)
        //        {
        //            DiveType diveType = new DiveType(621 + ((i+j) % 2)*10 + ((i+j)%4), DiveType.DivePosition.A, DiveType.DiveHeight._10M);
        //            Dive dive = new Dive(0, CurrentEvent.Divers[i], CurrentEvent, diveType);
        //            CurrentEvent.Divers[i].AddDive(dive);

        //            for (int k = 0; k < 5; k++)
        //            {
        //                //Score s = new Score(0, dive, CurrentEvent.Judges[k], (k + j) % 11);
        //                //dive.AddScore(s);
        //            }
        //        }
        //    }
        //    #endregion

        //    Judges = CurrentEvent.Judges;
        //    Divers = CurrentEvent.Divers;

        //}
        public void SetMode(ViewMode mode, int clientJudgeIndex = -1, IJudgeClient judgeClient = null, Icon icon = null)
        {
            Mode = mode;
            _clientJudgeIndex = clientJudgeIndex;
            _judgeClient = judgeClient;
            _view.ToggleControls(false, true);
            _view.SetClientLogin();
            if (icon != null)
            {
                _view.SetIcon(icon);
            }
        }

        /// <summary>
        /// Hoppa över hoppare i klient-listan om bedömning sker i standalone
        /// </summary>
        private void SkipToNonClientJudges(bool next = false)
        {
            if (next)
                CurrentJudgeIndex++;

            while (JudgeServer.IsJudgeClient(_currentJudgeIndex) && Mode != ViewMode.Client)
            {
                Console.WriteLine(Mode.ToString() + " Current: " + _currentJudgeIndex + " is client. ++ing");
                _currentJudgeIndex++;
            }

            if (_currentJudgeIndex >= Judges.Count)
            {
                Console.WriteLine(Mode.ToString() + " Current: " + _currentJudgeIndex + " more than count");
                _currentJudgeIndex--;
                _view.ToggleControls(false);
            }
        }

        /// <summary>
        /// Sker när man klickar på ett domar-poäng i standalone
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public Score ScoreDive(double points)
        {
            SkipToNonClientJudges();
            return CreateScoreForDive(points, CurrentJudgeIndex, true);
        }

        /// <summary>
        /// Skapa ett poäng för CurrentDive och lägg till det i Dive
        /// Skicka poängen till domarklienterna om server
        /// Skicka poängen till server om client
        /// </summary>
        /// <param name="points"></param>
        /// <param name="judgeIndex"></param>
        /// <param name="broadcastScore"></param>
        /// <returns></returns>
        private Score CreateScoreForDive(double points, int judgeIndex, bool broadcastScore = true, int roundIndex = -1, int diverIndex = -1)
        {
            if (roundIndex == -1)
                roundIndex = CurrentRoundIndex;

            if (diverIndex == -1)
                diverIndex = CurrentDiverIndex;

            Console.WriteLine(Mode.ToString() + " Scoring: " + points + " for index: " + judgeIndex + " with broadcast:" + broadcastScore.ToString());
            Console.WriteLine(Mode.ToString() + " judgeIndex: " + _currentJudgeIndex + ", roundIndex: " + roundIndex + ", diverIndex: " + diverIndex);

            Judge scoringJudge = Judges[judgeIndex];

            Score score = new Score(Divers[diverIndex].Dives[roundIndex], scoringJudge, points);
            Divers[diverIndex].Dives[roundIndex].AddScore(score); //Add score to current dive

            _view.PopulateScoreInput(score, judgeIndex, diverIndex, roundIndex);

            SkipToNonClientJudges(broadcastScore);

            if (Mode == ViewMode.Client && broadcastScore)
            {
                Console.WriteLine(Mode.ToString() + " Commiting score to client (is client)");
                _judgeClient.CommitScore(_clientJudgeIndex, score);
                _view.ToggleControls(false);
            }
            else if (Mode == ViewMode.Standalone)
            {
                Console.WriteLine(Mode.ToString() + " Broadcasting score (is server)");
                JudgeServer.BroadcastScore(score, roundIndex, diverIndex);
            }

            if (CurrentDive.Scores.Count == CurrentEvent.Judges.Count && Mode == ViewMode.Standalone)
            {
                _view.CurrentDiveScore = CurrentDive.Score;

                Database.AddScoreToDive(CurrentDive.Scores, CurrentDive);

                CurrentJudgeIndex = 0;
                CurrentDiverIndex++;

                SendStatusToClient();
                if (CurrentDiverIndex >= Divers.Count)
                {
                    CurrentDiverIndex = 0;
                    CurrentRoundIndex++;
                }
                _view.CompleteDive();
            }
            return score;
        }

        public void ShowView()
        {
            _view.Show();
        }

        public DialogResult ShowViewDialog()
        {
            return _view.ShowDialog();
        }

        #region Server functions
        public void LogToServer(string message)
        {
            Console.WriteLine(Mode.ToString() + " UDP: " + message);
            _view.LogToServer(message);
        }

        public void AssignJudgeAsClient(int judgeIndex)
        {
            _view.AssignJudgeAsClient(judgeIndex);
        }

        public void LogoutClient(int judgeIndex)
        {
            if (Judges[judgeIndex].isClient)
            {
                CurrentJudgeIndex = judgeIndex;
                _view.ToggleControls(true);
            }

            Judges[judgeIndex].isClient = false;
            _view.RedrawContestInfo();
        }
        
        public void RequestScoreFromClients()
        {
            JudgeServer.RequestScore();
        }

        public void SendStatusToClient()
        {
            JudgeServer.SendStatus();
        }

        public void SubmitClientScore(double points, int judgeIndex, int roundIndex = -1, int diverIndex = -1)
        {
            Console.WriteLine(Mode.ToString() + " Submitting client score: " + points + ", judgeIndex: " + judgeIndex);
            CreateScoreForDive(points, judgeIndex, false, roundIndex, diverIndex);
        }

        public void StartServer()
        {
            JudgeServer.Start();
        }

        public void StopServer()
        {
            JudgeServer.Stop();
        }

        public void Close(bool serverTerminating = false, FormClosingEventArgs e = null)
        {
            if (Mode == ViewMode.Client)
            {
                if (!serverTerminating)
                {
                    _judgeClient.SendLogout(_clientJudgeIndex);
                }
                else
                {
                    _view.CloseInvoke();
                }
            }
            else
            {
                _view.Hide();
                JudgeServer.TerminateServer(true);
                //JudgeServer.Stop(true);
            }
        }

        public void CloseView()
        {
            _view.CloseInvoke();
        }

        public void KickJudges(ListView.SelectedIndexCollection judgeIndicies)
        {
            foreach (int judgeIndex in judgeIndicies)
            {
                JudgeServer.KickJudge(judgeIndex);
            }
        }
        #endregion



#region Client functions
        public void ScoreRequested(SimhoppMessage msg)
        {
            CurrentRoundIndex = msg.Status.RoundIndex;
            CurrentDiverIndex = msg.Status.DiverIndex;

            _view.ToggleControls(true);
            _view.RedrawContestInfo(true);
        }

        public void StatusUpdated(SimhoppMessage msg)
        {
            while (CurrentDive.Scores.Count < CurrentEvent.Judges.Count && Mode == ViewMode.Standalone)
            {
                Thread.Sleep(100);
            }

            CurrentRoundIndex = msg.Status.RoundIndex;
            CurrentDiverIndex = msg.Status.DiverIndex;

            _view.RedrawContestInfo();
        }
#endregion
    }
}
