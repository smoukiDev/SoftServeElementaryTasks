// <copyright file="StreamParser.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace FileParser
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    class StreamParser : TextParser, IDisposable
    {
        public string FilePath { get; private set; }

        public string TempFilePath { get; private set; }

        private StreamReader textReader;
        private StreamWriter textWriter;

        public bool OverwriteMode { get; private set; }

        public StreamParser(string filePath, string search)
        {
            this.FilePath = filePath;
            this.SearchValue = search;
            this.ReplaceValue = null;
            this.OverwriteMode = false;
            this.TempFilePath = null;
            this.textReader = null;
            this.textWriter = null;

        }

        public StreamParser(string filePath, string search, string pattern)
        {
            this.FilePath = filePath;
            this.SearchValue = search;
            this.ReplaceValue = pattern;
            this.OverwriteMode = false;
            this.TempFilePath = null;
            this.textReader = null;
            this.textWriter = null;
        }

        public StreamParser(string filePath, string search, string pattern, bool mode)
        {
            this.FilePath = filePath;
            this.SearchValue = search;
            this.ReplaceValue = pattern;
            this.OverwriteMode = mode;
            this.TempFilePath = null;
            this.textReader = null;
            this.textWriter = null;
        }

        private void InitializeStream()
        {
            try
            {
                if (new FileInfo(this.FilePath).Length == 0)
                {
                    string message = "File is empty";
                    throw new FileIsEmptyException(message);
                }
            }
            catch (FileNotFoundException ex)
            {
                string message = "Path or file name is incorect.";
                throw new FileToParseNotFoundException(message + Environment.NewLine + ex.Message, ex);
            }

            this.TempFilePath = Path.GetTempFileName();
            this.textReader = new StreamReader(this.FilePath);
            this.textWriter = new StreamWriter(this.TempFilePath);
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

        public override int CountEnteries()
        {
            int result = 0;

            this.ReleaseStream();
            this.InitializeStream();

            string buffer;
            while ((buffer = this.textReader.ReadLine()) != null)
            {
                result += Regex.Matches(buffer, this.SearchValue).Count;
            }

            return result;
        }

        public override int ReplaceEnteries()
        {
            if (this.ReplaceValue == null)
            {
                string message = "String to replace on hasn't specified";
                throw new NoReplacePatternException(message);
            }

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
                string tempFileMovePath = Path.GetDirectoryName(this.FilePath) + "\\"
                                        + Path.GetFileNameWithoutExtension(this.FilePath) + ".txt";
                File.Delete(this.FilePath);
                File.Move(this.TempFilePath, tempFileMovePath);
            }
            else
            {
                string tempFileMovePath = Path.GetDirectoryName(this.FilePath) + "\\"
                                        + Path.GetFileNameWithoutExtension(this.TempFilePath) + ".txt";
                File.Move(this.TempFilePath, tempFileMovePath);
            }

            if (result == 0)
            {
                string message = "No matches have been detected.";
                throw new ZeroReplaceException(message);
            }

            return result;
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

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
                    this.TempFilePath = null;
                }

                // release unmanaged resources
                this.ReleaseStream();
                this.disposed = true;
            }
        }

        // Destructor
        ~StreamParser()
        {
            Dispose(false);
        }
    }
}
