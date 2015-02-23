using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Simhopp
{
    public class DiveType
    {
        public enum DivePosition
        {
            A, B, C, D
        };

        /// <summary>
        /// Descriptions är tabellnamn för difficulty i DD-datatable
        /// </summary>
        public enum DiveHeight
        {
            [Description("1")] _1M,
            [Description("3")] _3M,
            [Description("5")] _5M,
            [Description("7_5")] _7_5M,
            [Description("10")] _10M
        };

        //_dd håller information om svårighetsgraf för hopp.
        //Användning: _dd[nummer][höjd][position]
        private static Dictionary<int, Dictionary<DiveHeight, Dictionary<DivePosition, double>>> _dd;

        //_names hämtar hoppnamn från hopp-nummer
        private static Dictionary<int, String> _names;

        private double _difficulty;
        private String _name;

        public int No { get; set; }

        public String Name
        {
            get { return _names[this.No]; }
            set { _name = value; }
        }
        public double Difficulty
        {
            get
            {
                //Returnerar 0 om difficulty inte finns i _dd
                //Annars returnerar difficulty från _dd
                return !_dd[this.No][this.Height].ContainsKey(this.Position) ? 0 : _dd[this.No][this.Height][this.Position];
            }
            set { _difficulty = value; }
        }

        public DivePosition Position { get; set; }
        public DiveHeight Height { get; set; }
        
        public DiveType(int no, DivePosition position, DiveHeight height)
        {
            No = no;
            Position = position;
            Height = height;
        }


        /// <summary>
        /// Hämtar DD-listan från databasen
        /// Måste anropas (endast en gång) innan man kan hämta Difficulty och Namn
        /// </summary>
        public static void LoadDDTable()
        {
            if (_dd != null)
                return;

            _dd = new Dictionary<int, Dictionary<DiveHeight, Dictionary<DivePosition, double>>>();
            _names = new Dictionary<int, string>();

            DataTable dt = Database.GetDDList();

            if (dt == null)
            {
                throw new Exception("Kunde ej ladda DD DataTable");
            }

            //Loopa rader
            foreach (DataRow row in dt.Rows)
            {
                int diveNo = Int32.Parse(row["DiveNo"].ToString());
                _names[diveNo] = row["DiveName"].ToString();
                _dd[diveNo] = new Dictionary<DiveHeight, Dictionary<DivePosition, double>>();

                //Loopa möjliga hopp-höjder
                foreach (DiveType.DiveHeight diveHeight in Enum.GetValues(typeof(DiveType.DiveHeight)))
                {
                    _dd[diveNo][diveHeight] = new Dictionary<DivePosition, double>();

                    //Loopa möjliga hopp-positioner
                    foreach (DiveType.DivePosition divePosition in Enum.GetValues(typeof(DiveType.DivePosition)))
                    {
                        //Hämtar kolumnnamn för höjd och position
                        String colName = "A" + ColumnNameFromEnum(diveHeight) + ColumnNameFromEnum(divePosition);

                        double difficutly = Double.Parse(row[colName].ToString());

                        if (difficutly.Equals(0))
                            continue;
                        
                        _dd[diveNo][diveHeight][divePosition] = difficutly;
                    }
                }
            }
        }

        /// <summary>
        /// Hämtar kolumnnamn på enum från dess Description-attribut
        /// </summary>
        /// <param name="en">DivePosition eller DiveHeight</param>
        /// <returns></returns>
        private static String ColumnNameFromEnum(Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }
    }
}
