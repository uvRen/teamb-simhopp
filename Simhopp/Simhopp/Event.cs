using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Event
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string location { get; set; }
        public int discipline { get; set; }
        public int sync { get; set; }
        public int diveCount { get; set; }
        public int sex { get; set; }
        List<Judge> judges;
        List<Diver> divers;

        #region Konstruktor
        public Event() 
        {
            this.ID = -1;
            this.name = "";
            this.location = "";
            this.date = "";
            this.discipline = -1;
            this.sex = -1;
            this.sync = 0;
            this.diveCount = -1;
            this.judges = new List<Judge>();
            this.divers = new List<Diver>();
        }

        public Event(int ID, string name, string date, string location, int discipline, int sync, int diveCount, int sex)
        {
            this.ID = ID;
            this.name = name;
            this.location = location;
            this.date = date;
            this.discipline = discipline;
            this.sex = sex;
            this.sync = sync;
            this.diveCount = diveCount;
            this.judges = new List<Judge>();
            this.divers = new List<Diver>();
        }
        #endregion
        //medlemsfunktioner

        /// <summary>
        /// Lägg till en domare på eventet
        /// </summary>
        /// <param name="judge"></param>
        public void AddJudge(Judge judge)
        {
            judges.Add(judge);
        }

        /// <summary>
        /// Lägg till en lista med domare
        /// </summary>
        /// <param name="judges"></param>
        public void AddJudges(List<Judge> judges)
        {
            this.judges.Clear();
            this.judges = judges;
        }

        ////*-thomas////////*-thomas////////*-thomas////////*-thomas////////*-thomas////////*-thomas////
        /// <summary>
        /// Lägg till en hoppare på eventet
        /// </summary>
        /// <param name="diver"></param>
        public void AddDiver(Diver diver)
        {
            divers.Add(diver);
        }

        /// <summary>
        /// Lägg till en lista med hoppare
        /// </summary>
        /// <param name="divers"></param>
        public void AddDivers(List<Diver> divers)
        {
            this.divers.Clear();
            this.divers = divers;
        }

        public List<Diver> GetDivers()
        {
            return divers;
        }
        ////*-thomas////////*-thomas////////*-thomas////////*-thomas////////*-thomas////////*-thomas////


        public List<Judge> GetJudges()
        {
            return judges;
        }
    }
}
