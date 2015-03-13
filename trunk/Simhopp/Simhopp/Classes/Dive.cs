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
        [IgnoreDataMember]
        public Diver _diver;
        public Contest _contest;
        public int Id;
        [DataMember]
        public DiveType _diveType;

        //[DataMember]
        public double Difficulty
        {
            get { return _diveType.Difficulty; }
            set {
                //_diveType.Difficulty = value;
            }
        }

        [DataMember]
        public List<Score> Scores { get; set; }

        public string Name
        {
            get { return _diveType.Name; }
            set { _diveType.Name = value; }
        }

        public double Score
        {
            get
            {
                return CalculateScore();
            }
        } 

        #region Konstruktor
        public Dive()
        {
            this.Id = -1;
            this._diver = null;
            this.Difficulty = 0.0;
            this._contest = null;
            Scores = new List<Score>();
            _diveType = new DiveType(1, DiveType.DivePosition.A, DiveType.DiveHeight._1M);
        }

        public Dive(int diveNumber, DiveType.DiveHeight diveHeight, DiveType.DivePosition divePosition)
        {
            _diveType = new DiveType(diveNumber, divePosition, diveHeight);
        }

        public Dive(int ID, Diver person, double difficulty, Contest comp)
        {
            this.Id = ID;
            this._diver = person;
            this.Difficulty = difficulty;
            this._contest = comp;
            Scores = new List<Score>();
            _diveType = new DiveType(1, DiveType.DivePosition.A, DiveType.DiveHeight._1M);
        }

        public Dive(int ID, Diver person, Contest comp, DiveType diveType)
        {
            this.Id = ID;
            this._diver = person;
            this._contest = comp;
            _diveType = diveType;

            Scores = new List<Score>();
        }

        public Dive(int ID, Diver person, double difficulty, string name, Contest comp)
        {
            this.Id = ID;
            this._diver = person;
            this.Difficulty = difficulty;
            //this.Name = name;
            this._contest = comp;
            Scores = new List<Score>();
            _diveType = new DiveType(1, DiveType.DivePosition.A, DiveType.DiveHeight._1M);
        }
        #endregion

        #region Funktioner
        public void AddScore(Score score)
        {
            if (score.dive == null)
                score.dive = this;
            Scores.Add(score);
        }

        private double CalculateScore()
        {
            double totalScore = 0;
            int scoreCount = 0;
            List <double> points = new List<double>();
            int start = 0;
            foreach (Score score in Scores)
            {
                points.Add(score.Points);
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
