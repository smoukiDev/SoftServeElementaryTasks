using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTriangles
{
    public class SideOutOfRangeException : Exception
    {
        public SideOutOfRangeException()
        {
        }

        public SideOutOfRangeException(string message)
            : base(message)
        {
        }

        public SideOutOfRangeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
