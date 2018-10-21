// <copyright file="Program.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace GameBoard
{
    using GameBoard.User_Interface;

    /// <summary>
    /// Provides entery point to application
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Serves as entery point to application
        /// </summary>
        /// <param name="args">Console input arguments</param>
        private static void Main(string[] args)
        {
            GameBoardConsoleApplication application = new GameBoardConsoleApplication();
            application.Run(args);
        }
    }
}
