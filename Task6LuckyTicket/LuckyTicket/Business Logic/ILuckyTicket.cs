// <copyright file="ILuckyTicket.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace LuckyTicket
{
    /// <summary>
    /// Provides method IsLucky to indicate lucky ticket
    /// using some alghorithm
    /// </summary>
    public interface ILuckyTicket
    {
        /// <summary>
        /// Prototype of method, which indicates wheter Ticket is lucky
        /// </summary>
        /// <param name="ticket">Ticket</param>
        /// <returns>
        /// Returns true - for lucky tickets, false if vice versa
        /// </returns>
        bool IsLucky(Ticket ticket);
    }
}
