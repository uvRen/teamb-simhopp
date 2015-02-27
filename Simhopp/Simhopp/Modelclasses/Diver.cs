using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Diver
    {
        public List<Dive> Dives {get; set;}
        public Diver SyncDiver;
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
        public int Sex { get; set; }
        public string Country { get; set; }
        public double TotalScore
        {
            get
            {
                double _score = 0;
                foreach (Dive dive in Dives)
                {
                    _score += dive.Score;   
                }
                return _score;
            }
        }
        #region Konstruktor
        public Diver()
        {
            this.Id = -1;
            this.Name = "";
            this.Age = -1;
            this.Sex = -1;
            this.Country = "";
            Dives = new List<Dive>();
        }

        public Diver(string name)
        {
            this.Id = -1;
            this.Name = name;
            Dives = new List<Dive>();
        }

        public Diver(int ID, string name)
        {
            this.Id = ID;
            this.Name = name;
            Dives = new List<Dive>();
        }
        public Diver(int ID, string name, int age, int sex, string country)
        {
            this.Id = ID;
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
            this.Country = country;
            Dives = new List<Dive>();
        }

        public Diver(string name, int age, int sex, string country)
        {
            this.Id = -1;
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
            this.Country = country;
            Dives = new List<Dive>();
        }
        #endregion

        #region Funktioner
        public void AddDive(Dive dive)
        {
            Dives.Add(dive);
        }

        public void ScoreDive(int diveNum, Score score)
        {
            Dives[diveNum].AddScore(score);
        }
        #endregion
    }
}
