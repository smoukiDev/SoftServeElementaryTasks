// <copyright file="Envelop.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace EnvelopEnclosure
{
    using System;

    /// <summary>
    /// Represents Envelop with embed operators to compate them
    /// </summary>
    public class Envelop
    {
        private Envelop(double sideA, double sideB)
        {
            this.SideA = sideA;
            this.SideB = sideB;
        }

        /// <summary>
        /// Gets envelop first side
        /// </summary>
        public double SideA { get; private set; }

        /// <summary>
        /// Gets envelop second side
        /// </summary>
        public double SideB { get; private set; }

        /// <summary>
        /// Compares Envelops by sides
        /// </summary>
        /// <param name="one">Left envelop operand</param>
        /// <param name="two">Right envelop operand</param>
        /// <returns>true if envelop one larger envelop two and false if vice versa</returns>
        public static bool operator >(Envelop one, Envelop two)
        {
            if (one.SideA > two.SideA && one.SideB > one.SideB)
            {
                return true;
            }

            if (one.SideA > two.SideB && one.SideB > two.SideA)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compares Envelops by sides
        /// </summary>
        /// <param name="one">Left envelop operand</param>
        /// <param name="two">Right envelop operand</param>
        /// <returns>false if envelop one larger envelop two and true if vice versa</returns>
        public static bool operator <(Envelop one, Envelop two)
        {
            if (one.SideA < two.SideA && one.SideB < one.SideB)
            {
                return true;
            }

            if (one.SideA < two.SideB && one.SideB < two.SideA)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Creates envelop
        /// </summary>
        /// <param name="sideA">First side</param>
        /// <param name="sideB">Second side</param>
        /// <returns>Created envelop</returns>
        /// <exception cref="ArgumentException">Incorret sides</exception>
        public static Envelop CreateEnvelop(double sideA, double sideB)
        {
            if (sideA <= 0 || sideB <= 0)
            {
                throw new ArgumentException("Sides of envelop can be only positive values");
            }

            return new Envelop(sideA, sideB);
        }
    }
}
