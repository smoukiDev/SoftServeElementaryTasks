// <copyright file="MoskowLuckCounter.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace LuckyTicket
{
    /// <summary>
    /// Represent lucky ticket counter
    /// using Moskow algorithm.
    /// First 3 digits sum is equal
    /// last 3 digits sum.
    /// </summary>
    public class MoskowLuckCounter : LuckCounter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoskowLuckCounter"/> class.
        /// </summary>
        /// <param name="generator">Ticket generator</param>
        public MoskowLuckCounter(ITicketGenerator generator)
            : base(generator)
        {
        }

        /// <summary>
        /// Count number of lucky tickets on range
        /// specified by generator
        /// using Moskow algorithm.
        /// First 3 digits sum is equal
        /// last 3 digits sum.
        /// </summary>
        /// <returns>Number of lucky tickets on range specified by generator.</returns>
        public override int CountLuckyTickets()
        {
            return base.CountLuckyTickets();
        }

        /// <summary>
        /// Identifies whether ticket is lucky
        /// using Moskow algorithm.
        /// First 3 digits sum is equal
        /// last 3 digits sum.
        /// </summary>
        /// <param name="ticket">Ticket</param>
        /// <returns>
        /// Returns true for lucky ticket and false if vice versa.
        /// </returns>
        public override bool IsLucky(Ticket ticket)
        {
            int leftThreeSum = 0;
            int rightThreeSum = 0;
            int size = ticket.TicketNumber.Length;
            for (int i = 0; i < size / 2; i++)
            {
                leftThreeSum += (int)char.GetNumericValue(ticket.TicketNumber[i]);
                rightThreeSum += (int)char.GetNumericValue(ticket.TicketNumber[size - 1 - i]);
            }

            return leftThreeSum == rightThreeSum;
        }
    }
}
