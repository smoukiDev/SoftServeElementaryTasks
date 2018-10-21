// <copyright file="Sequence{T}.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace SequencesLib
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides foundation to build sequences
    /// </summary>
    /// <typeparam name="T">Type of sequence elements</typeparam>
    public abstract class Sequence<T>
    {
        private T downLimit;
        private T upLimit;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sequence{T}"/> class.
        /// </summary>
        /// <param name="downLimit">Sequence down bound of range</param>
        /// <param name="upLimit">Sequence up bound of range</param>
        public Sequence(T downLimit, T upLimit)
        {
            this.downLimit = downLimit;
            this.upLimit = upLimit;
        }

        /// <summary>
        /// Gets or sets sequence down bound of range
        /// </summary>
        protected T DownLimit
        {
            get
            {
                return this.downLimit;
            }

            set
            {
                this.downLimit = value;
            }
        }

        /// <summary>
        /// Gets or sets sequence up bound of range
        /// </summary>
        protected T UpLimit
        {
            get
            {
                return this.upLimit;
            }

            set
            {
                this.upLimit = value;
            }
        }

        /// <summary>
        /// Method Iterator for selection element
        /// of sequence by some condition and logic
        /// </summary>
        /// <returns>Sequence elements</returns>
        public abstract IEnumerable<T> GetSequence();
    }
}
