using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Competition
    {
        private int ID;
        private string name;
        private string location;
        private string date;
        private int diciplin;
        private string gender;
        private int singelSync;
        private int diveCount;

        //konstruktor
        public Competition() 
        {
            this.ID = -1;
            this.name = "";
            this.location = "";
            this.date = "";
            this.diciplin = -1;
            this.gender = "";
            this.singelSync = 0;
            this.diveCount = -1;
        }

        public Competition(int ID, string name, string location, string date, int diciplin, string gender, int singelSync, int diveCount)
        {
            this.ID = ID;
            this.name = name;
            this.location = location;
            this.date = date;
            this.diciplin = diciplin;
            this.gender = gender;
            this.singelSync = singelSync;
            this.diveCount = diveCount;
        }

        //medlemsfunktioner
    }
}
