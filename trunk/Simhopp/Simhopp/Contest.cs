using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Contest
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string location { get; set; }
        public int discipline { get; set; }
        public int sync { get; set; }
        public int diveCount { get; set; }
        public int sex { get; set; }
        public int started;
        List<Judge> Judges { get; set; }
        List<Diver> Divers { get; set; }

        #region Konstruktor
        public Contest() 
        {
            this.ID = -1;
            this.name = "";
            this.location = "";
            this.date = "";
            this.discipline = -1;
            this.sex = -1;
            this.sync = 0;
            this.diveCount = -1;
            this.Judges = new List<Judge>();
            this.Divers = new List<Diver>();
        }

        public Contest(int ID, string name, string date, string location, int discipline, int sync, int diveCount, int sex)
        {
            this.ID = ID;
            this.name = name;
            this.location = location;
            this.date = date;
            this.discipline = discipline;
            this.sex = sex;
            this.sync = sync;
            this.diveCount = diveCount;
            this.Judges = new List<Judge>();
            this.Divers = new List<Diver>();
        }

        public Contest(int ID, string name, string date, string location, int discipline, int sync, int diveCount, int sex, int started)
        {
            this.ID = ID;
            this.name = name;
            this.location = location;
            this.date = date;
            this.discipline = discipline;
            this.sex = sex;
            this.sync = sync;
            this.diveCount = diveCount;
            this.started = started;
            this.Judges = new List<Judge>();
            this.Divers = new List<Diver>();
        }

        public Contest(string name, string date, string location, int discipline, int sync, int diveCount, int sex)
        {
            this.name = name;
            this.location = location;
            this.date = date;
            this.discipline = discipline;
            this.sex = sex;
            this.sync = sync;
            this.diveCount = diveCount;
            this.Judges = new List<Judge>();
            this.Divers = new List<Diver>();
        }
        #endregion

        #region Funktioner

        /// <summary>
        /// Lägg till en domare på eventet
        /// </summary>
        /// <param name="judge"></param>
        public void AddJudge(Judge judge)
        {
            Judges.Add(judge);
        }

        /// <summary>
        /// Lägg till en lista med domare
        /// </summary>
        /// <param name="judges"></param>
        public void AddJudges(List<Judge> judges)
        {
            this.Judges.Clear();
            this.Judges = judges;
        }

        /// <summary>
        /// Lägg till en hoppare på eventet
        /// </summary>
        /// <param name="diver"></param>
        public void AddDiver(Diver diver)
        {
            Divers.Add(diver);
        }

        /// <summary>
        /// Lägg till en lista med hoppare
        /// </summary>
        /// <param name="divers"></param>
        public void AddDivers(List<Diver> divers)
        {
            this.Divers.Clear();
            this.Divers = divers;
        }

        public List<Diver> GetDivers()
        {
            return Divers;
        }


        public List<Judge> GetJudges()
        {
            return Judges;
        }
        #endregion
    }
}
