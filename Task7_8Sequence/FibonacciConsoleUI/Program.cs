using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SequencesLib;

namespace FibonacciConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            FibonacciSequance s = FibonacciSequance.Create(1, 89);
            foreach (var item in s.GetSequence())
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
