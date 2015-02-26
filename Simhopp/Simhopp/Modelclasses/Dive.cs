using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    [DataContract]
    public class Dive
    {
        private int ID;
        [IgnoreDataMember]
        private Diver diver;
        [DataMember]
        public double Difficulty {get; set; }
        public string Name { get; set; }
        private Contest comp;
        [DataMember]
        public List<Score> Scores { get; set; }

        private DiveType _diveType;

        public double Score
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
            this.diver = null;
            this.Difficulty = 0.0;
            this.comp = null;
            Scores = new List<Score>();
        }

        public Dive(int diveNumber, DiveType.DiveHeight diveHeight, DiveType.DivePosition divePosition)
        {
            _diveType = new DiveType(diveNumber, divePosition, diveHeight);
        }

        public Dive(int ID, Diver person, double difficulty, Contest comp)
        {
            this.ID = ID;
            this.diver = person;
            this.Difficulty = difficulty;
            this.comp = comp;
            Scores = new List<Score>();
        }

        public Dive(int ID, Diver person, double difficulty, string name, Contest comp)
        {
            this.ID = ID;
            this.diver = person;
            this.Difficulty = difficulty;
            this.Name = name;
            this.comp = comp;
            Scores = new List<Score>();
        }
        #endregion

        #region Funktioner
        public void AddScore(Score score)
        {
            if (score.dive == null)
                score.dive = this;
            Scores.Add(score);
        }

        private List<Score> GetScores()
        {
            return Scores;
        }

        private double GetScore()
        {
            double totalScore = 0;
            int scoreCount = 0;
            List <double> points = new List<double>();
            int start = 0;
            foreach (Score score in Scores)
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
            }

            points.Sort();

            for (int i = start; i < (scoreCount-start); i++)
            {
                  totalScore += points[i];     
            }

            totalScore *= Difficulty;
            return totalScore;
        }
        #endregion
    }
}
