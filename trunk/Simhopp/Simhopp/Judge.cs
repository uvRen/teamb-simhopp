﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Simhopp
{
    public class Judge
    {
        public int ID;
        public string name;
        #region Kontruktor
        public Judge() 
        {
            this.ID = -1;
            this.name = "";
        }

        public Judge(int ID, string name)
        {
            this.ID = ID;
            this.name = name;
        }

        public Judge(string name)
        {
            this.name = name;
        }
        #endregion

        #region Funktioner
       

        public void SetJudgeName(string name)
        {
            this.name = name;
        }

        public string GetJudgeName()
        {
            return this.name;
        }

        public int GetJudgeID()
        {
            return this.ID;
        }

        public override string ToString()
        {
            return this.name;
        }
        #endregion
    }
}
