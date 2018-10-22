// <copyright file="TextFileSimpleReplacementParser.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace FileParser
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represents functionality of replacement strings in text file
    /// </summary>
    public class TextFileSimpleReplacementParser : IParse, IDisposable
    {
        private const string FILE_EMPTY_MESSAGE = "File is empty";
        private const string FILE_NOT_FOUND_MESSAGE = "Path or file name is incorect.";

        private StreamReader textReader;
        private StreamWriter textWriter;
        private string tempFilePath;

        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileSimpleReplacementParser"/> class.
        /// </summary>
        /// <param name="filePath">
        /// Path to target parsing text file
        /// </param>
        /// <param name="search">String to replace</param>
        /// <param name="pattern">String replacer</param>
        public TextFileSimpleReplacementParser(string filePath, string search, string pattern)
            : this(filePath, search, pattern, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileSimpleReplacementParser"/> class.
        /// </summary>
        /// <param name="filePath">
        /// Path to target parsing text file
        /// </param>
        /// <param name="search">String to replace</param>
        /// <param name="pattern">String replacer</param>
        /// <param name="mode">Overwrite original file - true, false - make copy with changes</param>
        public TextFileSimpleReplacementParser(string filePath, string search, string pattern, bool mode)
        {
            this.FilePath = filePath;
            this.SearchValue = search;
            this.ReplaceValue = pattern;
            this.OverwriteMode = mode;
            this.tempFilePath = null;
            this.textReader = null;
            this.textWriter = null;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="TextFileSimpleReplacementParser"/> class.
        /// </summary>
        ~TextFileSimpleReplacementParser()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets or sets string to replace
        /// </summary>
        public string SearchValue { get; set; }

        /// <summary>
        /// Gets or sets string to replace on
        /// </summary>
        public string ReplaceValue { get; set; }

        /// <summary>
        /// Gets path of target parsing file
        /// </summary>
        public string FilePath
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets path of last copy of target file with replacements
        /// </summary>
        public string FileCopy
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether replacements are written 
        /// in original file or in copy file
        /// </summary>
        public bool OverwriteMode
        {
            get;
            private set;
        }

        /// <summary>
        /// Perform replacement of strings in text file.
        /// Replaces strings are equal SearchValue on ReplaceValue
        /// </summary>
        /// <returns>Number of successful replacements</returns>
        public int Parse()
        {
            int result = 0;

            this.InitializeStream();

            while (!this.textReader.EndOfStream)
            {
                string buffer = this.textReader.ReadLine();
                int subResult = Regex.Matches(buffer, this.SearchValue).Count;
                Regex analyser = new Regex(this.SearchValue);
                this.textWriter.WriteLine(analyser.Replace(buffer, this.ReplaceValue));
                result += subResult;
            }

            this.ReleaseStream();

            if (this.OverwriteMode)
            {
                this.FileCopy = Path.GetDirectoryName(this.FilePath) + "\\"
                                        + Path.GetFileNameWithoutExtension(this.FilePath) + ".txt";
                File.Delete(this.FilePath);
                File.Move(this.tempFilePath, this.FileCopy);
            }
            else
            {
                this.FileCopy = Path.GetDirectoryName(this.FilePath) + "\\"
                                        + Path.GetFileNameWithoutExtension(this.tempFilePath) + ".txt";
                File.Move(this.tempFilePath, this.FileCopy);
            }

            return result;
        }

        /// <summary>
        /// Disposes all resources of instanse <see cref="TextFileSimpleReplacementParser"/>
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
                    this.ReplaceValue = null;
                    this.tempFilePath = null;
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

            this.tempFilePath = Path.GetTempFileName();
            this.textReader = new StreamReader(this.FilePath);
            this.textWriter = new StreamWriter(this.tempFilePath);
        }

        private void ReleaseStream()
        {
            if (this.textReader != null)
            {
                this.textReader.Close();
                this.textReader = null;
            }

            if (this.textWriter != null)
            {
                this.textWriter.Close();
                this.textWriter = null;
            }
        }
    }
}
