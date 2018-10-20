// <copyright file="Board.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace GameBoard.Bisuness_Logic
{
    using System;

    /// <summary>
    /// Represents game board
    /// </summary>
    public class Board : IBoard
    {
        private static readonly string ARGUMENT_EXCEPTION_MESSAGE = $"Impossible to build board with specified"
                                                                  + $"{nameof(Width)} and {nameof(Height)} parameters";

        private static readonly string ARGUMENT_NULL_EXCEPTION_MESSAGE = $"Board hasn't build.Impossible to get cell";

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class with default values
        /// </summary>
        public Board()
            : this(0, 0, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class with default values
        /// </summary>
        /// <param name="width">Board width - amount of cell by vertical</param>
        /// <param name="height">Board width - amount of cell by horisontal</param>
        /// <param name="isLightCell">Flag wheter first cell is light(true) or dark(false)</param>
        public Board(int width, int height, bool isLightCell)
        {
            if (width <= 0)
            {
                this.Width = 0;
            }
            else
            {
                this.Width = width;
            }

            if (height <= 0)
            {
                this.Height = 0;
            }
            else
            {
                this.Height = height;
            }

            this.BoardSurface = new Cell[this.Height, this.Width];
            this.IsLightCell = isLightCell;
        }

        /// <summary>
        /// Gets board width - amount of cell by horisontal
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets board width - amount of cell by vertical
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets board surface - massive of cells
        /// </summary>
        public Cell[,] BoardSurface { get; private set; }

        /// <summary>
        /// Gets a value indicating whether  fist cell of board is light cell
        /// </summary>
        public bool IsLightCell { get; private set; }

        /// <summary>
        /// Gets cell by x and y coordinates on the board
        /// </summary>
        /// <param name="xPosition">Cell coordinate x</param>
        /// <param name="yPosition">Cell coordinate y</param>
        /// <returns>Cell with x and y coordinates</returns>
        /// <exception cref="ArgumentException">Incorrect width and height</exception>
        /// <exception cref="ArgumentNullException">Board hasn't build, cell are empty</exception>
        /// <exception cref="IndexOutOfRangeException">Incorrect index</exception>
        public ICell this[int xPosition, int yPosition]
        {
            get
            {
                if (this.Width == 0 || this.Height == 0)
                {
                    throw new ArgumentException(ARGUMENT_EXCEPTION_MESSAGE);
                }

                if (xPosition > this.Width || xPosition == 0)
                {
                    throw new IndexOutOfRangeException();
                }

                if (yPosition > this.Height || yPosition == 0)
                {
                    throw new IndexOutOfRangeException();
                }

                if (this.BoardSurface[yPosition - 1, xPosition - 1] == null)
                {
                    throw new ArgumentNullException(ARGUMENT_NULL_EXCEPTION_MESSAGE);
                }

                return this.BoardSurface[yPosition - 1, xPosition - 1];
            }
        }

        /// <summary>
        /// Reset instant of <see cref="Board"/> changing parameters
        /// </summary>
        /// <param name="width">Board width - amount of cell by vertical</param>
        /// <param name="height">Board width - amount of cell by horisontal</param>
        /// <param name="isLightCell">Flag wheter first cell is light(true) or dark(false)</param>
        /// <exception cref="ArgumentException">Incorrect width and height</exception>
        public void ResetBoard(int width, int height, bool isLightCell)
        {
            if (width <= 0)
            {
                throw new ArgumentException(ARGUMENT_EXCEPTION_MESSAGE);
            }
            else
            {
                this.Width = width;
            }

            if (height <= 0)
            {
                throw new ArgumentException(ARGUMENT_EXCEPTION_MESSAGE);
            }
            else
            {
                this.Height = height;
            }

            this.BoardSurface = new Cell[this.Height, this.Width];
            this.IsLightCell = isLightCell;
        }

        /// <summary>
        /// Builds game board creating cells
        /// </summary>
        /// <exception cref="ArgumentException">Incorrect width and height</exception>
        public void BuildBoard()
        {
            if (this.Width == 0 || this.Height == 0)
            {
                throw new ArgumentException(ARGUMENT_EXCEPTION_MESSAGE);
            }

            for (int height = 0; height < this.Height; height++)
            {
                for (int width = 0; width < this.Width; width++)
                {
                    if (this.IsLightCell)
                    {
                        this.BoardSurface[height, width] = new Cell
                        {
                            Color = (((height + width) % 2) == 0) ? CellColor.White : CellColor.Black
                        };
                    }
                    else
                    {
                        this.BoardSurface[height, width] = new Cell
                        {
                            Color = (((height + width) % 2) == 0) ? CellColor.Black : CellColor.White
                        };
                    }
                }
            }
        }
    }
}
