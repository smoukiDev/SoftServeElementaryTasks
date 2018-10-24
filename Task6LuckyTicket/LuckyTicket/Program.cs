// <copyright file="Program.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace LuckyTicket
{
    using UserInterface;
    
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
            LuckyTicketsConsoleApplication application = new LuckyTicketsConsoleApplication();
            application.Run();
        }
    }
}
