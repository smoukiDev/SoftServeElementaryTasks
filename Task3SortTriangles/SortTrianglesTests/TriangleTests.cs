// <copyright file="Triangle.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace SortTriangles.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortTriangles;
    using System;

    [TestClass]
    public class TriangleTests
    {
        // TODO: Add Documentation CalculateSquare_ThrowArgumentException
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

        // TODO: Add Documentation For CalculateSquare_ReturnSquareCorrectly
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