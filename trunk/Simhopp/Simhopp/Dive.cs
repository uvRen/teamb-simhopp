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
        public double difficulty {get; set; }

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

        #region Funktioner
        public void AddScore(Score score)
        {
            scores.Add(score);
        }

        public List<Score> GetScores()
        {
            return scores;
        }

        private double GetScore()
        {
            double totalScore = 0;
            int scoreCount = 0;
            List <double> points = new List<double>();
            int start = 0;
            foreach (Score score in scores)
            {
                points.Add(score.points);
                scoreCount++;
            }

            switch(scoreCount)
            {
                case 3:
                    start = 0;
                        break;
                case 5:
                    start = 1;
                        break;
                case 7:
                    start = 2;
                        break;
                case 9:
                    start = 3;
                        break;
                case 11:
                    start = 4;
                        break;
            }

            points.Sort();

            for (int i = start; i < (scoreCount-start); i++)
            {
                  totalScore += points[i];     
            }

            totalScore *= difficulty;
            return totalScore;
        }
        #endregion
    }
}
