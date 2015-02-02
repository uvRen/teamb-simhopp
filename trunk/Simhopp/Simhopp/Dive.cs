﻿using System;
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
        private Competition comp;

        private Score score {get; set;}

        #region Konstruktor
        public Dive()
        {
            this.ID = -1;
            this.person = null;
            this.difficulty = 0.0;
            this.comp = null;
            this.score = null;
        }

        public Dive(int ID, Diver person, double difficulty, Competition comp, Score score)
        {
            this.ID = ID;
            this.person = person;
            this.difficulty = difficulty;
            this.comp = comp;
            this.score = score;
        }
        #endregion

        //medlemsfunktioner
    }
}
