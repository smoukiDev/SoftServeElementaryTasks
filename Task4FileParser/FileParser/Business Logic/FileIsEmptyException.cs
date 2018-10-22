// <copyright file="FileIsEmptyException.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace FileParser
{
    using System;

    /// <summary>
    /// Represents situations when file for parsing is empty
    /// </summary>
    public class FileIsEmptyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileIsEmptyException"/> class.
        /// </summary>
        public FileIsEmptyException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileIsEmptyException"/> class.
        /// </summary>
        /// <param name="message">Exception message</param>
        public FileIsEmptyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileIsEmptyException"/> class.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="inner">Inner exception</param>
        public FileIsEmptyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
