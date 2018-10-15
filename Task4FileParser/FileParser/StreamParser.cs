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
        private string filePath;

        public bool OverwriteMode { get; set; }

        public StreamParser(string filePath, string search)
        {
            this.filePath = filePath;
            this.SearchValue = search;
            this.ReplaceValue = null;
            this.OverwriteMode = false;
        }

        public StreamParser(string filePath, string search, string pattern)
        {
            this.filePath = filePath;
            this.SearchValue = search;
            this.ReplaceValue = pattern;
            this.OverwriteMode = false;
        }

        public StreamParser(string filePath, string search, string pattern, bool mode)
        {
            this.filePath = filePath;
            this.SearchValue = search;
            this.ReplaceValue = pattern;
            this.OverwriteMode = mode;
        }

        public override int CountEnteries()
        {
            int result = 0;
            try
            {
                using (StreamReader streamReader = new StreamReader(this.filePath))
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
                // Create Custom Exception
                throw new Exception();
            }

            int result = 0;

            // Replace?
            string tempFilePath = Path.GetTempFileName();

            try
            {

                using (StreamReader streamReader = new StreamReader(this.filePath))
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
                    string tempFileMovePath = Path.GetDirectoryName(this.filePath) + "\\"
                                            + Path.GetFileNameWithoutExtension(this.filePath) + ".txt";
                    File.Delete(this.filePath);
                    File.Move(tempFilePath, tempFileMovePath);
                }
                else
                {
                    string tempFileMovePath = Path.GetDirectoryName(this.filePath) + "\\"
                                            + Path.GetFileNameWithoutExtension(tempFilePath) + ".txt";
                    File.Move(tempFilePath, tempFileMovePath);
                }

                if (result == 0)
                {
                    // specify
                    throw new Exception();
                }

                return result;
            }
            catch (Exception ex)
            {
                // specify
                throw new Exception();
            }
        }
    }
}
