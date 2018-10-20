// <copyright file="IBoard.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace GameBoard.Bisuness_Logic
{
    /// <summary>
    /// Provides methods to build board and get cell
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// Get Cell by indexes
        /// </summary>
        /// <param name="xPosition">X coordinate of cell</param>
        /// <param name="yPosition">Y coordinate of cel</param>
        /// <returns>Сell by coordinates</returns>
        ICell this[int xPosition, int yPosition] { get; }

        /// <summary>
        /// Builds Board
        /// </summary>
        void BuildBoard();
    }
}
