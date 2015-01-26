using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Score
    {
        private int ID;
        private Dive d;
        private Judge j;
        private double poang;

        //konstruktor
        public Score()
        {
            this.ID = -1;
            this.d = null;
            this.j = null;
            this.poang = 0.0;
        }

        public Score(int ID, Dive d, Judge j, double poang)
        {
            this.ID = ID;
            this.d = d;
            this.j = j;
            this.poang = poang;
        }

        //medlemsfunktioner

    }
}
