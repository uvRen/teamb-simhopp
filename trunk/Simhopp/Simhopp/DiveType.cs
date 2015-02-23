using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            A,
            B,
            C,
            D
        };

        /// <summary>
        /// Descriptions är tabellnamn för difficulty i DD-datatable
        /// </summary>
        public enum DiveHeight
        {
            [Description("1")]
            _1M,
            [Description("3")]
            _3M,
            [Description("5")]
            _5M,
            [Description("7_5")]
            _7_5M,
            [Description("10")]
            _10M
        };

        private double _difficulty;

        public int No { get; set; }
        public String Name { get; set; }
        public DivePosition Position { get; set; }
        public DiveHeight Height { get; set; }
        
        public double Difficulty
        {
            get
            {
                return _difficulty.Equals(0) ? DD.Difficulty(this) : _difficulty;
            }
            set
            {
                _difficulty = value;
            }
        }

        public static String GetDescription(Enum en)
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

        public DiveType(int no, DivePosition position, DiveHeight height)
        {
            No = no;
            Name = "";
            Position = position;
            Height = height;
            Difficulty = 0;
        }
        public DiveType(int no, string name, DivePosition position, DiveHeight height, double difficulty)
        {
            No = no;
            Name = name;
            Position = position;
            Height = height;
            Difficulty = difficulty;
        }
    }
}
