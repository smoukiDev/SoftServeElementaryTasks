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
            FibonacciSequance s = FibonacciSequance.Create(int.MaxValue - 100000, int.MaxValue);
            foreach (var item in s.GetSequence())
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
