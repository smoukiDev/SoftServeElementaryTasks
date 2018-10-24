// <copyright file="EnvelopTests.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace EnvelopEnclosure.Tests
{
    using EnvelopEnclosure;
    using Microsoft.VisualStudio.TestTools.UnitTesting;   
    using System;

    [TestClass]
    public class EnvelopTests
    {
        [TestMethod]
        [DataRow(-10, 4.5)]
        [DataRow(4.5, -10)]
        [DataRow(-4.5, -10)]
        [DataRow(0, -10)]
        [DataRow(-10, 0)]
        [DataRow(0, 0)]
        public void CreateEnvelopTest_ThrowsArgumentException(double sideA, double sideB)
        {
            // Arrange
            Envelop envelop;

            // Act                     

            // Assert 
            Assert.ThrowsException<ArgumentException>(() => envelop = Envelop.Create(sideA, sideB));
        }

        [TestMethod]
        public void CreateEnvelopTest_ReturnInstanceSuccessfully()
        {
            // Arrange
            Envelop envelop;
            double sideA = 20.0d;
            double sideB =  5.0d;

            // Act 
            // Assert
            try
            {
                envelop = Envelop.Create(sideA, sideB);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [DataRow(40, 120, 5, 20)]
        [DataRow(40, 120, 20, 5)]
        public void OperatorGreaterThan_ReturnTrue(double oneSideA, double oneSideB, double twoSideA, double twoSideB)
        {
            // Arrange
            Envelop firstEnvelop = Envelop.Create(oneSideA, oneSideB);
            Envelop secondEnvelop = Envelop.Create(twoSideA, twoSideB); ;
            bool actual;
            bool expected = true;

            // Act 
            actual = firstEnvelop > secondEnvelop ? true : false;

            // Assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(5, 20, 40, 120)]
        [DataRow(20, 5, 40, 120)]
        public void OperatorLessThan_ReturnTrue(double oneSideA, double oneSideB, double twoSideA, double twoSideB)
        {
            // Arrange
            Envelop firstEnvelop = Envelop.Create(oneSideA, oneSideB);
            Envelop secondEnvelop = Envelop.Create(twoSideA, twoSideB); ;
            bool actual;
            bool expected = true;

            // Act 
            actual = firstEnvelop < secondEnvelop ? true : false;

            // Assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(20, 20, 20, 20)]
        [DataRow(100, 100, 100, 100)]
        public void OperatorEqualTo_ReturnTrue(double oneSideA, double oneSideB, double twoSideA, double twoSideB)
        {
            // Arrange
            Envelop firstEnvelop = Envelop.Create(oneSideA, oneSideB);
            Envelop secondEnvelop = Envelop.Create(twoSideA, twoSideB); ;
            bool actual;
            bool expected = true;
            // Act 
            actual = firstEnvelop == secondEnvelop ? true : false;
            // Assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(20, 30, 20, 20)]
        [DataRow(100, 100, 50, 100)]
        public void OperatorNotEqualTo_ReturnTrue(double oneSideA, double oneSideB, double twoSideA, double twoSideB)
        {
            // Arrange
            Envelop firstEnvelop = Envelop.Create(oneSideA, oneSideB);
            Envelop secondEnvelop = Envelop.Create(twoSideA, twoSideB); ;
            bool actual;
            bool expected = true;
            // Act 
            actual = firstEnvelop != secondEnvelop ? true : false;
            // Assert 
            Assert.AreEqual(expected, actual);
        }
    }
}