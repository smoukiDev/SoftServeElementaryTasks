// <copyright file="MoskovLuckCounterTests.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace LuckyTicket.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MoskovLuckCounterTests
    {
        [TestMethod]
        [DataRow(246525, 6)]
        [DataRow(228840, 6)]
        [DataRow(380407, 6)]
        [DataRow(811091, 6)]
        public void IsLucky_ReturnsTrue(int number, int size)
        {

            // Arrange
            int downBound = 000001;
            int upBound = 000003;
            SixDigitTicketGenerator generator = SixDigitTicketGenerator.Create(downBound, upBound);
            Ticket singleTicket = Ticket.Create(number, size);
            MoskowLuckCounter counter = new MoskowLuckCounter(generator);

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
            MoskowLuckCounter counter = new MoskowLuckCounter(generator);

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
            int downBound = 100000;
            int upBound = 100100;
            SixDigitTicketGenerator generator = SixDigitTicketGenerator.Create(downBound, upBound);
            MoskowLuckCounter counter = new MoskowLuckCounter(generator);

            int expected = 3;
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
            int downBound = 000100;
            int upBound = 000107;
            SixDigitTicketGenerator generator = SixDigitTicketGenerator.Create(downBound, upBound);
            MoskowLuckCounter counter = new MoskowLuckCounter(generator);

            int expected = 0;
            int actual;

            // Act
            actual = counter.CountLuckyTickets();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}