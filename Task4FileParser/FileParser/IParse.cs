// <copyright file="IParse.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace FileParser
{
    /// <summary>
    /// Provides prototype of method to parse  strings
    /// </summary>
    public interface IParse
    {
        /// <summary>
        /// Perform parsing of string
        /// </summary>
        /// <returns>
        /// Number ofSuccess parsing manipulations
        /// </returns>
        int Parse();
    }
}
