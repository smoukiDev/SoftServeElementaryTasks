using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuckyTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicket.Tests
{
    [TestClass()]
    public class SixDigitTicketGeneratorTests
    {
        [TestMethod]
        [DataRow(-7, 1)]
        [DataRow(7, -1)]
        [DataRow(000100, 1000000)]
        [DataRow(000000, 000007)]
        [DataRow(000001, 000001)]
        [DataRow(999999, 999999)]
        [DataRow(999999, 999999)]
        public void Create_ThrowsArgumentException(int downLimit, int upLimit)
        {
            // Arrange
            SixDigitTicketGenerator generator;

            // Act
            // Assert
            Assert.ThrowsException<ArgumentException>(() => generator = SixDigitTicketGenerator.Create(downLimit, upLimit));
        }

        [TestMethod]
        [DataRow(000001, 999999)]
        [DataRow(100, 110)]
        public void Create_ReturnInstanceSuccessfully(int downLimit, int upLimit)
        {
            // Arrange
            SixDigitTicketGenerator generator;

            // Act
            // Assert
            try
            {
                generator = SixDigitTicketGenerator.Create(downLimit, upLimit);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [DataRow(000001, 000003, new string[] { "000001", "000002", "000003" })]
        [DataRow(999997, 999999, new string[] { "999997", "999998", "999999" })]
        [DataRow(000011, 000013, new string[] { "000011", "000012", "000013" })]
        public void GetEnumerator_ReturnTicketsCorrectly(int downLimit, int upLimit, string[] tickets)
        {
            // Arrange
            SixDigitTicketGenerator genetator;
            genetator = SixDigitTicketGenerator.Create(downLimit, upLimit);
            List<string> expected = new List<string>(tickets);
            List<string> actual = new List<string>(tickets.Length);

            // Act
            foreach (Ticket ticket in genetator)
            {
                actual.Add(ticket.TicketNumber);
            }

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}