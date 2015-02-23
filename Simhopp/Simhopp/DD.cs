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
            
            foreach (DataRow row in dt.Rows)
            {
                foreach (DiveType.DivePosition divePosition in Enum.GetValues(typeof (DiveType.DivePosition)))
                {
                    foreach (DiveType.DivePosition diveHeight in Enum.GetValues(typeof (DiveType.DivePosition)))
                    {
                        String colName = "A" + diveHeight.ToString() + divePosition.ToString();
                        double difficutly = Double.Parse(row[colName].ToString());
                        DiveType _diveType = new DiveType(
                            Int32.Parse(row["DiveNo"]), row["DiveName"], , );
                        _diveTypes.Add(_diveType);
                    }
                }
            }
        }

        public static int Difficulty(Dive dive)
        {
            return 1;
        }

        public void FillArrays()
        {
           // Database.GetDiveNoFromDDinDatabase(DiveNo, DiveName);
        }
    }
}
