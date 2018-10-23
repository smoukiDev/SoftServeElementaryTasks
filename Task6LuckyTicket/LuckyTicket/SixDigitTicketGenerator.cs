// <copyright file="SixDigitTicketGenerator.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace LuckyTicket
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents functionality to generate ticket with six digits
    /// </summary>
    public class SixDigitTicketGenerator : ITicketGenerator
    {
        private const byte SIZE = 6;
        private const int MAX_TICKET = 999999;
        private const int MIN_TICKET = 000001;

        /// <summary>
        /// Initializes a new instance of the <see cref="SixDigitTicketGenerator"/> class.
        /// </summary>
        public SixDigitTicketGenerator()
        {
            this.DigitAmount = SIZE;
        }

        /// <summary>
        /// Gets number of digits in ticket
        /// </summary>
        public int DigitAmount { get; }

        /// <summary>
        /// Iterators returns tickets <see cref="Ticket"></see> type./>
        /// </summary>
        /// <returns>Ticket</returns>
        public IEnumerator<Ticket> GetEnumerator()
        {
            for (int i = MIN_TICKET; i <= MAX_TICKET; i++)
            {
                yield return Ticket.Create(i, this.DigitAmount);
            }
        }
    }
}
