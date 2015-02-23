using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Simhopp
{
    internal class DiveType
    {
        public enum DivePosition
        {
            A,
            B,
            C,
            D
        };

        public enum DiveHeight
        {
            _1M,
            _3M,
            _5M,
            _7_5M,
            _10M
        };
        public int No { get; set; }
        public String Name { get; set; }
        public DivePosition Position { get; set; }
        public DiveHeight Height { get; set; }
    }
}
