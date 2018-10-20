// <copyright file="ICell.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace GameBoard.Bisuness_Logic
{
    /// <summary>
    /// Contains colors for cell on game board
    /// </summary>
    public enum CellColor
    {
        /// <summary>
        /// White color
        /// </summary>
        White,

        /// <summary>
        ///  Black color
        /// </summary>
        Black
    }

    /// <summary>
    /// Provides prototype of property to get and set color of cell
    /// </summary>
    public interface ICell
    {
        /// <summary>
        /// Gets or sets color of cell
        /// </summary>
        CellColor Color { get; set; }
    }
}
