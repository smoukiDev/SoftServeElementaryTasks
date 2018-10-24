// <copyright file="Program.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace EnvelopEnclosure
{
    using EnvelopEnclosure.UserInterface;

    /// <summary>
    /// Provides appliction entery point
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            EnvelopConsoleApplication application = new EnvelopConsoleApplication();
            application.Run();
        }
    }
}
