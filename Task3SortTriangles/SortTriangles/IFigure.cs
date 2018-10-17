// <copyright file="IFigure.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace SortTriangles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFigure
    {
        double CalculatePerimeter();

        double CalculateSquare();

        double this[int index]
        {
            get;
        }
    }
}
