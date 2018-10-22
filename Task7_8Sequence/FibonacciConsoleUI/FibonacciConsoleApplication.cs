// <copyright file="FibonacciConsoleApplication.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace FibonacciConsoleUI
{
    using System;
    using SequencesLib;

    /// <summary>
    /// Reprecrnts Application which display Febonacci numbers in some range
    /// </summary>
    public class FibonacciConsoleApplication
    {
        private static readonly string SEPARATE_LINE = new string('=', 60);
        private static readonly string WARNING_LINE = new string('!', 60);
        private const string FORMAT_EXCEPTION_MESSAGE = "Incorrect input. Impossible use input parameters to overview sequence.";
        private const byte ARGS_LIMIT = 2;

        /// <summary>
        /// Receive console input arguments and runs application
        /// </summary>
        /// <param name="args">Console input arguments</param>
        public void Run(string[] args)
        {
            try
            {
                if (args.Length == ARGS_LIMIT)
                {
                    int leftBound = 0;
                    int rightBound = 0;
                    bool isParsed = false;
                    isParsed = int.TryParse(args[0], out leftBound);

                    if (!isParsed)
                    {
                        throw new FormatException(FORMAT_EXCEPTION_MESSAGE);
                    }

                    isParsed = int.TryParse(args[1], out rightBound);

                    if (!isParsed)
                    {
                        throw new FormatException(FORMAT_EXCEPTION_MESSAGE);
                    }

                    FibonacciSequance sequance = FibonacciSequance.Create(leftBound, rightBound);
                    this.DisplaySequence(sequance);

                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Press double-enter to exit, please...");
                    Console.ReadLine();
                }
                else
                {
                    throw new FormatException("Application needs only two input arguments");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(WARNING_LINE);
                Console.WriteLine(ex.Message);
                Console.WriteLine(WARNING_LINE);
                this.DisplayHelpMessage();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(WARNING_LINE);
                Console.WriteLine(ex.Message);
                Console.WriteLine(WARNING_LINE);
                this.DisplayHelpMessage();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(WARNING_LINE);
                Console.WriteLine(ex.Message);
                Console.WriteLine(WARNING_LINE);
                this.DisplayHelpMessage();
            }
        }

        private void DisplaySequence(FibonacciSequance sequance)
        {
            foreach (int element in sequance.GetSequence())
            {
                Console.Write(element + " ");
            }
        }

        private void DisplayHelpMessage()
        {
            Console.WriteLine(SEPARATE_LINE);
            Console.WriteLine("Fibonacci Sequence Application");
            Console.WriteLine(SEPARATE_LINE);
            Console.WriteLine("Print right and left bound");
            Console.WriteLine("to overview Fibonacci numbers in this range");
            Console.Write("Print format: FibonacciConsoleUI ");
            Console.Write("[left bound] [right bound]");
            Console.Write(Environment.NewLine);
            Console.WriteLine(SEPARATE_LINE);
            Console.Write("Press Enter to continue");
            Console.ReadLine();
        }
    }
}
