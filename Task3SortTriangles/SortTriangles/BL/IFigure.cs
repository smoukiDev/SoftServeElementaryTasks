// <copyright file="IFigure.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace SortTriangles
{
    /// <summary>
    /// Provides methods and indexer which some figure could realize
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// An indexer prototypes that return side of figure
        /// </summary>
        /// <param name="index">Index of side</param>
        /// <returns>Side by index</returns>
        double this[int index]
        {
            get;
        }

        /// <summary>
        /// A method prototype that calculates and return perimeter of figure
        /// </summary>
        /// <returns>Perimeter</returns>
        double CalculatePerimeter();

        /// <summary>
        /// A method prototype that calculates and return square of figure
        /// </summary>
        /// <returns>Square</returns>
        double CalculateSquare();

    }
}
