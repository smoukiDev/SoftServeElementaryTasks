// <copyright file="TypeToStringViewConvertor{T}.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace IntToStringView.BusinessLogic
{
    /// <summary>
    /// Provides structure
    /// which must have convertor
    /// which converts number value
    /// to string representation.
    /// </summary>
    /// <typeparam name="T">
    /// Type of base converted value.
    /// </typeparam>
    public abstract class TypeToStringViewConvertor<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeToStringViewConvertor{T}"/> class.
        /// </summary>
        /// <param name="convertedValue">Base value to convert</param>
        public TypeToStringViewConvertor(T convertedValue)
        {
            this.BaseConvertedValue = convertedValue;
        }

        /// <summary>
        /// Gets or sets base converted value
        /// </summary>
        public T BaseConvertedValue
        {
            get;
            protected set;
        }

        /// <summary>
        /// Prototype of method
        /// which converts specified base convert value
        /// to string view.
        /// </summary>
        /// <returns>String view of specified number value</returns>
        public abstract string ToStringView();
    }
}
