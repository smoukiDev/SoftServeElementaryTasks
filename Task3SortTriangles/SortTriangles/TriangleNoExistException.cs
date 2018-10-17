using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTriangles
{
    public class TriangleNoExistException : Exception
    {
        public TriangleNoExistException()
        {
        }

        public TriangleNoExistException(string message)
            : base(message)
        {
        }

        public TriangleNoExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
