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
        public void BuildBoardTest_FirstCellDark()
        {
            // Arrange
            int width = 4;
            int height = 4;
            bool isFirstCellWhite = false;
            Board board = new Board(width, height, isFirstCellWhite);
            board.BuildBoard();
            Cell[,] actualBoardSurface = board.BoardSurface;

            #region Expected BoardSurface Initialization

            Cell[,] expectedBoardSurface = new Cell[width, height];
            // Row One of expected board
            expectedBoardSurface[0, 0] = new Cell(CellColor.Black);
            expectedBoardSurface[0, 1] = new Cell(CellColor.White);
            expectedBoardSurface[0, 2] = new Cell(CellColor.Black);
            expectedBoardSurface[0, 3] = new Cell(CellColor.White);
            // Row Two of expected board
            expectedBoardSurface[1, 0] = new Cell(CellColor.White);
            expectedBoardSurface[1, 1] = new Cell(CellColor.Black);
            expectedBoardSurface[1, 2] = new Cell(CellColor.White);
            expectedBoardSurface[1, 3] = new Cell(CellColor.Black);
            // Row Three of expected board
            expectedBoardSurface[2, 0] = new Cell(CellColor.Black);
            expectedBoardSurface[2, 1] = new Cell(CellColor.White);
            expectedBoardSurface[2, 2] = new Cell(CellColor.Black);
            expectedBoardSurface[2, 3] = new Cell(CellColor.White);
            // Row Four of expected board
            expectedBoardSurface[3, 0] = new Cell(CellColor.White);
            expectedBoardSurface[3, 1] = new Cell(CellColor.Black);
            expectedBoardSurface[3, 2] = new Cell(CellColor.White);
            expectedBoardSurface[3, 3] = new Cell(CellColor.Black);

            #endregion

            bool actual = false;
            bool expected = true;

            // Act
            for (int heightIndex = 0; height < board.Height; height++)
            {
                for (int widthIndex = 0; widthIndex < board.Width; widthIndex++)
                {
                    if(actualBoardSurface[heightIndex, widthIndex].Color == expectedBoardSurface[heightIndex, widthIndex].Color)
                    {
                        actual = true;
                    }
                    else
                    {
                        actual = false;
                    }
                }
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BoardTest()
        {
            Assert.Fail();
        }
    }
}