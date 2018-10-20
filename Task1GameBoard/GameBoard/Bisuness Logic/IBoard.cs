// <copyright file="IBoard.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace GameBoard.Bisuness_Logic
{
    /// <summary>
    /// Represents game board
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// Gets cell by x and y coordinates on the board
        /// </summary>
        /// <param name="xPosition">Cell coordinate x</param>
        /// <param name="yPosition">Cell coordinate y</param>
        /// <returns>Cell with x and y coordinates</returns>
        ICell this[int xPosition, int yPosition] { get; }

        /// <summary>
        /// Resets board parameters
        /// </summary>
        /// <param name="width">Horisontal amount of cells</param>
        /// <param name="height">Vertical amount of cells</param>
        /// <param name="lightDark">First cell color. Light or dark</param>
        void ResetBoard(int width, int height, bool isLightCell);

        /// <summary>
        /// Builds board with specified parameters
        /// </summary>
        void BuildBoard();
    }
}
