// <copyright file="FileParserConsoleApplication.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace FileParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class FileParserConsoleApplication
    {
        public void Run(string[] args)
        {
            switch ((InputArgs)args.Length)
            {
            }
        }

        /// <summary>
        /// Specifies variants of input arguments
        /// </summary>
        public enum InputArgs
        {
            /// <summary>
            /// Application gets no arguments
            /// </summary>
            NoArgs,

            /// <summary>
            /// Application gets two arguments
            /// </summary>
            TwoArgs = 2,

            /// <summary>
            /// Application gets three arguments
            /// </summary>
            ThreeArgs,

            /// <summary>
            /// Application gets four arguments
            /// </summary>
            FourArgs
        }
    }
}
