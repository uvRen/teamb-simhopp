using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class DD
    {
        public string[] DiveNo;
        public string[] DiveName;

        public DD()
        {
            DiveNo = new string[122];
            DiveName = new string[122];
        }

        public static int Difficulty(Dive dive)
        {
            return 1;
        }

        public void FillArrays()
        {
            Database.GetDiveNoFromDDinDatabase(DiveNo, DiveName);
        }

    }
}
