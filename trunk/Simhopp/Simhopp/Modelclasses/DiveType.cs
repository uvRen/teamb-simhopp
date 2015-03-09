using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Runtime.Serialization;

namespace Simhopp
{
    [DataContract]
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
        [DataMember]
        private static Dictionary<int, Dictionary<DiveHeight, Dictionary<DivePosition, double>>> _dd;

        //_names hämtar hoppnamn från hopp-nummer
        [DataMember]
        private static Dictionary<int, String> _names;
        [IgnoreDataMember]
        private double _difficulty;
        [IgnoreDataMember]
        private string _name;
        [DataMember]
        public int No { get; set; }
        [DataMember]
        public DivePosition Position { get; set; }
        [DataMember]
        public DiveHeight Height { get; set; }

        public double GetHeight()
        {
            DiveHeight a = this.Height;
            switch (a)
            {
                case DiveHeight._1M:
                    return 1;
                case DiveHeight._3M:
                    return 3;
                case DiveHeight._5M:
                    return 5;
                case DiveHeight._7_5M:
                    return 7.5;
                case DiveHeight._10M:
                    return 10;
                default:
                    return -1;
            }
        }

        public void SetPosition(string p)
        {
            switch(p)
            {
                case "A":
                    this.Position = DivePosition.A;
                    break;
                case "B":
                    this.Position = DivePosition.B;
                    break;
                case "C":
                    this.Position = DivePosition.C;
                    break;
                case "D":
                    this.Position = DivePosition.D;
                    break;
                default:
                    break;
            }
        }

        public void SetHeight(double h)
        {
            switch(h.ToString())
            {
                case "1.0":
                    this.Height = DiveHeight._1M;
                    break;
                case "3.0":
                    this.Height = DiveHeight._3M;
                    break;
                case "5.0":
                    this.Height = DiveHeight._5M;
                    break;
                case "7.5":
                    this.Height = DiveHeight._7_5M;
                    break;
                case "10.0":
                    this.Height = DiveHeight._10M;
                    break;
                default:
                    break;
            }
        }
        [DataMember]
        public String Name
        {
            get
            {
                if (_dd == null)
                    LoadDDTable();

                if (_name == null)
                    _name = _names[this.No];

                return _names[this.No];
            }
            set { _name = value; }
        }
        //[DataMember]
        public double Difficulty
        {
            get
            {
                if (_dd == null)
                    LoadDDTable();
                //Returnerar 0 om difficulty inte finns i _dd
                //Annars returnerar difficulty från _dd
                return !_dd[this.No][this.Height].ContainsKey(this.Position) ? 0 : _dd[this.No][this.Height][this.Position];
            }
            set { _difficulty = value; }
        }

        public DiveType(int no, DivePosition position, DiveHeight height)
        {

            if (_dd == null)
                LoadDDTable();

            No = no;
            Position = position;
            Height = height;
        }

        public DiveType(int no)
        {
            No = no;
        }
        public DiveType()
        {
            No = 1;
            Height = DiveHeight._1M;
            Position = DivePosition.A;
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
