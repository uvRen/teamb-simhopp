﻿using System;
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
            CurrentEvent.AddDiver(new Diver(0, "Hopptjej"));
            CurrentEvent.AddDiver(new Diver(0, "Annika 1"));
            CurrentEvent.AddDiver(new Diver(0, "Annika 2"));
            CurrentEvent.AddDiver(new Diver(0, "Annika 3"));

            for (int i = 0; i < CurrentEvent.Divers.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Dive dive = new Dive(0, CurrentEvent.Divers[i], j + 1, CurrentEvent);
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

        public Score ScoreDive(double points, int judgeIndex = -1)
        {
            while (JudgeServer.IsJudgeClient(_currentJudgeIndex) && CurrentJudgeIndex < Judges.Count - 1)
            {
                CurrentJudgeIndex++;
            }

            Judge scoringJudge = CurrentJudge;
            if (judgeIndex > -1)
            {
                scoringJudge = Judges[judgeIndex];
            }
            Score score = new Score(-1, CurrentDiver.Dives[CurrentRoundIndex], scoringJudge, points);
            CurrentDiver.Dives[CurrentRoundIndex].AddScore(score); //Add score to current dive

            _view.PopulateScoreInput(score, CurrentJudgeIndex);

            CurrentJudgeIndex++;

            //if (CurrentJudgeIndex >= Judges.Count)
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
                _view.UpdateLeaderboard();
                _view.PrintEventStatus();
            }

            if (Mode == ViewMode.Client)
            {
                _judgeClient.CommitScore(_clientJudgeIndex, score);
                _view.EnableControls(false);
            }
            else
            {
                JudgeServer.BroadcastScore(score);
            }
            return score;
        }

        public void ShowView()
        {
            _view.Show();
        }

        public void SetMode(ViewMode mode, int clientJudgeIndex = -1, IJudgeClient judgeClient = null)
        {
            Mode = mode;
            _clientJudgeIndex = clientJudgeIndex;
            _judgeClient = judgeClient;
        }

        public void ScoreRequested(SimhoppMessage msg)
        {
            CurrentRoundIndex = msg.Status.RoundIndex;
            CurrentDiverIndex = msg.Status.DiverIndex;

            _view.EnableControls(true);
            _view.RedrawContestInfo();
        }

        public void RequestScoreFromClients()
        {
            JudgeServer.RequestScore();
        }

        public void LogToServer(string message)
        {
            _view.LogToServer(message);
        }

        public void SubmitClientScore(double points, int judgeIndex)
        {
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
