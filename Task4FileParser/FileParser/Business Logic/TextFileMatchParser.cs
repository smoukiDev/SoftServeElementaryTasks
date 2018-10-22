// <copyright file="TextFileMatchParser.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace FileParser
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represents functionality to find string matches in the text file
    /// </summary>
    public class TextFileMatchParser : IParse, IDisposable
    {
        private const string FILE_EMPTY_MESSAGE = "File is empty.";
        private const string FILE_NOT_FOUND_MESSAGE = "Path or file name is incorect.";

        private StreamReader textReader;

        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileMatchParser"/> class.
        /// </summary>
        /// <param name="filePath">
        /// Path to target parsing text file
        /// </param>
        /// <param name="search">String to search</param>
        public TextFileMatchParser(string filePath, string search)
        {
            this.FilePath = filePath;
            this.SearchValue = search;
            this.textReader = null;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="TextFileMatchParser"/> class.
        /// </summary>
        ~TextFileMatchParser()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets or sets string to find in the file
        /// </summary>
        public string SearchValue { get; set; }

        /// <summary>
        /// Gets path of target parsing file
        /// </summary>
        public string FilePath
        {
            get;
            private set;
        }

        /// <summary>
        /// Searchs how many times SearchValue is found in the file
        /// </summary>
        /// <returns>Number of matches with SearchValue</returns>
        /// <exception cref="FileToParseNotFoundException">
        /// Path or file name is incorect.
        /// </exception>
        /// <exception cref="FileIsEmptyException">
        /// File is empty
        /// </exception>
        public int Parse()
        {
            int result = 0;

            this.InitializeStream();

            string buffer;
            while ((buffer = this.textReader.ReadLine()) != null)
            {
                result += Regex.Matches(buffer, this.SearchValue).Count;
            }

            this.ReleaseStream();

            return result;
        }

        /// <summary>
        /// Disposes all resources of instanse <see cref="TextFileMatchParser"/>
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Realize logic of cleaning up
        /// </summary>
        /// <param name="disposing">Flag wheter object has disposed or hasn't yet</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // release managed resources
                    this.FilePath = null;
                    this.SearchValue = null;
                }

                // release unmanaged resources
                this.ReleaseStream();
                this.disposed = true;
            }
        }

        private void InitializeStream()
        {
            try
            {
                if (new FileInfo(this.FilePath).Length == 0)
                {
                    throw new FileIsEmptyException(FILE_EMPTY_MESSAGE);
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileToParseNotFoundException(FILE_NOT_FOUND_MESSAGE + Environment.NewLine + ex.Message, ex);
            }

            this.textReader = new StreamReader(this.FilePath);
        }

        private void ReleaseStream()
        {
            if (this.textReader != null)
            {
                this.textReader.Close();
                this.textReader = null;
            }
        }
    }
}
