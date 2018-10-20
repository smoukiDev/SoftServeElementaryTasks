using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvelopEnclosure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopEnclosure.Tests
{
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
            /// Arrange
            Envelop envelop;

            /// Act                     

            /// Assert 
            Assert.ThrowsException<ArgumentException>(() => envelop = Envelop.CreateEnvelop(sideA, sideB));
        }

        [TestMethod]
        public void CreateEnvelopTest_ReturnInstanceSuccessfully()
        {
            /// Arrange
            Envelop envelop;
            double sideA = 20.0d;
            double sideB =  5.0d;

            /// Act 
            try
            {
                envelop = Envelop.CreateEnvelop(sideA, sideB);
            }
            /// Assert 
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
            /// Arrange
            Envelop firstEnvelop = Envelop.CreateEnvelop(oneSideA, oneSideB);
            Envelop secondEnvelop = Envelop.CreateEnvelop(twoSideA, twoSideB); ;
            bool actual;
            bool expected = true;

            /// Act 
            actual = firstEnvelop > secondEnvelop ? true : false;

            /// Assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(5, 20, 40, 120)]
        [DataRow(20, 5, 40, 120)]
        public void OperatorLessThan_ReturnTrue(double oneSideA, double oneSideB, double twoSideA, double twoSideB)
        {
            /// Arrange
            Envelop firstEnvelop = Envelop.CreateEnvelop(oneSideA, oneSideB);
            Envelop secondEnvelop = Envelop.CreateEnvelop(twoSideA, twoSideB); ;
            bool actual;
            bool expected = true;

            /// Act 
            actual = firstEnvelop < secondEnvelop ? true : false;

            /// Assert 
            Assert.AreEqual(expected, actual);
        }
    }
}