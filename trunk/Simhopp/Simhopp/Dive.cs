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
        private Jumper person;
        private double difficulty;
        private Competition comp;

        //konstruktor
        public Dive()
        {
            this.ID = -1;
            this.person = null;
            this.difficulty = 0.0;
            this.comp = null;
        }

        public Dive(int ID, Jumper person, double difficulty, Competition comp)
        {
            this.ID = ID;
            this.person = person;
            this.difficulty = difficulty;
            this.comp = comp;
        }

        //medlemsfunktioner
    }
}
