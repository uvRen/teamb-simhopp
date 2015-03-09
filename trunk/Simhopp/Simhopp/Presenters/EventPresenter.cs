using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
                return Divers[CurrentDiverIndex];
            }
        }
        public Judge CurrentJudge
        {
            get
            {
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
        public void CreateTestEvent()
        {
            #region testtävling

            CurrentEvent = new Contest(0, "Hopp OS", "Test", "Test", 1, 1, 5, 5);

            CurrentEvent.AddJudge(new Judge(0, "Mr. Test"));
            CurrentEvent.AddJudge(new Judge(1, "Mrs. Fest"));
            CurrentEvent.AddJudge(new Judge(2, "Mr. Mega"));
            CurrentEvent.AddJudge(new Judge(3, "Mr. Domherre"));
            CurrentEvent.AddJudge(new Judge(4, "Mr. McFlash"));
            /*
            ev.AddJudge(new Judge(5, "Mr. Dunder"));
            ev.AddJudge(new Judge(6, "Mr. Mega"));
            ev.AddJudge(new Judge(7, "Mr. Bleh bleh"));
            ev.AddJudge(new Judge(8, "Mr. Tjalala"));
             * */

            CurrentEvent.AddDiver(new Diver(0, "Kalle"));
            CurrentEvent.AddDiver(new Diver(0, "Greger"));
            //CurrentEvent.AddDiver(new Diver(0, "Hopptjej"));
            //CurrentEvent.AddDiver(new Diver(0, "Annika 1"));
            //CurrentEvent.AddDiver(new Diver(0, "Annika 2"));
            //CurrentEvent.AddDiver(new Diver(0, "Annika 3"));

            for (int i = 0; i < CurrentEvent.Divers.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    DiveType diveType = new DiveType(621 + ((i+j) % 2)*10 + ((i+j)%4), DiveType.DivePosition.A, DiveType.DiveHeight._10M);
                    Dive dive = new Dive(0, CurrentEvent.Divers[i], CurrentEvent, diveType);
                    CurrentEvent.Divers[i].AddDive(dive);

                    for (int k = 0; k < 5; k++)
                    {
                        //Score s = new Score(0, dive, CurrentEvent.Judges[k], (k + j) % 11);
                        //dive.AddScore(s);
                    }
                }
            }
            #endregion

            Judges = CurrentEvent.Judges;
            Divers = CurrentEvent.Divers;

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
                _view.EnableControls(false);
            }
        }

        private Score CreateScoreForDive(double points, int judgeIndex, bool broadcastScore = true)
        {
            Console.WriteLine(Mode.ToString() + " Scoring: " + points + " for index: " + judgeIndex + " with broadcast:" + broadcastScore.ToString());
            Console.WriteLine(Mode.ToString() + " Current: " + _currentJudgeIndex);
            Judge scoringJudge = Judges[judgeIndex];
            
            Score score = new Score(-1, CurrentDiver.Dives[CurrentRoundIndex], scoringJudge, points);
            CurrentDiver.Dives[CurrentRoundIndex].AddScore(score); //Add score to current dive

            _view.PopulateScoreInput(score, judgeIndex);

            SkipToNonClientJudges(broadcastScore);

            if (CurrentDive.Scores.Count == CurrentEvent.diveCount)
            {
                _view.CurrentDiveScore = CurrentDive.Score;
                
                CurrentJudgeIndex = 0;
                CurrentDiverIndex++;

                if (CurrentDiverIndex >= Divers.Count)
                {
                    CurrentDiverIndex = 0;
                    CurrentRoundIndex++;
                }
                _view.CompleteDive();
            }

            if (Mode == ViewMode.Client && broadcastScore)
            {
                Console.WriteLine(Mode.ToString() + " Commiting score to client (is client)");
                _judgeClient.CommitScore(_clientJudgeIndex, score);
                _view.EnableControls(false);
            }
            else if (Mode == ViewMode.Standalone)
            {
                Console.WriteLine(Mode.ToString() + " Broadcasting score (is server)");
                JudgeServer.BroadcastScore(score);
            }
            return score;
        }

        public void ShowView()
        {
            _view.Show();
        }

        public void ShowViewDialog()
        {
            _view.ShowDialog();
        }

        public void SetMode(ViewMode mode, int clientJudgeIndex = -1, IJudgeClient judgeClient = null)
        {
            Mode = mode;
            _clientJudgeIndex = clientJudgeIndex;
            _judgeClient = judgeClient;
            _view.EnableControls(false, true);
        }

        public void ScoreRequested(SimhoppMessage msg)
        {
            CurrentRoundIndex = msg.Status.RoundIndex;
            CurrentDiverIndex = msg.Status.DiverIndex;

            _view.EnableControls(true);
            _view.RedrawContestInfo(true);
        }

        public void StatusUpdated(SimhoppMessage msg)
        {
            CurrentRoundIndex = msg.Status.RoundIndex;
            CurrentDiverIndex = msg.Status.DiverIndex;

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

        public void LogToServer(string message)
        {
            Console.WriteLine(Mode.ToString() + " UDP: " + message);
            _view.LogToServer(message);
        }

        public void SubmitClientScore(double points, int judgeIndex)
        {
            Console.WriteLine(Mode.ToString() + " Submitting client score: " + points + ", judgeIndex: " + judgeIndex);
            CreateScoreForDive(points, judgeIndex, false);
            return;

            Judge scoringJudge = Judges[judgeIndex];
            Score score = new Score(-1, CurrentDiver.Dives[CurrentRoundIndex], scoringJudge, points);
            CurrentDiver.Dives[CurrentRoundIndex].AddScore(score); //Add score to current dive

            JudgeServer.BroadcastScore(score);

            _view.RedrawContestInfo();
        }

        public void StartServer()
        {
            JudgeServer.Start();
        }
    }
}
