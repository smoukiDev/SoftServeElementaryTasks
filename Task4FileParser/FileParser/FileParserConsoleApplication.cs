// <copyright file="FileParserConsoleApplication.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>



namespace FileParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class FileParserConsoleApplication : UserInstruction
    {
        private static readonly string SEPARATE_LINE = new string('=', 90);

        public FileParserConsoleApplication()
        {
            this.CompanyName = "Serhii Maksymchuk";
            this.ProductName = "File Parser";
            this.ProductVersion = "v.1.0";
            this.ReleaseDate = new DateTime(2018, 10, 16);
            this.Copyright = $"Copyright(c) "
                           + $"{this.ReleaseDate.Year} "
                           + $"by {this.CompanyName}.All Rights Reserved.";
            this.ProductDescription = "Application helps to parse text files.";
            this.UserManual = "FileParse usage:"
                            + Environment.NewLine
                            + "Get count of matches:"
                            + Environment.NewLine
                            + "FileParser [FilePath] [SearchString]"
                            + Environment.NewLine
                            + "Get count of matches and replace matches without file overwrite:"
                            + Environment.NewLine
                            + "FileParser [FilePath]  [SearchString] [ReplaceString]"
                            + Environment.NewLine
                            + "Get count of matches and replace matches with file overwrite"
                            + Environment.NewLine
                            + "FileParser [--overwrite] [FilePath] [SearchString] [ReplaceString]";
        }

        public override void Display()
        {
            Console.WriteLine(SEPARATE_LINE);
            Console.WriteLine($"{this.ProductName} {this.ProductVersion}");
            Console.WriteLine(SEPARATE_LINE);
            Console.WriteLine($"{this.ProductDescription}");
            Console.WriteLine(SEPARATE_LINE);
            Console.WriteLine($"{this.UserManual}");
            Console.WriteLine(SEPARATE_LINE);
            Console.WriteLine($"{this.Copyright}");
            Console.WriteLine(SEPARATE_LINE);
        }

        private enum NumberOfArgs
        {
            TwoArgs = 2,
            ThreeArgs,
            FourArgs
        }

        public void Run(string[] args)
        {

            switch ((NumberOfArgs)args.Length)
            {
                case NumberOfArgs.TwoArgs:
                    
                    break;
                case NumberOfArgs.ThreeArgs:
                    break;
                case NumberOfArgs.FourArgs:
                    break;
                default:
                    this.Display();
                    break;
            }
        }

        
    }

}
