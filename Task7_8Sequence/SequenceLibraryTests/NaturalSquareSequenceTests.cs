// <copyright file="NaturalSquareSequenceTests.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequencesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequencesLib.Tests
{
    [TestClass]
    public class NaturalSquareSequenceTests
    {
        [TestMethod]
        [DataRow(-10)]
        [DataRow(0)]
        public void Create_ThrowsArgumentException(int limit)
        {
            // Arrange
            NaturalSquareSequence sequence;
            // Act

            // Arrange
            Assert.ThrowsException<ArgumentException>(() => sequence = NaturalSquareSequence.Create(limit));
        }

        [TestMethod]
        [DataRow(4)]
        [DataRow(25)]
        [DataRow(100)]
        [DataRow(2147483647)]
        public void Create_ReturnInstanceOfNaturalSquareSequence(int limit)
        {
            /// Arrange
            NaturalSquareSequence sequence;

            /// Act 
            try
            {
                sequence = NaturalSquareSequence.Create((int)limit);
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
        [DataRow(16, new int[] { 1, 2, 3 })]
        [DataRow(36, new int[] { 1, 2, 3, 4, 5})]
        [DataRow(100, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void GetSequence_GetRangeOfSequenceSuccessfully(int limit, int[] elements)
        {
            //Arrange
            NaturalSquareSequence sequence = NaturalSquareSequence.Create(limit);
            List<int> expected = new List<int>(elements);
            List<int> actual = new List<int>(elements.Length);

            // Act
            foreach (int element in sequence.GetSequence())
            {
                actual.Add(element);
            }

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}