// <copyright file="Program.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace FileParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            StreamParser sp = new StreamParser(@"D:\BackLog & Estimate.txt", "Limitation", "Constraint");
            Console.WriteLine(sp.ReplaceEnteries());
            Console.ReadLine();
        }
    }
}
