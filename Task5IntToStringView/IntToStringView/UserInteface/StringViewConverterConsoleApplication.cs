// <copyright file="StringViewConverterConsoleApplication.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace IntToStringView.UserInteface
{
    using System;
    using System.IO;
    using IntToStringView.BusinessLogic;

    /// <summary>
    /// Reprecents console application
    /// for convetation integer number
    /// to word representaion
    /// </summary>
    public class StringViewConverterConsoleApplication
    {
        private static readonly string SEPARATE_LINE = new string('=', 60);
        private static readonly string WARNING_LINE = new string('!', 60);

        private const string USER_GUIDE_LOSTED = "User Guide not found.";

        /// <summary>
        /// Runs application
        /// </summary>
        /// <param name="args">Console input arguments</param>
        public void Run(string[] args)
        {

            try
            {
                if (args.Length == 1)
                {
                    long convertedValue;
                    bool isParse = long.TryParse(args[0], out convertedValue);

                    if (!isParse)
                    {
                        throw new FormatException("Invalid console input");
                    }

                    Console.WriteLine(convertedValue.ToStringView());

                    Console.WriteLine("Press enter to exit, please...");
                    Console.ReadLine();
                }
                else
                {
                    this.DisplayGuide();
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(WARNING_LINE);
                Console.WriteLine(ex.Message);
                Console.WriteLine(WARNING_LINE);
                this.DisplayGuide();
            }
        }

        /// <summary>
        /// Displays user guide from resource file
        /// </summary>
        /// <exception cref="FileNotFoundException">User Guide file losted/</exception>
        public void DisplayGuide()
        {
            string path = Directory.GetCurrentDirectory() + "\\Resources\\UserGuide.txt";
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
    }
}
