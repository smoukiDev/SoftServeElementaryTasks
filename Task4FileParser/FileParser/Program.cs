// <copyright file="Program.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace FileParser
{
    /// <summary>
    /// Contains application entery point
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Provides entery point to applications
        /// </summary>
        /// <param name="args">Console input arguments</param>
        private static void Main(string[] args)
        {
            FileParserConsoleApplication application = new FileParserConsoleApplication();
            application.Run(args);
        }
    }
}
