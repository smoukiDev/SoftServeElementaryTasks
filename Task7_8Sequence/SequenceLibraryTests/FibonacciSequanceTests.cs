// <copyright file="FibonacciSequenceTests.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace SequencesLib.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SequencesLib;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class FibonacciSequenceTests
    {
        [TestMethod]
        [DataRow(-10, -1)]
        [DataRow(-1, 10)]
        [DataRow(10, -1)]
        public void Create_ThrowsArgumentException(int downLimit, int uplimit)
        {
            // Arrange
            FibonacciSequance sequence;
            // Act

            // Arrange
            Assert.ThrowsException<ArgumentException>(() => sequence = FibonacciSequance.Create(downLimit, uplimit));
        }

        [TestMethod]
        [DataRow(0, 21)]
        [DataRow(12,145)]
        public void Create_ReturnInstanceOfFibonacciSequance(int downLimit, int uplimit)
        {
            /// Arrange
            FibonacciSequance sequence;

            /// Act 
            try
            {
                sequence = FibonacciSequance.Create(downLimit, uplimit);
            }
            /// Assert 
            catch (ArgumentException)
            {
                Assert.Fail();
            }
            catch (OverflowException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [DataRow(0, 13, new int[] {0, 1, 1, 2, 3, 5, 8, 13})]
        [DataRow(1, 13, new int[] {1, 1, 2, 3, 5, 8, 13 })]
        [DataRow(4, 13, new int[] {5, 8, 13 })]
        public void GetSequence_GetRangeOfSequenceSuccessfully(int downLimit, int upLimit, int[] elements)
        {
            //Arrange
            FibonacciSequance sequence = FibonacciSequance.Create(downLimit, upLimit);
            List<int> expected = new List<int>(elements);
            List<int> actual = new List<int>(elements.Length);

            // Act
            foreach (int element in sequence.GetSequence())
            {
                actual.Add((int)element);
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSequence_ThrowsOverflowException()
        {
            // Arrange            
            int downLimit = 0;
            int upLimit = int.MaxValue;
            FibonacciSequance sequence = FibonacciSequance.Create(downLimit, upLimit);
            // Act
            // Assert
            try
            {
                foreach  (int element in sequence.GetSequence())
                {

                }
                Assert.Fail();
            }
            catch(OverflowException)
            {
                
            }
        }
    }
}