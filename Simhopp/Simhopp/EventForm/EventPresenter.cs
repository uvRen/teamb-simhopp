using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class EventPresenter
    {
        
        public IFormEvent view;
        public Event CurrentEvent { get; set; }

        public List<Diver> Divers { get; set; }
        public List<Judge> Judges { get; set; }
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
                return CurrentDiver.dives[CurrentRoundIndex];
            }
        }
        public int CurrentDiverIndex { get; set; }
        public int CurrentRoundIndex { get; set; }
        public int CurrentJudgeIndex { get; set; }

        public EventPresenter(IFormEvent view)
        {
            this.view = view;
        }

        public void CreateTestEvent()
        {
            #region testtävling

            CurrentEvent = new Event(0, "Hopp OS", "Test", "Test", 1, 1, 5, 5);

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
            CurrentEvent.AddDiver(new Diver(0, "Annika"));
            CurrentEvent.AddDiver(new Diver(0, "Annika2"));
            CurrentEvent.AddDiver(new Diver(0, "Annika3"));

            for (int i = 0; i < CurrentEvent.GetDivers().Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Dive dive = new Dive(0, null, j + 1, CurrentEvent);
                    CurrentEvent.GetDivers()[i].AddDive(dive);

                    for (int k = 0; k < 5; k++)
                    {
                        //Score s = new Score(0, null, ev.GetJudges()[k], (k + j) % 11);
                        //dive.AddScore(s);
                    }
                }
            }
            #endregion

            Judges = CurrentEvent.GetJudges();
            Divers = CurrentEvent.GetDivers();

        }

        public Score ScoreDive(double points)
        {

            Score score = new Score(-1, CurrentDiver.dives[CurrentRoundIndex], CurrentJudge, points);
            CurrentDiver.dives[CurrentRoundIndex].AddScore(score); //Add score to current dive

            view.PopulateScoreInput(score, CurrentJudgeIndex);

            CurrentJudgeIndex++;

            if (CurrentJudgeIndex >= Judges.Count)
            {
                view.CurrentDiveScore = CurrentDive.score;

                CurrentJudgeIndex = 0;
                CurrentDiverIndex++;

                if (CurrentDiverIndex >= Divers.Count)
                {
                    CurrentDiverIndex = 0;
                    CurrentRoundIndex++;
                }

                view.CompleteDive();
                view.UpdateLeaderboard();
                view.PrintEventStatus();
            }

            return score;

        }
    }
}
