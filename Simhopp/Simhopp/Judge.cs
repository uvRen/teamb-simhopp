using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Judge
    {
        private int ID;
        private string name;

        //konstruktorer
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

        //medlemsfunktioner
        public void setJudgeName(string name)
        {
            this.name = name;
        }

        public string getJudgeName()
        {
            return this.name;
        }
    }
}
