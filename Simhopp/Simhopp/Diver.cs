using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Diver
    {
        private List<Dive> dives;
        public int ID { get; set; }
        public string name { get; set; }
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
        }

        public Diver(int ID, string name)
        {
            this.ID = ID;
            this.name = name;
        }
        #endregion

        //medlemsfunktioner
        public void AddDive(Dive dive)
        {
            dives.Add(dive);
        }

        public void ScoreDive(int diveNum, Score score)
        {
            dives[diveNum].AddScore(score);
        }

    }
}
