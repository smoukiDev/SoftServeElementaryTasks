// <copyright file="FibonacciSequance.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace SequencesLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Reprecents sequence of Fibonacci numbers as 0,1,1,2,3...
    /// </summary>
    public class FibonacciSequance : Sequence<int>
    {
        private FibonacciSequance(int downLimit, int upLimit)
            : base(downLimit, upLimit)
        {
        }

        /// <summary>
        /// Gets up bound of sequence
        /// </summary>
        public int UpBound
        {
            get
            {
                return this.UpLimit;
            }
        }

        /// <summary>
        /// Gets down bound of sequence
        /// </summary>
        public int DownBound
        {
            get
            {
                return this.DownLimit;
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="FibonacciSequance"/> class.
        /// </summary>
        /// <param name="downLimit">Range down limit</param>
        /// <param name="upLimit">Range up limit</param>
        /// <returns>Instance of <see cref="FibonacciSequance"/></returns>
        /// <exception cref="ArgumentException">
        /// Up and down limits should be
        /// greater than zero or equal to
        /// </exception>
        public static FibonacciSequance Create(int downLimit, int upLimit)
        {
            if (downLimit < 0 || upLimit < 0)
            {
                throw new ArgumentException("Up and down limits should be greater than zero or equal to.");
            }

            return new FibonacciSequance(downLimit, upLimit);
        }

        /// <summary>
        /// Iterator return Fibonacci number in specified range
        /// </summary>
        /// <returns>Sequence elements</returns>
        public override IEnumerable<int> GetSequence()
        {
            int first = 0;
            int second = 1;

            while (second <= this.UpLimit)
            {
                int temp = second;
                second = first + second;
                first = temp;

                if (second >= this.DownLimit)
                {
                    yield return second;
                }
            }
        }
    }
}
