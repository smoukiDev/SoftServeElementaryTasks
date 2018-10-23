// <copyright file="FileParserConsoleApplication.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace FileParser
{
    using System;
    using System.IO;

    /// <summary>
    /// Specifies number of input arguments
    /// </summary>
    public enum NumberOfArgs
    {
        /// <summary>
        /// One argument
        /// </summary>
        One = 1,

        /// <summary>
        /// Two arguments
        /// </summary>
        Two = 2,

        /// <summary>
        /// Three arguments
        /// </summary>
        Three = 3,

        /// <summary>
        /// Four arguments
        /// </summary>
        Four = 4
    }

    /// <summary>
    /// Represent console application for parsing files
    /// </summary>
    public class FileParserConsoleApplication
    {
        private static readonly string SEPARATE_LINE = new string('=', 90);
        private static readonly string WARNING_LINE = new string('!', 90);
        private const string OVERWRITE_FLAG = "--overwrite";
        private const string USER_GUIDE_LOSTED = "User Guide file losted";

        /// <summary>
        /// Displays user guide from resource file
        /// </summary>
        /// <exception cref="FileNotFoundException">User Guide file losted/</exception>
        public void DisplayGuide()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            string path = Directory.GetCurrentDirectory() + "\\UserGuide\\FileParserGuide.txt";
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        Console.WriteLine(reader.ReadLine());
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(USER_GUIDE_LOSTED);
            }

            Console.WriteLine("Press Enter...");
            Console.ReadLine();
        }

        /// <summary>
        /// Gets console input arguments and runs application
        /// </summary>
        /// <param name="args">Console input arguments</param>
        public void Run(string[] args)
        {
            try
            {
                switch ((NumberOfArgs)args.Length)
                {
                    case NumberOfArgs.Two:
                        this.FindMatches(args[0], args[1]);
                        break;
                    case NumberOfArgs.Three:
                        this.ReplaceMatches(args[0], args[1], args[2]);
                        break;
                    case NumberOfArgs.Four:
                        this.ReplaceMatches(args[1], args[2], args[3], args[0]);
                        break;
                    default:
                        this.DisplayGuide();
                        break;
                }
            }
            catch (InvalidFlagException ex)
            {
                Console.WriteLine(WARNING_LINE);
                Console.WriteLine(ex.Message);
                Console.WriteLine(WARNING_LINE);
                this.DisplayGuide();
            }
            catch (FileToParseNotFoundException ex)
            {
                Console.WriteLine(WARNING_LINE);
                Console.WriteLine(ex.Message);
                Console.WriteLine(WARNING_LINE);
                this.DisplayGuide();
            }
            catch (FileIsEmptyException ex)
            {
                Console.WriteLine(WARNING_LINE);
                Console.WriteLine(ex.Message);
                Console.WriteLine(WARNING_LINE);
                this.DisplayGuide();
            }
        }

        private void FindMatches(string filePath, string searchPattern)
        {
            using (TextFileMatchParser parser = new TextFileMatchParser(filePath, searchPattern))
            {
                int result = parser.Parse();
                Console.WriteLine($"{result} matches have been detected");
            }
        }

        private void ReplaceMatches(string filePath, string searchPattern, string replacePattern)
        {
            using (TextFileReplacementParser parser = new TextFileReplacementParser(filePath, searchPattern, replacePattern))
            {
                int result = parser.Parse();
                Console.WriteLine($"{result} matches have been replaced");
                Console.Write("Copy of file with changes has been saved ");
                Console.Write($"Path: {parser.FileCopy}");
                Console.WriteLine();
            }
        }

        /// <exception cref="InvalidFlagException">Application doesn't support such a flag</exception>
        private void ReplaceMatches(string filePath, string searchPattern, string replacePattern, string flag)
        {
            if (flag != OVERWRITE_FLAG)
            {
                string message = $"Application doesn't support such a flag {flag}.";
                throw new InvalidFlagException(message);
            }

            using (TextFileReplacementParser parser = new TextFileReplacementParser(filePath, searchPattern, replacePattern, true))
            {
                int result = parser.Parse();
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
