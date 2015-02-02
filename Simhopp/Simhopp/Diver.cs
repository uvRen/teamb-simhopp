using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Diver
    {
        private int ID;
        public List<Dive> dives;
        private string name { get; set; }

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
