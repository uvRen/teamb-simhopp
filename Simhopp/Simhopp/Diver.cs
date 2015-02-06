using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Diver
    {
        public List<Dive> dives {get; set;}
        public int ID { get; set; }
        public string name { get; set; }

        public int age { get; set; }
        public int sex { get; set; }
        public string country { get; set; }
        public double TotalScore
        {
            get
            {
                double _score = 0;
                foreach (Dive dive in dives)
                {
                    _score += dive.score;   
                }
                return _score;
            }
        }
        #region Konstruktor
        public Diver()
        {
            this.ID = -1;
            this.name = "";
            this.age = -1;
            this.sex = -1;
            this.country = "";
            dives = new List<Dive>();
        }

        public Diver(int ID, string name)
        {
            this.ID = ID;
            this.name = name;
            dives = new List<Dive>();
        }
        public Diver(int ID, string name, int age, int sex, string country)
        {
            this.ID = ID;
            this.name = name;
            this.age = age;
            this.sex = sex;
            this.country = country;
            dives = new List<Dive>();
        }
        #endregion

        #region Funktioner
        public void AddDive(Dive dive)
        {
            dives.Add(dive);
        }

        public void ScoreDive(int diveNum, Score score)
        {
            dives[diveNum].AddScore(score);
        }

        public List<Dive> GetDives()
        {
            return dives;
        }
        #endregion
    }
}
