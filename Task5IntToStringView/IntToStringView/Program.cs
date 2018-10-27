// <copyright file="Program.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace IntToStringView
{
    using IntToStringView.UserInteface;

    /// <summary>
    /// Serves as entery point to application
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Provides entery point to application
        /// </summary>
        /// <param name="args">Console input arguments</param>
        private static void Main(string[] args)
        {
            StringViewConverterConsoleApplication application;
            application = new StringViewConverterConsoleApplication();
            application.Run(args);
        }
    }
}
