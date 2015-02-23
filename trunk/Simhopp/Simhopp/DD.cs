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

        public static void LoadDDTable()
        {
            if (_diveTypes != null)
                return;

            _diveTypes = new List<DiveType>();

            DataTable dt = Database.GetDDList();
            
            if (dt == null)
            {
                throw new Exception("Kunde ej ladda DD DataTable");
            }

            foreach (DataRow row in dt.Rows)
            {
                foreach (DiveType.DiveHeight diveHeight in Enum.GetValues(typeof (DiveType.DiveHeight)))
                {
                    foreach (DiveType.DivePosition divePosition in Enum.GetValues(typeof (DiveType.DivePosition)))
                    {
                        String colName = "A" + DiveType.GetDescription(diveHeight) + DiveType.GetDescription(divePosition);
                        
                        double difficutly = Double.Parse(row[colName].ToString());

                        if (difficutly.Equals(0))
                            continue;
                        
                        DiveType diveType = new DiveType(
                                Int32.Parse(row["DiveNo"].ToString()),
                                row["DiveName"].ToString(),
                                divePosition,
                                diveHeight,
                                difficutly
                            );
                        _diveTypes.Add(diveType);
                    }
                }
            }
        }

        public static double Difficulty(DiveType diveType)
        {
            foreach (DiveType dt in _diveTypes)
            {
                if (dt.Height == diveType.Height &&
                    dt.No == diveType.No &&
                    dt.Position == diveType.Position)
        {
                    return dt.Difficulty;
                }
            }
            return 0;
        }

        public void FillArrays()
        {
           // Database.GetDiveNoFromDDinDatabase(DiveNo, DiveName);
            return;
        }
    }
}
