// <copyright file="ITicketGenerator.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace LuckyTicket
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides iterator and property to build ticket generators
    /// </summary>
    public interface ITicketGenerator
    {
        /// <summary>
        /// Gets or sets number of digits in ticket number
        /// </summary>
        int DigitAmount { get; set; }

        /// <summary>
        /// Iterator which returns Ticket
        /// </summary>
        /// <returns>Ticket</returns>
        IEnumerator<Ticket> GetEnumerator();
    }
}
