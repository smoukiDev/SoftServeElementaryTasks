using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    public class ZeroReplaceException : Exception
    {
        public ZeroReplaceException()
        {
        }

        public ZeroReplaceException(string message)
            : base(message)
        {
        }

        public ZeroReplaceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
