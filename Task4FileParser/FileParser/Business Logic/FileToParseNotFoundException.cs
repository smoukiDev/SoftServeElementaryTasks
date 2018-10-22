// <copyright file="FileToParseNotFoundException.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace FileParser
{
    using System;

    /// <summary>
    /// Represents situation when file for parsing is not found
    /// </summary>
    public class FileToParseNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileToParseNotFoundException"/> class.
        /// </summary>
        public FileToParseNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileToParseNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Exception message</param>
        public FileToParseNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileToParseNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="inner">Inner exception</param>
        public FileToParseNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
