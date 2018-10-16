using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    class NoReplacePatternException : Exception
    {
        public NoReplacePatternException()
        {
        }

        public NoReplacePatternException(string message)
            : base(message)
        {
        }

        public NoReplacePatternException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
