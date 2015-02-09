using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    delegate int Check();
    class Program
    {
        static int checkJudges()
        {
            return 1;
        }
        static int checkDivers()
        {
            return 1;
        }
        static int checkName()
        {
            return 1;
        }
        static void Main(string[] args)
        {
            int antal = 0;
            Check a, b, c, d;
            a = checkJudges;
            b = checkDivers;
            c = checkName;
            d = a + b + c;

            antal = checkDivers() + checkJudges() + checkName();

            Console.WriteLine("a = checkJudges(): " + a());
            Console.WriteLine("b = checkDivers(): " + b());
            Console.WriteLine("c = checkName(): " + c());
            Console.WriteLine("d = a + b + c: " + d());
            Console.WriteLine("Antal: " + antal);

            Console.ReadLine();
        }
    }
}

