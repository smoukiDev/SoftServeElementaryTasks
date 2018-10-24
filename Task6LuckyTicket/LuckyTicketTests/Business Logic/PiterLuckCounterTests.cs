// <copyright file="PiterLuckCounterTests.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace LuckyTicket.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PiterLuckCounterTests
    {
        [TestMethod]
        [DataRow(522456, 6)]
        [DataRow(824208, 6)]
        [DataRow(348007, 6)]
        [DataRow(801911, 6)]
        public void IsLucky_ReturnsTrue(int number, int size)
        {
            // Arrange
            int downBound = 000001;
            int upBound = 000003;
            SixDigitTicketGenerator generator = SixDigitTicketGenerator.Create(downBound, upBound);
            Ticket singleTicket = Ticket.Create(number, size);
            PiterLuckCounter counter = new PiterLuckCounter(generator);

            bool expected = true;
            bool actual;

            // Act
            actual = counter.IsLucky(singleTicket);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(315317, 6)]
        [DataRow(195998, 6)]
        public void IsLucky_ReturnsFalse(int number, int size)
        {

            // Arrange
            int downBound = 000001;
            int upBound = 000003;
            SixDigitTicketGenerator generator = SixDigitTicketGenerator.Create(downBound, upBound);
            Ticket singleTicket = Ticket.Create(number, size);
            PiterLuckCounter counter = new PiterLuckCounter(generator);

            bool expected = false;
            bool actual;

            // Act
            actual = counter.IsLucky(singleTicket);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountLuckyTickets_ReturnCorrectValue()
        {
            // Arrange
            int downBound = 348007;
            int upBound = 348009;
            SixDigitTicketGenerator generator = SixDigitTicketGenerator.Create(downBound, upBound);
            PiterLuckCounter counter = new PiterLuckCounter(generator);

            int expected = 1;
            int actual;

            // Act
            actual = counter.CountLuckyTickets();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountLuckyTickets_ReturnsZero()
        {
            // Arrange
            int downBound = 522457;
            int upBound = 522460;
            SixDigitTicketGenerator generator = SixDigitTicketGenerator.Create(downBound, upBound);
            PiterLuckCounter counter = new PiterLuckCounter(generator);

            int expected = 0;
            int actual;

            // Act
            actual = counter.CountLuckyTickets();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}