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
        private const string ARGUMENT_EXCEPTION_MESSAGE = "Sides of envelop can be only positive values";

        private Envelop(double sideA, double sideB)
        {
            this.SideA = sideA;
            this.SideB = sideB;
        }

        /// <summary>
        /// Gets envelop first side
        /// </summary>
        public double SideA
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets envelop second side
        /// </summary>
        public double SideB
        {
            get;
            private set;
        }

        /// <summary>
        /// Compares Envelops by sides
        /// </summary>
        /// <param name="one">Left envelop operand</param>
        /// <param name="two">Right envelop operand</param>
        /// <returns>
        /// Returns true if envelop one larger then envelop two
        /// and false if vice versa
        /// </returns>
        public static bool operator >(Envelop one, Envelop two)
        {
            bool result = false;

            if (one.SideA > two.SideA && one.SideB > one.SideB)
            {
                result = true;
            }

            if (one.SideA > two.SideB && one.SideB > two.SideA)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Compares Envelops by sides
        /// </summary>
        /// <param name="one">Left envelop operand</param>
        /// <param name="two">Right envelop operand</param>
        /// <returns>
        /// Returns false if envelop one larger envelop two
        /// and true if vice versa
        /// </returns>
        public static bool operator <(Envelop one, Envelop two)
        {
            bool result = false;

            if (one.SideA < two.SideA && one.SideB < one.SideB)
            {
                result = true;
            }

            if (one.SideA < two.SideB && one.SideB < two.SideA)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Compares Envelops by sides
        /// </summary>
        /// <param name="one">Left envelop operand</param>
        /// <param name="two">Right envelop operand</param>
        /// <returns>
        /// Returns true if envelop one equals envelop two
        /// and false if vice versa
        /// </returns>
        public static bool operator ==(Envelop one, Envelop two)
        {
            bool result = false;

            if (one.SideA == two.SideA && one.SideB == one.SideB)
            {
                result = true;
            }

            if (one.SideA == two.SideB && one.SideB == two.SideA)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Compares Envelops by sides
        /// </summary>
        /// <param name="one">Left envelop operand</param>
        /// <param name="two">Right envelop operand</param>
        /// <returns>
        /// Returns true if envelop one doesn't equal envelop two
        /// and false if vice versa
        /// </returns>
        public static bool operator !=(Envelop one, Envelop two)
        {
            bool result = false;

            if (one.SideA != two.SideA || one.SideB != one.SideB)
            {
                result = true;
            }

            if (one.SideA != two.SideB || one.SideB != two.SideA)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Creates envelop
        /// </summary>
        /// <param name="sideA">First side</param>
        /// <param name="sideB">Second side</param>
        /// <returns>Created envelop</returns>
        /// <exception cref="ArgumentException">
        /// Sides of envelop can be only positive values
        /// </exception>
        public static Envelop Create(double sideA, double sideB)
        {
            if (sideA <= 0 || sideB <= 0)
            {
                throw new ArgumentException(ARGUMENT_EXCEPTION_MESSAGE);
            }

            return new Envelop(sideA, sideB);
        }

        /// <summary>
        /// Serves as hash function
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Determines wheter objects are equal
        /// </summary>
        /// <param name="obj">Object to compare with</param>
        /// <returns>
        /// Returns true - are equal, false - aren't equal
        /// </returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
