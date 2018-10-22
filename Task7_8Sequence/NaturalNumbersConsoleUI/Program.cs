// <copyright file="Program.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace NaturalNumbersConsoleUI
{
    using System;

    /// <summary>
    /// Contains method which is entery point to application
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Provides Entery point to application
        /// </summary>
        /// <param name="args">Console input arguments</param>
        private static void Main(string[] args)
        {
            NaturalNumbersConsoleApplication application = new NaturalNumbersConsoleApplication();
            application.Run(args);
            Console.ReadLine();
        }
    }
}
