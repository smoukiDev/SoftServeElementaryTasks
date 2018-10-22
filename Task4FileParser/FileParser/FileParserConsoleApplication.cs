// <copyright file="FileParserConsoleApplication.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace FileParser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class FileParserConsoleApplication : UserInstruction
    {
        private static readonly string SEPARATE_LINE = new string('=', 90);
        private static readonly string WARNING_LINE = new string('!', 90);
        private static readonly string OVERWRITE_FLAG = "--overwrite";

        public FileParserConsoleApplication()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            this.CompanyName = "Serhii Maksymchuk";
            this.ProductName = "File Parser";
            this.ProductVersion = "v.1.0";
            this.ReleaseDate = new DateTime(2018, 10, 16);
            this.Copyright = $"Copyright(c) "
                           + $"{this.ReleaseDate.Year} "
                           + $"by {this.CompanyName}.All Rights Reserved.";

            this.ProductDescription = "Application helps to parse text files.";

            this.UserManual = $"FileParse usage:"
                            + Environment.NewLine
                            + $"Get count of matches:"
                            + Environment.NewLine
                            + $"FileParser [FilePath] [SearchString]"
                            + Environment.NewLine
                            + $"Get count of matches and replace matches without file overwrite:"
                            + Environment.NewLine
                            + $"FileParser [FilePath]  [SearchString] [ReplaceString]"
                            + Environment.NewLine
                            + $"Get count of matches and replace matches with file overwrite"
                            + Environment.NewLine
                            + $"FileParser {OVERWRITE_FLAG} [FilePath] [SearchString] [ReplaceString]";
        }

        public void Run(string[] args)
        {
            try
            {
                switch ((NumberOfArgs)args.Length)
                {
                    case NumberOfArgs.TwoArgs:
                        this.FindMatches(args[0], args[1]);
                        break;
                    case NumberOfArgs.ThreeArgs:
                        this.ReplaceMatches(args[0], args[1], args[2]);
                        break;
                    case NumberOfArgs.FourArgs:
                        this.ReplaceMatches(args[1], args[2], args[3], args[0]);
                        break;
                    default:
                        this.Display();
                        break;
                }
            }
            catch (InvalidFlagException ex)
            {
                Console.WriteLine(WARNING_LINE);
                Console.WriteLine(ex.Message);
                this.Display();
            }
            //catch (ZeroReplaceException ex)
            //{
            //    Console.WriteLine(WARNING_LINE);
            //    Console.WriteLine(ex.Message);
            //}
            catch (FileToParseNotFoundException ex)
            {
                Console.WriteLine(WARNING_LINE);
                Console.WriteLine(ex.Message);
            }
            catch (FileIsEmptyException ex)
            {
                Console.WriteLine(WARNING_LINE);
                Console.WriteLine(ex.Message);
            }
        }

        private enum NumberOfArgs
        {
            TwoArgs = 2,
            ThreeArgs,
            FourArgs
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

        private void FindMatches(string filePath, string searchPattern)
        {
            using (StreamParser streamParser = new StreamParser(filePath, searchPattern))
            {
                int result = streamParser.CountEnteries();
                Console.WriteLine($"{result} matches have been detected");
            }
        }

        private void ReplaceMatches(string filePath, string searchPattern, string replacePattern)
        {
            using (StreamParser streamParser = new StreamParser(filePath, searchPattern, replacePattern))
            {
                int result = streamParser.ReplaceEnteries();
                Console.WriteLine($"{result} matches have been replaced");
                Console.Write("Copy of file with changes has been saved ");
                Console.Write($"Path: {streamParser.TempFilePath}");
            }
        }

        private void ReplaceMatches(string filePath, string searchPattern, string replacePattern, string flag)
        {
            if (flag != OVERWRITE_FLAG)
            {
                string message = $"Application doesn't support such a flag {flag}.";
                throw new InvalidFlagException(message);
            }

            using (StreamParser streamParser = new StreamParser(filePath, searchPattern, replacePattern, true))
            {
                int result = streamParser.ReplaceEnteries();
                Console.WriteLine($"{result} matches have been replaced");
                Console.WriteLine("File has been overwritten.");
            }
        }

        private class InvalidFlagException : Exception
        {
            public InvalidFlagException()
            {
            }

            public InvalidFlagException(string message)
                : base(message)
            {
            }

            public InvalidFlagException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }
    }
}
