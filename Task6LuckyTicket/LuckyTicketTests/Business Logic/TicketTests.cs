namespace LuckyTicket.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class TicketTests
    {
        [TestMethod]
        [DataRow(000000, 0)]
        [DataRow(000007, 1)]
        [DataRow(-000001, 6)]
        [DataRow(000001, -6)]
        [DataRow(1234567, 6)]
        public void Create_ThrowsArgumentException(int number, int size)
        {
            // Arrange
            Ticket ticket;

            // Act
            // Assert
            Assert.ThrowsException<ArgumentException>(() => ticket = Ticket.Create(number, size));
        }

        [TestMethod]
        [DataRow(000001, 6)]
        [DataRow(999999, 6)]
        [DataRow(123456, 6)]
        [DataRow(0000001, 6)]
        public void Create_ReturnInstanceSuccessfully(int number, int size)
        {
            // Arrange
            Ticket ticket;

            // Act
            // Assert
            try
            {
                ticket = Ticket.Create(number, size);
            }
            catch(ArgumentException)
            {
                Assert.Fail();
            }
        }
    }
}