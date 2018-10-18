// <copyright file="Triangle.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace SortTriangles
{
    using System;

    /// <summary>
    /// Reprecents Triangle with name and measure unit
    /// </summary>
    public class Triangle : IFigure, IComparable<Triangle>
    {
        private readonly double _sideA;
        private readonly double _sideB;
        private readonly double _sideC;

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="name">Triangle name</param>
        /// <param name="measure">Measure unit</param>
        /// <param name="sideA">Side A of triangle</param>
        /// <param name="sideB">Side B of triangle</param>
        /// <param name="sideC">Side C of triangle</param>
        public Triangle(string name, string measure, double sideA, double sideB, double sideC)
        {
            if (name == null)
            {
                Name = "Unknown";
            }
            else
            {
                Name = name;
            }

            if (sideA <= 0)
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

            this.Measure = measure ?? "sm";
        }

        /// <summary>
        /// Gets or sets measure unit
        /// </summary>
        public string Measure { get; set; }

        /// <summary>
        /// Gets or sets triangle name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets a side of triangle by indexes 0,1,2
        /// </summary>
        /// <param name="index">Index of side</param>
        /// <returns>Side of triangle</returns>
        public double this[int index]
        {
            get
            {
                if (index == 0)
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

                throw new IndexOutOfRangeException("Triangles has only three side to access");
            }
        }

        /// <summary>
        /// Indicates whether trianles exists with such sides
        /// </summary>
        /// <returns>True if triangle exist, false if it doesn't exist</returns>
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

        /// <summary>
        /// Calculates a perimeter of the trianle
        /// </summary>
        /// <returns>Perimeter of triangle</returns>
        public double CalculatePerimeter()
        {
            if (this.IsExist())
            {
                return _sideA + _sideB + _sideC;
            }

            string message = $"Imposible to build triangle "
                           + $" with sides "
                           + $"{this[0]}, {this[1]}, {this[2]}";
            throw new ArgumentException(message);
        }

        /// <summary>
        /// Calculates a square of the trianle
        /// </summary>
        /// <returns>Square of triangle</returns>
        public double CalculateSquare()
        {
            double half = this.CalculatePerimeter() / 2;
            return Math.Sqrt(half * (half - _sideA) * (half - _sideB) * (half - _sideC));
        }

        /// <summary>
        /// Returns information about name, square, measure of the triangle 
        /// </summary>
        /// <returns>String with information about name, square, measure</returns>
        public override string ToString()
        {
            return $"[Triangle {this.Name}]: "
                 + $"{this.CalculateSquare()} {this.Measure}";
        }

        /// <summary>
        /// Compares this instance of <see cref="Triangle"/> with other
        /// </summary>
        /// <param name="other"> Other instance of <see cref="Triangle"/> to compare with </param>
        /// <returns> Comparison result: 1 - this smaller than other, -1 - larger, 0 - equal </returns>
        public int CompareTo(Triangle other)
        {
            double thisSquare = this.CalculateSquare();
            double otherSquare = other.CalculateSquare();
            if (thisSquare > otherSquare)
            {
                return -1;
            }
            else if (thisSquare < otherSquare)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
