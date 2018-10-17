// <copyright file="Program.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace FileParser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    class Program
    {
        private static StreamReader a;
        static void Main(string[] args)
        {
            FileParserConsoleApplication application = new FileParserConsoleApplication();
            
            if (a == null)
                Console.WriteLine("null");
            a = new StreamReader("D:\\test.txt");
            if (a != null)
                Console.WriteLine("not null");
            a.Close();
            if (a != null)
                Console.WriteLine("not null");
            Console.ReadLine();

            application.Run(args);
        }
    }
}
