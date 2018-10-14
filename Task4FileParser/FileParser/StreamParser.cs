// <copyright file="StreamParser.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace FileParser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    class StreamParser : TextParser
    {
        private string filePath;

        public StreamParser(string filePath, string search)
        {
            this.filePath = filePath;
            this.SearchValue = search;
            this.ReplaceValue = null;
        }

        public override int CountEnteries()
        {
            int result = 0;
            try
            {
                using (StreamReader streamReader = new StreamReader(this.filePath))
                {
                    string buffer;
                    Regex analyser;
                    while ((buffer = streamReader.ReadLine()) != null)
                    {
                        analyser = new Regex(this.SearchValue);
                        if (analyser.IsMatch(buffer) == true)
                        {
                            result++;
                        }
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
            throw new NotImplementedException();
        }
    }
}
