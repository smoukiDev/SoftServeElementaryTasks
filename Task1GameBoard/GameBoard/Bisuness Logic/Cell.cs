// <copyright file="Cell.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace GameBoard.Bisuness_Logic
{
    /// <summary>
    /// Represents board cell
    /// </summary>
    public class Cell : ICell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        public Cell()
            : this(CellColor.White)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="color">Cell color</param>
        public Cell(CellColor color)
        {
            this.Color = color;
        }

        /// <summary>
        /// Gets or sets board cell color
        /// </summary>
        public CellColor Color { get; set; }

        /// <summary>
        /// Get name of color for board cell
        /// </summary>
        /// <returns>Name of color</returns>
        public override string ToString()
        {
            return this.Color.ToString();
        }
    }
}
