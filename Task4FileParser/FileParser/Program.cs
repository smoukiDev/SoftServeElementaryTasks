using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamParser sp = new StreamParser(@"C:\BackLog & Estimate.txt", "Constraint");
            Console.WriteLine(sp.CountEnteries());
            Console.ReadLine();
        }
    }
}
