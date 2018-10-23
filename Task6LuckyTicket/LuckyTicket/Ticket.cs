// <copyright file="Ticket.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace LuckyTicket
{
    using System;

    /// <summary>
    /// Specifies incorrect ticket sizes
    /// </summary>
    public enum TicketSize
    {
        /// <summary>
        /// Size is equal 0
        /// </summary>
        Zero,

        /// <summary>
        /// Size is equal 1
        /// </summary>
        One
    }

    /// <summary>
    /// Represents ticket which use in public transport as tram for example
    /// </summary>
    public class Ticket
    {
        private const string ARGUMENT_EXCEPTION_ONE = "Number can't contain more digits than size.";
        private const string ARGUMENT_EXCEPTION_TWO = "Number can't be negative.";
        private const string ARGUMENT_EXCEPTION_THREE = "Size can't be zero or one";

        private Ticket(int number, int size)
        {
            this.Initialize(number, size);
        }

        /// <summary>
        /// Gets string view of ticket number
        /// </summary>
        public string TicketNumber { get; private set; }

        /// <summary>
        /// Creates and returns instance of <see cref="Ticket"/>
        /// </summary>
        /// <param name="number">Ticket number in integer view</param>
        /// <param name="size">Ticket size</param>
        /// <returns>Instance of <see cref="Ticket"/></returns>
        public static Ticket Create(int number, int size)
        {
            if (number.ToString().Length > size)
            {
                throw new ArgumentException(ARGUMENT_EXCEPTION_ONE);
            }

            if (number < 0)
            {
                throw new ArgumentException(ARGUMENT_EXCEPTION_TWO);
            }

            if (size == (int)TicketSize.Zero || size == (int)TicketSize.One)
            {
                throw new ArgumentException(ARGUMENT_EXCEPTION_THREE);
            }

            return new Ticket(number, size);
        }

        private void Initialize(int number, int size)
        {
            this.TicketNumber = number.ToString();
            int lenght = this.TicketNumber.Length;
            for (int i = 0; i < size - lenght; i++)
            {
                this.TicketNumber = this.TicketNumber.Insert(0, "0");
            }
        }
    }
}
