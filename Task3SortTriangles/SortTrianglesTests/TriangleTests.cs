using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortTriangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTriangles.Tests
{
    [TestClass]
    public class TriangleTests
    {

        [DataTestMethod]
        [DataRow(-3, 4, 5)]
        [DataRow(3, -4, 5)]
        [DataRow(3, 4, -5)]
        [DataRow(-3, -4, 5)]
        [DataRow(3, -4, -5)]
        [DataRow(-3, 4, -5)]
        [DataRow(-3, -4, -5)]
        [DataRow(0, 0, 0)]
        [DataRow(1, 2, 28)]
        public void CalculateSquare_ThrowArgumentException(double a, double b, double c)
        {
            /// Arrange
            Triangle testTriangle = new Triangle("testTriangle", "sm", a, b, c);

            /// Act                     

            /// Assert 
            Assert.ThrowsException<ArgumentException>(() => testTriangle.CalculatePerimeter());
        }

        [DataTestMethod]
        [DataRow(3, 4, 5, 6)]
        [DataRow(3.75, 4.75, 5.75, 8.86)]
        [DataRow(4, 4, 7, 6.78)]
        [DataRow(4.75, 4.75, 7.75, 10.65)]
        [DataRow(7, 7, 7, 21.22)]
        [DataRow(7.75, 7.75, 7.75, 26.01)]
        [DataRow(3, 6, 6.5, 8.97)]
        public void CalculateSquare_ReturnSquareCorrectly(double a, double b, double c, double s)
        {
            /// Arrange
            Triangle testTriangle = new Triangle("testTriangle", "sm", a, b, c);
            double expected = s;
            
            /// Act                     
            double actual = testTriangle.CalculateSquare();
            
            /// Assert 
            Assert.AreEqual(expected, Math.Round(actual,2));
        }
    }
}