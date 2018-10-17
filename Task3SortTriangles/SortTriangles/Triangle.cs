using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTriangles
{
    public class Triangle : IFigure
    {
        private static readonly string MEASURE = "sm";

        private double _sideA;
        private double _sideB;
        private double _sideC;

        public string Name { get; set; }

        public Triangle(string name, double sideA, double sideB, double sideC)
        {
            if (name == null)
            {
                Name = "Unknown";
            }
            else
            {
                Name = name;
            }

            if (sideA <=0)
            {
                _sideA = 0;
            }
            else
            {
                _sideA = sideA;
            }

            if (sideB <= 0)
            {
                _sideB = 0;
            }
            else
            {
                _sideB = sideB;
            }

            if (sideC <= 0)
            {
                _sideC = 0;
            }
            else
            {
                _sideC = sideC;
            }
        }

        public bool IsExist()
        {
            if (_sideB + _sideC > _sideA)
            {
                if (_sideA + _sideC > _sideB)
                {
                    if (_sideA + _sideB > _sideC)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public double this[int index]
        {
            get
            {
                if(index == 0)
                {
                    return _sideA;
                }

                if (index == 1)
                {
                    return _sideB;
                }

                if (index == 2)
                {
                    return _sideC;
                }

                throw new SideOutOfRangeException("Triangles has only three side to access");
            }
        }

        public double CalculatePerimeter()
        {
            if (this.IsExist())
            {
                return _sideA + _sideB + _sideC;
            }

            string message = $"Imposible to build triangle "
                           + $" with sides "
                           + $"{this[0]}, {this[1]}, {this[2]}";
            throw new TriangleNoExistException(message);
        }

        public double CalculateSquare()
        {
            double half = this.CalculatePerimeter() / 2;
            return Math.Sqrt(half * (half - _sideA) * (half - _sideB) * (half - _sideC));
        }

        public override string ToString()
        {
            return $"[Triangle {this.Name}]: "
                 + $"{this.CalculateSquare()} {MEASURE}";
        }
    }
}
