// <copyright file="LuckyTicketsConsoleApplication.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace LuckyTicket.UserInterface
{
    using System;
    using System.IO;

    /// <summary>
    /// Represents LuckyTickets console application
    /// </summary>
    public class LuckyTicketsConsoleApplication
    {
        private static readonly string SEPARATE_LINE = new string('=', 60);
        private static readonly string WARNING_LINE = new string('!', 60);

        private const string USER_GUIDE_LOSTED = "User Guide not found.";
        private const string FILE_WITH_MARKER_LOSTED = "File with marker not found.";
        private const string INCORRECT_MARKER = "Incorrect alghorithm marker.";
        private const string INCORRECT_BOUNDARIES = "Incorrect values of boundaries has entered.";

        private const byte NUMBER_OF_ARGS = 3;

        private const string MOSKOW_MARKER = "Moskow";
        private const string PITER_MARKER = "Piter";

        /// <summary>
        /// Displays user guide from resource file
        /// </summary>
        /// <exception cref="FileNotFoundException">User Guide file losted/</exception>
        public void DisplayGuide()
        {
            string path = Directory.GetCurrentDirectory() + "\\Resources\\LuckyTicketGuide.txt";
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
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(WARNING_LINE);
                Console.WriteLine(USER_GUIDE_LOSTED);
                Console.WriteLine(ex.Message);
                Console.WriteLine(WARNING_LINE);
            }

            Console.WriteLine("Press Enter...");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Runs application
        /// </summary>
        public void Run()
        {
            this.DisplayGuide();

            string[] args = this.GetInput();

            try
            {
                string key = string.Empty;
                this.ReadAlgorithmMarker(args[0], out key);

                int result = 0;

                switch (key)
                {
                    case PITER_MARKER:
                        result = this.UsePiterAlgorithm(args[1], args[2]);
                        this.DisplayResult(result);
                        break;
                    case MOSKOW_MARKER:
                        result = this.UseMoskowAlgorithm(args[1], args[2]);
                        this.DisplayResult(result);
                        break;
                    default:
                        throw new FormatException(INCORRECT_MARKER);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(WARNING_LINE);
                Console.WriteLine(ex.Message);
                Console.WriteLine(WARNING_LINE);
                this.DisplayGuide();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(WARNING_LINE);
                Console.WriteLine(ex.Message);
                Console.WriteLine(WARNING_LINE);
                this.DisplayGuide();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(WARNING_LINE);
                Console.WriteLine(ex.Message);
                Console.WriteLine(WARNING_LINE);
                this.DisplayGuide();
            }
        }

        private string[] GetInput()
        {
            string[] args = new string[NUMBER_OF_ARGS];

            Console.WriteLine(SEPARATE_LINE);
            Console.WriteLine("Enter path to file with algorithm marker:");
            args[0] = Console.ReadLine();
            Console.WriteLine(SEPARATE_LINE);
            Console.WriteLine("Enter ticket number to start from:");
            args[1] = Console.ReadLine();
            Console.WriteLine(SEPARATE_LINE);
            Console.WriteLine("Enter ticket number to finish on:");
            args[2] = Console.ReadLine();
            Console.WriteLine(SEPARATE_LINE);

            return args;
        }

        private void ReadAlgorithmMarker(string path, out string marker)
        {
            marker = string.Empty;

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    marker = reader.ReadLine();
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(FILE_WITH_MARKER_LOSTED);
            }
        }

        private int UsePiterAlgorithm(string leftBound, string rightBound)
        {
            int leftTicket;
            int rightTicket;
            bool isParsed = false;
            int result = 0;

            isParsed = int.TryParse(leftBound, out leftTicket);

            if (!isParsed)
            {
                throw new FormatException(INCORRECT_BOUNDARIES);
            }

            isParsed = int.TryParse(rightBound, out rightTicket);

            if (!isParsed)
            {
                throw new FormatException(INCORRECT_BOUNDARIES);
            }

            try
            {
                SixDigitTicketGenerator generator = SixDigitTicketGenerator.Create(leftTicket, rightTicket);
                PiterLuckCounter counter = new PiterLuckCounter(generator);
                result = counter.CountLuckyTickets();
            }
            catch (ArgumentException)
            {
                throw;
            }

            return result;
        }

        private int UseMoskowAlgorithm(string leftBound, string rightBound)
        {
            int leftTicket;
            int rightTicket;
            bool isParsed = false;
            int result = 0;

            isParsed = int.TryParse(leftBound, out leftTicket);

            if (!isParsed)
            {
                throw new FormatException(INCORRECT_BOUNDARIES);
            }

            isParsed = int.TryParse(rightBound, out rightTicket);

            if (!isParsed)
            {
                throw new FormatException(INCORRECT_BOUNDARIES);
            }

            try
            {
                SixDigitTicketGenerator generator = SixDigitTicketGenerator.Create(leftTicket, rightTicket);
                MoskowLuckCounter counter = new MoskowLuckCounter(generator);
                result = counter.CountLuckyTickets();
            }
            catch (ArgumentException)
            {
                throw;
            }

            return result;
        }

        private void DisplayResult(int result)
        {
            Console.WriteLine($"{result} lucky tickets was founded.");
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
