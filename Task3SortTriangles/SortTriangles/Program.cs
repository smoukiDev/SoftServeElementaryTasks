using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTriangles
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Triangle a = new Triangle("tini", null, 3.0, 4.0, 5.0);
                Console.WriteLine(a.IsExist());
                Console.WriteLine(a.Name);
                Console.WriteLine(a[0]);
                Console.WriteLine(a[1]);
                Console.WriteLine(a[2]);
                Console.WriteLine(a[3]);
                Console.WriteLine(a.CalculatePerimeter());
                Console.WriteLine(a.CalculateSquare());
                Console.WriteLine(a.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
