using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    class FileToParseNotFoundException : Exception
    {
        public FileToParseNotFoundException()
        {
        }

        public FileToParseNotFoundException(string message)
            : base(message)
        {
        }

        public FileToParseNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
