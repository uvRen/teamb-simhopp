﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    [DataContract]
    public class Score
    {
        [IgnoreDataMember]
        private int Id;
        [IgnoreDataMember]
        public Dive dive { get; set; }
        [DataMember]
        public Judge judge {get; set;}
        [DataMember]
        public double Points {get; set;}

        #region Konstruktor
        public Score()
        {
            this.Id = -1;
            this.dive = null;
            this.judge = null;
            this.Points = 0.0;
        }

        public Score(int ID, Dive d, Judge j, double points)
        {
            this.Id = ID;
            this.dive = d;
            this.judge = j;
            this.Points = points;
        }
        #endregion

        #region FUnktioner

        #endregion

    }
}
