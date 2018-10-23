// <copyright file="SixDigitTicketGenerator.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace LuckyTicket
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents functionality to generate ticket with six digits
    /// </summary>
    public class SixDigitTicketGenerator : ITicketGenerator
    {
        private const string ARGUMENT_EXCEPTION_MESSAGE = "Incorrect values for range";
        private const byte SIZE = 6;
        private const int MAX_TICKET = 999999;
        private const int MIN_TICKET = 000001;

        /// <summary>
        /// Initializes a new instance of the <see cref="SixDigitTicketGenerator"/> class.
        /// </summary>
        private SixDigitTicketGenerator(int downBound, int upBound)
        {
            this.DigitAmount = SIZE;
            this.DownBound = downBound;
            this.UpBound = upBound;
        }

        /// <summary>
        /// Gets down limit of range
        /// </summary>
        public int DownBound { get; }

        /// <summary>
        /// Gets up limit of range
        /// </summary>
        public int UpBound { get; }

        /// <summary>
        /// Gets number of digits in ticket
        /// </summary>
        public int DigitAmount { get; }

        /// <summary>
        /// Creates and returns instance of <see cref="SixDigitTicketGenerator"/>
        /// </summary>
        /// <param name="downBound">Down bound of range</param>
        /// <param name="upBound">Up bound of range</param>
        /// <returns>Instance of <see cref="SixDigitTicketGenerator"/></returns>
        public static SixDigitTicketGenerator Create(int downBound, int upBound)
        {
            if (downBound < MIN_TICKET || downBound > MAX_TICKET - 1)
            {
                throw new ArgumentException(ARGUMENT_EXCEPTION_MESSAGE);
            }

            if (upBound < MIN_TICKET + 1 || upBound > MAX_TICKET)
            {
                throw new ArgumentException(ARGUMENT_EXCEPTION_MESSAGE);
            }

            return new SixDigitTicketGenerator(downBound, upBound);
        }

        /// <summary>
        /// Iterators returns tickets <see cref="Ticket"></see> type./>
        /// </summary>
        /// <returns>Ticket</returns>
        public IEnumerator<Ticket> GetEnumerator()
        {
            for (int i = this.DownBound; i <= this.UpBound; i++)
            {
                yield return Ticket.Create(i, this.DigitAmount);
            }
        }
    }
}
