// <copyright file="NaturalSquareSequence.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace SequencesLib
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Reprecents sequence of natural numbers with square less then N^2
    /// </summary>
    public class NaturalSquareSequence : Sequence<int>
    {
        private const int DOWN_LIMIT = 1;

        private NaturalSquareSequence(int squareLimit)
            : base(DOWN_LIMIT, squareLimit)
        {
        }

        /// <summary>
        /// Gets bound of sequence
        /// </summary>
        public int SquareLimit
        {
            get
            {
                return this.UpLimit;
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="NaturalSquareSequence"/> class.
        /// </summary>
        /// <param name="squareLimit">Square of number limit</param>
        /// <returns>Instance of <see cref="NaturalSquareSequence"/></returns>
        /// <exception cref="ArgumentException">Square Limit should be greater than zero</exception>
        public static NaturalSquareSequence Create(int squareLimit)
        {
            if (squareLimit <= 0)
            {
                throw new ArgumentException("Square Limit should be greater than zero");
            }

            return new NaturalSquareSequence(squareLimit);
        }

        /// <summary>
        /// Iterator return natural numbers with square less then SquareLimit
        /// </summary>
        /// <returns>Sequence elements</returns>
        public override IEnumerable<int> GetSequence()
        {
            for (int counter = this.DownLimit; counter < this.UpLimit; counter++)
            {
                if (counter * counter < this.UpLimit)
                {
                    yield return counter;
                }
            }
        }
    }
}
