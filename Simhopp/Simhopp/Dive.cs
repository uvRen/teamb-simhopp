using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Dive
    {
        private int ID;
        private Diver person;
        private double difficulty;
        private Event comp;
        private List<Score> scores;

        public double score
        {
            get
            {
                return GetScore();
            }
        } 

        #region Konstruktor
        public Dive()
        {
            this.ID = -1;
            this.person = null;
            this.difficulty = 0.0;
            this.comp = null;
            scores = new List<Score>();
        }

        public Dive(int ID, Diver person, double difficulty, Event comp)
        {
            this.ID = ID;
            this.person = person;
            this.difficulty = difficulty;
            this.comp = comp;
            scores = new List<Score>();
        }
        #endregion

        //medlemsfunktioner
        public void AddScore(Score score)
        {
            scores.Add(score);
        }

        public double GetScore()
        {
            double totalScore, low, high;
            totalScore = high = 0;
            low = 10;
            int scoreCount = 0;
            foreach (Score score in scores)
            {
                scoreCount++;
                totalScore += score.poang;
                if (score.poang <= low)
                    low = score.poang;
                if (score.poang > high)
                    high = score.poang;
            }
            totalScore -= low;
            totalScore -= high;
            totalScore /= (scoreCount - 2);
            totalScore *= difficulty;

            return totalScore;
        }
    }
}
