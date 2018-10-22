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
        static void Main(string[] args)
        {
            //FileParserConsoleApplication application = new FileParserConsoleApplication();
            //application.Run(args);

            string a = "D:\\kurlik.txt";
            string b = "ula";
            using (TextFileMatchParser parser = new TextFileMatchParser(a, b))
            {
                Console.WriteLine(parser.Parse());
            }

            Console.ReadLine();
        }
    }
}
