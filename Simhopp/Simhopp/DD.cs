using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class DD
    {
        private static List<DiveType> _diveTypes;
        public DD(bool loadFromDatabase)
        {
            _diveTypes = new List<DiveType>();

            if (loadFromDatabase)
            {
                LoadDDTable();
            }
        }

        private static void LoadDDTable()
        {
            DataTable dt = Database.GetDDList();

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
