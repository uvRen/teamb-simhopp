using System;
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
        private int ID;
        [IgnoreDataMember]
        public Dive dive { get; set; }
        [DataMember]
        public Judge judge {get; set;}
        [DataMember]
        public double points {get; set;}

        #region Konstruktor
        public Score()
        {
            this.ID = -1;
            this.dive = null;
            this.judge = null;
            this.points = 0.0;
        }

        public Score(int ID, Dive d, Judge j, double points)
        {
            this.ID = ID;
            this.dive = d;
            this.judge = j;
            this.points = points;
        }
        #endregion

        #region FUnktioner

        #endregion

    }
}
