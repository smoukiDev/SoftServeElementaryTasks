using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameBoard.Bisuness_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBoard.Bisuness_Logic.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(-8, 8)]
        [DataRow(8, -8)]
        [DataRow(-8, -8)]
        public void ResetBoardTest_ThrowsArgumentException(int width, int height)
        {
            // Arrange
            Board board = new Board();
            // Act

            // Arrange
            Assert.ThrowsException<ArgumentException>(() => board.ResetBoard(width, height, true));
        }

        [TestMethod]
        [DataRow(8, 8)]
        [DataRow(10, 25)]
        public void ResetBoard_UpdateInstancePropertiesSuccessfully(int width, int height)
        {
            /// Arrange
            Board board = new Board();

            /// Act 
            try
            {
                board.ResetBoard(width, height, true);
            }
            /// Assert 
            catch (ArgumentException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [DataRow(4, 4, false)]
        public void BuildBoardTest(int width, int height)
        {
            
        }

        [TestMethod]
        public void BoardTest()
        {
            Assert.Fail();
        }
    }
}