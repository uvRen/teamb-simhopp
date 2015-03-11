using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public class Contest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public int Discipline { get; set; }
        public int Sync { get; set; }
        public int diveCount { get; set; }
        public int sex { get; set; }
        public int started;
        public List<Judge> Judges { get; set; }
        public List<Diver> Divers { get; set; }

        /// <summary>
        /// [0] Discipline, [1] Singel/Sync, [2] Male/Female, [3] Location, [4] Date, [5] Name
        /// </summary>
        /// <returns></returns>
        public List<string> GetCollectedContestInfo()
        {
            List<string> collected = new List<string>();

            switch (Discipline)
            {
                case 0:
                    collected.Add("1m");
                    break;
                case 1:
                    collected.Add("3m");
                    break;
                case 2:
                    collected.Add("5m");
                    break;
                case 3:
                    collected.Add("7,5m");
                    break;
                case 4:
                    collected.Add("10m");
                    break;
                default:
                    collected.Add("N/A");
                    break;
            }

            switch (Sync)
            {
                case 0:
                    collected.Add("Singel");
                    break;
                case 1:
                    collected.Add("Synkroniserat");
                    break;
                default:
                    collected.Add("N/A");
                    break;
            }

            switch (sex)
            {
                case 0:
                    collected.Add("Män");
                    break;
                case 1:
                    collected.Add("Kvinnor");
                    break;
                default:
                    collected.Add("N/A");
                    break;
            }

            collected.Add(Location);
            collected.Add(Date);
            collected.Add(Name);

            return collected;
        }

        public int CurrentDiverIndex { get; set; }
        public int CurrentRoundIndex { get; set; }

        #region Konstruktor
        public Contest() 
        {
            this.Id = -1;
            this.Name = "";
            this.Location = "";
            this.Date = "";
            this.Discipline = -1;
            this.sex = -1;
            this.Sync = 0;
            this.diveCount = -1;
            this.Judges = new List<Judge>();
            this.Divers = new List<Diver>();

            CurrentRoundIndex = CurrentDiverIndex = 0;
        }

        public Contest(int ID, string name, string date, string location, int discipline, int sync, int diveCount, int sex)
        {
            this.Id = ID;
            this.Name = name;
            this.Location = location;
            this.Date = date;
            this.Discipline = discipline;
            this.sex = sex;
            this.Sync = sync;
            this.diveCount = diveCount;
            this.Judges = new List<Judge>();
            this.Divers = new List<Diver>();

            CurrentRoundIndex = CurrentDiverIndex = 0;
        }

        public Contest(int ID, string name, string date, string location, int discipline, int sync, int diveCount, int sex, int started = 0)
        {
            this.Id = ID;
            this.Name = name;
            this.Location = location;
            this.Date = date;
            this.Discipline = discipline;
            this.sex = sex;
            this.Sync = sync;
            this.diveCount = diveCount;
            this.started = started;
            this.Judges = new List<Judge>();
            this.Divers = new List<Diver>();

            CurrentRoundIndex = CurrentDiverIndex = 0;
        }

        public Contest(string name, string date, string location, int discipline, int sync, int diveCount, int sex)
        {
            this.Name = name;
            this.Location = location;
            this.Date = date;
            this.Discipline = discipline;
            this.sex = sex;
            this.Sync = sync;
            this.diveCount = diveCount;
            this.Judges = new List<Judge>();
            this.Divers = new List<Diver>();

            CurrentRoundIndex = CurrentDiverIndex = 0;
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
        #endregion
    }
}
