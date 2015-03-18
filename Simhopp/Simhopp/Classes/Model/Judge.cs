using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Simhopp
{
    public class Judge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isClient { get; set; }

        public int Index(List<Judge> judges)
        {
            int i = 0;
            foreach (Judge judge in judges)
            {
                if (judge.Id == this.Id)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        #region Kontruktor
        public Judge() 
        {
            this.Id = -1;
            this.Name = "";
            this.isClient = false;
        }

        public Judge(int ID, string name)
        {
            this.Id = ID;
            this.Name = name;
            this.isClient = false;
        }

        public Judge(string name)
        {
            this.Name = name;
            this.isClient = false;
        }
        #endregion

        #region Funktioner
       

        public void SetJudgeName(string name)
        {
            this.Name = name;
        }

        public string GetJudgeName()
        {
            return this.Name;
        }

        public int GetJudgeID()
        {
            return this.Id;
        }

        public override string ToString()
        {
            return this.Name;
        }
        #endregion
    }
}
