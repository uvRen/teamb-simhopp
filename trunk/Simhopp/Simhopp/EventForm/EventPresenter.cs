using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    class EventPresenter
    {
        
        public IFormEvent view;

        private List<Diver> divers;
        private List<Judge> judges;
        public Diver CurrentDiver
        {
            get
            {
                return divers[CurrentDiverIndex];
            }
        }
        public Judge CurrentJudge
        {
            get
            {
                return judges[CurrentJudgeIndex];
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

        EventPresenter(IFormEvent view)
        {
            this.view = view;
        }

        public Score ScoreDive(double points)
        {

            Score score = new Score(-1, CurrentDiver.dives[CurrentRoundIndex], CurrentJudge, points);
            CurrentDiver.dives[CurrentRoundIndex].AddScore(score); //Add score to current dive
            CurrentJudgeIndex++;

            if (CurrentJudgeIndex >= judges.Count)
            {
                view.CurrentDiveScore = CurrentDive.score;

                CurrentJudgeIndex = 0;
                CurrentDiverIndex++;

                if (CurrentDiverIndex >= divers.Count)
                {
                    CurrentDiverIndex = 0;
                    CurrentRoundIndex++;
                }

                view.CompleteDive();
                view.UpdateLeaderboard();
            }

            return score;

        }
    }
}
