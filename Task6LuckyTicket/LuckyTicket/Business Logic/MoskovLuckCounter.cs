// <copyright file="MoskovLuckCounter.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace LuckyTicket
{
    /// <summary>
    /// Represent lucky ticket counter
    /// using Moskov algorithm
    /// First 3 digits sum is equal
    /// Last 3 digits sum
    /// </summary>
    public class MoskovLuckCounter : LuckCounter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoskovLuckCounter"/> class.
        /// </summary>
        /// <param name="generator">Ticket generator</param>
        public MoskovLuckCounter(ITicketGenerator generator)
            : base(generator)
        {
        }

        /// <summary>
        /// Count number of lucky tickets on range
        /// specified in generator
        /// using Moskov algorithm
        /// First 3 digits sum is equal
        /// Last 3 digits sum
        /// </summary>
        /// <returns>Number of lucky tickets on range specified in generator</returns>
        public override int CountLuckyTickets()
        {
            return base.CountLuckyTickets();
        }

        /// <summary>
        /// Identifies whether ticket is lucky
        /// using Moskov algorithm
        /// First 3 digits sum is equal
        /// Last 3 digits sum
        /// </summary>
        /// <param name="ticket">Ticket</param>
        /// <returns>Lucky ticket - true, false - if not</returns>
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
