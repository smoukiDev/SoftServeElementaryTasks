// <copyright file="LuckCounter.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace LuckyTicket
{
    /// <summary>
    /// Reprecents prototype of lucky ticket counter
    /// which can work using some alghoritm of count
    /// </summary>
    public abstract class LuckCounter : ILuckyTicket
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LuckCounter"/> class
        /// </summary>
        /// <param name="generator">Generator of tickets</param>
        public LuckCounter(ITicketGenerator generator)
        {
            this.Generator = generator;
        }

        /// <summary>
        /// Gets or sets tickets generator
        /// </summary>
        public ITicketGenerator Generator
        {
            get;
            protected set;
        }

        /// <summary>
        /// Count number of lucky tickets
        /// on range specified by generator
        /// </summary>
        /// <returns>Number of lucky tickets</returns>
        public virtual int CountLuckyTickets()
        {
            int result = 0;

            foreach (Ticket ticket in this.Generator)
            {
                if (this.IsLucky(ticket))
                {
                    result++;
                }
            }

            return result;
        }

        /// <summary>
        /// Obligates child class realize interface ILuckyTicket
        /// </summary>
        /// <param name="ticket">Ticket</param>
        /// <returns>
        /// Returns true for lucky ticket and false if vice versa
        /// </returns>
        public abstract bool IsLucky(Ticket ticket);
    }
}
