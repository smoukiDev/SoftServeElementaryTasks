// <copyright file="PiterLuckCounter.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace LuckyTicket
{
    /// <summary>
    /// Represent lucky ticket counter
    /// using Piter algorithm.
    /// Even digits sum is equal
    /// uneven 3 digits sum.
    /// </summary>
    public class PiterLuckCounter : LuckCounter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PiterLuckCounter"/> class.
        /// </summary>
        /// <param name="generator">Ticket generator</param>
        public PiterLuckCounter(ITicketGenerator generator)
            : base(generator)
        {
        }

        /// <summary>
        /// Count number of lucky tickets on range
        /// specified by generator
        /// using Piter algorithm.
        /// Even digits sum is equal
        /// uneven digits sum.
        /// </summary>
        /// <returns>
        /// Number of lucky tickets on range specified in generator.
        /// </returns>
        public override int CountLuckyTickets()
        {
            return base.CountLuckyTickets();
        }

        /// <summary>
        /// Identifies whether ticket is lucky
        /// using Piter algorithm.
        /// Even digits sum is equal
        /// uneven digits sum.
        /// </summary>
        /// <param name="ticket">Ticket</param>
        /// <returns>
        /// Returns true for lucky ticket and false if vice versa.
        /// </returns>
        public override bool IsLucky(Ticket ticket)
        {
            int unevenSum = 0;
            int evenSum = 0;
            int size = ticket.TicketNumber.Length;
            for (int i = 0; i < size - 1; i += 2)
            {
                unevenSum += (int)char.GetNumericValue(ticket.TicketNumber[i]);
                evenSum += (int)char.GetNumericValue(ticket.TicketNumber[i + 1]);
            }

            return unevenSum == evenSum;
        }
    }
}
