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

    class StreamParser : TextParser
    {
        public string FilePath{ get; private set; }

        public bool OverwriteMode { get; set; }

        public StreamParser(string filePath, string search)
        {
            this.FilePath = filePath;
            this.SearchValue = search;
            this.ReplaceValue = null;
            this.OverwriteMode = false;
        }

        public StreamParser(string filePath, string search, string pattern)
        {
            this.FilePath = filePath;
            this.SearchValue = search;
            this.ReplaceValue = pattern;
            this.OverwriteMode = false;
        }

        public StreamParser(string filePath, string search, string pattern, bool mode)
        {
            this.FilePath = filePath;
            this.SearchValue = search;
            this.ReplaceValue = pattern;
            this.OverwriteMode = mode;
        }

        public override int CountEnteries()
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

            int result = 0;
            try
            {
                using (StreamReader streamReader = new StreamReader(this.FilePath))
                {
                    string buffer;
                    while ((buffer = streamReader.ReadLine()) != null)
                    {
                        result += Regex.Matches(buffer, this.SearchValue).Count;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                // Specify
                throw new Exception();
            }

        }

        public override int ReplaceEnteries()
        {
            if (this.ReplaceValue == null)
            {
                string message = "String to replace on hasn't specified";
                throw new NoReplacePatternException(message);
            }

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

            int result = 0;

            // Replace?
            try
            {
                string tempFilePath = Path.GetTempFileName();

                using (StreamReader streamReader = new StreamReader(this.FilePath))
                {
                    using (StreamWriter streamWriter = new StreamWriter(tempFilePath))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            string buffer = streamReader.ReadLine();
                            int subResult = Regex.Matches(buffer, this.SearchValue).Count;
                            Regex analyser = new Regex(this.SearchValue);
                            streamWriter.WriteLine(analyser.Replace(buffer, this.ReplaceValue));
                            result += subResult;
                        }
                    }
                }

                if (this.OverwriteMode)
                {
                    string tempFileMovePath = Path.GetDirectoryName(this.FilePath) + "\\"
                                            + Path.GetFileNameWithoutExtension(this.FilePath) + ".txt";
                    File.Delete(this.FilePath);
                    File.Move(tempFilePath, tempFileMovePath);
                }
                else
                {
                    string tempFileMovePath = Path.GetDirectoryName(this.FilePath) + "\\"
                                            + Path.GetFileNameWithoutExtension(tempFilePath) + ".txt";
                    File.Move(tempFilePath, tempFileMovePath);
                }

                if (result == 0)
                {
                    string message = "No matches have been detected.";
                    throw new ZeroReplaceException(message);
                }

                return result;
            }
            catch (Exception ex)
            {
                // StreamReader Exceptions
                string message = "Path or file name is incorect.";
                throw new FileToParseNotFoundException(message + Environment.NewLine + ex.Message, ex);
            }
        }

    }
}
