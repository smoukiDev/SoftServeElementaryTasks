using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    class FileIsEmptyException : Exception
    {
        public FileIsEmptyException()
        {
        }

        public FileIsEmptyException(string message)
            : base(message)
        {
        }

        public FileIsEmptyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
