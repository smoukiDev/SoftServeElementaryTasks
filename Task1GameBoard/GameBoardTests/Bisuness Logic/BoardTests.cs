using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameBoard.Bisuness_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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
        public void ResetBoard_ThrowsArgumentException(int width, int height)
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
        public void BuildBoard_FirstCellDark()
        {
            // Arrange
            int width = 4;
            int height = 4;
            bool isFirstCellWhite = false;
            Board board = new Board(width, height, isFirstCellWhite);
            board.BuildBoard();
            Cell[,] actualBoardSurface = board.BoardSurface;

            #region Expected BoardSurface Initialization

            Cell[,] expectedBoardSurface = new Cell[height, width];
            Cell cellOne = new Cell (CellColor.Black);
            Cell cellTwo = new Cell (CellColor.White);
            // Row One of expected board
            expectedBoardSurface[0, 0] = cellOne;
            expectedBoardSurface[0, 1] = cellTwo;
            expectedBoardSurface[0, 2] = cellOne;
            expectedBoardSurface[0, 3] = cellTwo;
            // Row Two of expected board
            expectedBoardSurface[1, 0] = cellTwo;
            expectedBoardSurface[1, 1] = cellOne;
            expectedBoardSurface[1, 2] = cellTwo;
            expectedBoardSurface[1, 3] = cellOne;
            // Row Three of expected board
            expectedBoardSurface[2, 0] = cellOne;
            expectedBoardSurface[2, 1] = cellTwo;
            expectedBoardSurface[2, 2] = cellOne;
            expectedBoardSurface[2, 3] = cellTwo;
            // Row Four of expected board
            expectedBoardSurface[3, 0] = cellTwo;
            expectedBoardSurface[3, 1] = cellOne;
            expectedBoardSurface[3, 2] = cellTwo;
            expectedBoardSurface[3, 3] = cellOne;

            #endregion

            int actual = 0;
            int expected = height*width;

            // Act
            for (int heightIndex = 0; heightIndex < board.Height; heightIndex++)
            {
                for (int widthIndex = 0; widthIndex < board.Width; widthIndex++)
                {
                    if((int)actualBoardSurface[heightIndex, widthIndex].Color == (int)expectedBoardSurface[heightIndex, widthIndex].Color)
                    {
                        actual++;
                    }
                }
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuildBoard_FirstCellLight()
        {
            // Arrange
            int width = 4;
            int height = 4;
            bool isFirstCellWhite = true;
            Board board = new Board(width, height, isFirstCellWhite);
            board.BuildBoard();
            Cell[,] actualBoardSurface = board.BoardSurface;

            #region Expected BoardSurface Initialization

            Cell[,] expectedBoardSurface = new Cell[height, width];
            Cell cellOne = new Cell(CellColor.White);
            Cell cellTwo = new Cell(CellColor.Black);
            // Row One of expected board
            expectedBoardSurface[0, 0] = cellOne;
            expectedBoardSurface[0, 1] = cellTwo;
            expectedBoardSurface[0, 2] = cellOne;
            expectedBoardSurface[0, 3] = cellTwo;
            // Row Two of expected board
            expectedBoardSurface[1, 0] = cellTwo;
            expectedBoardSurface[1, 1] = cellOne;
            expectedBoardSurface[1, 2] = cellTwo;
            expectedBoardSurface[1, 3] = cellOne;
            // Row Three of expected board
            expectedBoardSurface[2, 0] = cellOne;
            expectedBoardSurface[2, 1] = cellTwo;
            expectedBoardSurface[2, 2] = cellOne;
            expectedBoardSurface[2, 3] = cellTwo;
            // Row Four of expected board
            expectedBoardSurface[3, 0] = cellTwo;
            expectedBoardSurface[3, 1] = cellOne;
            expectedBoardSurface[3, 2] = cellTwo;
            expectedBoardSurface[3, 3] = cellOne;

            #endregion

            int actual = 0;
            int expected = height * width;

            // Act
            for (int heightIndex = 0; heightIndex < board.Height; heightIndex++)
            {
                for (int widthIndex = 0; widthIndex < board.Width; widthIndex++)
                {
                    if ((int)actualBoardSurface[heightIndex, widthIndex].Color == (int)expectedBoardSurface[heightIndex, widthIndex].Color)
                    {
                        actual++;
                    }
                }
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(0, 0, true)]
        [DataRow(-8, 8, false)]
        [DataRow(8, -8, true)]
        [DataRow(-8, -8, false)]
        public void BuildBoard_ThrowsArgumentException(int width, int height, bool isWhiteCell)
        {
            // Arrange
            Board board = new Board(width, height, isWhiteCell);
            // Act

            // Arrange
            Assert.ThrowsException<ArgumentException>(() => board.BuildBoard());
        }

        [TestMethod]
        [DataRow(4, 4, 0, 1)]
        [DataRow(4, 4, 1, 0)]
        [DataRow(4, 4, 0, 0)]
        [DataRow(4, 4, 1, 5)]
        [DataRow(4, 4, 5, 1)]
        [DataRow(4, 4, 5, 5)]
        [DataRow(4, 4, -1, -1)]
        public void Indexer_ThrowsIndexOutRangeException(int width, int height, int indexWidth, int indexHeight)
        {
            // Arrange
            bool isWhiteCell = true;
            Board board = new Board(width, height, isWhiteCell);

            // Act
            board.BuildBoard();

            // Arrange
            Assert.ThrowsException<IndexOutOfRangeException>(() => board[indexHeight, indexWidth]);
        }

        [TestMethod]
        [DataRow(4, 4, 1, 1)]
        [DataRow(4, 4, 4, 4)]
        [DataRow(4, 4, 3, 2)]
        [DataRow(4, 4, 2, 1)]
        public void Indexer_ThrowsArgumentNullException(int width, int height, int indexWidth, int indexHeight)
        {
            // Arrange
            bool isWhiteCell = true;
            Board board = new Board(width, height, isWhiteCell);

            // Act
            // Don't proceed
            // board.BuildBoard();

            // Arrange
            Assert.ThrowsException<ArgumentNullException>(() => board[indexHeight, indexWidth]);
        }

        [TestMethod]
        [DataRow(4, 4, 1, 1)]
        [DataRow(4, 4, 4, 4)]
        [DataRow(4, 4, 3, 2)]
        [DataRow(4, 4, 2, 1)]
        public void Indexer_ReturnCellSuccessfully(int width, int height, int indexWidth, int indexHeight)
        {
            // Arrange
            bool isWhiteCell = true;
            Board board = new Board(width, height, isWhiteCell);

            // Act
            board.BuildBoard();

            // Arrange
            try
            {
                Cell cell = (Cell)board[indexHeight, indexWidth];
            }
            catch(Exception)
            {
                Assert.Fail();
            }
        }
    }
}