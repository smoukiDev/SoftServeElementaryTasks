// <copyright file="EnvelopConsoleApplication.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace EnvelopEnclosure.UserInterface
{
    using System;
    using System.Collections;

    /// <summary>
    /// Represent application comparing envelops
    /// </summary>
    public class EnvelopConsoleApplication
    {
        private static readonly string SEPARATE_LINE = new string('=', 60);
        private static readonly string WARNING_LINE = new string('!', 60);
        private const string ARG_EXCEPTION = "Number of argument greater than 4.";
        private static readonly string[] CONFIRM_KEY = { "Y", "YES" };
        private const int NUMBER_OF_ARGS = 4;

        /// <summary>
        /// Runs Application
        /// </summary>
        public void Run()
        {
            this.DisplayHelpMessage();

            string key = null;
            do
            {
                try
                {
                    Console.Clear();
                    double[] arguments = (double[])this.ConvertInput(this.GetInput());
                    this.PrintResult(this.CompareEnvelops(arguments));
                    Console.WriteLine(SEPARATE_LINE);
                    Console.Write("Y/Yes - next session. ");
                    Console.Write("Other - for exit: ");
                    key = Console.ReadLine().ToUpper();
                    Console.WriteLine(SEPARATE_LINE);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(WARNING_LINE);
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(WARNING_LINE);
                    this.DisplayHelpMessage();
                    key = "Y";
                    continue;
                }
            }
            while (key == CONFIRM_KEY[0] || key == CONFIRM_KEY[1]);
        }

        private void DisplayHelpMessage()
        {
            Console.WriteLine(SEPARATE_LINE);
            Console.WriteLine("Welcome to EnvelopEnclosure Application");
            Console.WriteLine(SEPARATE_LINE);
            Console.WriteLine("Print information about the envelop sides to compare them");
            Console.WriteLine("Print Y or YES to new session of comparison");
            Console.WriteLine("Other input cause exit from application");
            Console.WriteLine(SEPARATE_LINE);
            Console.Write("Press Enter to continue");
            Console.ReadLine();
            Console.Clear();
        }

        private string[] GetInput()
        {
            string[] arguments = new string[NUMBER_OF_ARGS];

            Console.Write("Please enter envelops sides...");
            Console.Write(Environment.NewLine);
            Console.Write("Envelope One - Side One: ");
            arguments[0] = Console.ReadLine();
            Console.Write("Envelope One - Side Two: ");
            arguments[1] = Console.ReadLine();
            Console.Write("Envelope Two - Side One: ");
            arguments[2] = Console.ReadLine();
            Console.Write("Envelope Two - Side Two: ");
            arguments[3] = Console.ReadLine();

            return arguments;
        }

        private ICollection ConvertInput(string[] inputArguments)
        {
            if (inputArguments.Length != 4)
            {
                throw new ArgumentException(ARG_EXCEPTION);
            }

            double[] arguments = new double[4];
            try
            {
                arguments[0] = double.Parse(inputArguments[0]);
                arguments[1] = double.Parse(inputArguments[1]);
                arguments[2] = double.Parse(inputArguments[2]);
                arguments[3] = double.Parse(inputArguments[3]);
            }
            catch (Exception)
            {
                throw new ArgumentException("Incorrect sides value has been entered");
            }

            return arguments;
        }

        private string CompareEnvelops(double[] arguments)
        {
            if (arguments.Length != 4)
            {
                throw new ArgumentException(ARG_EXCEPTION);
            }

            Envelop one = Envelop.Create(arguments[0], arguments[1]);
            Envelop two = Envelop.Create(arguments[2], arguments[3]);

            string resultMessage = "Envelops are equal and cannot be enclosed";

            if (one > two)
            {
                resultMessage = "Second envelop can be enclosed in first";
            }
            else
            if (one < two)
            {
                resultMessage = "First envelop can be enclosed in second";
            }

            return resultMessage;
        }

        private void PrintResult(string result)
        {
            Console.WriteLine(SEPARATE_LINE);
            Console.WriteLine(result);
            Console.WriteLine(SEPARATE_LINE);
        }
    }
}
