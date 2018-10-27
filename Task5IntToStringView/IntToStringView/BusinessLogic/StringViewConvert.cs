// <copyright file="StringViewConvert.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace IntToStringView.BusinessLogic
{
    /// <summary>
    /// Provides extension methods
    /// for base types
    /// as ulong, long, uint, int, ushort, short, byte, sbyte
    /// which convert them to string view
    /// </summary>
    public static class StringViewConvert
    {
        /// <summary>
        /// Converts argument to string view
        /// </summary>
        /// <param name="argument">Value to convert</param>
        /// <returns>String view of value</returns>
        public static string ToStringView(this ulong argument)
        {
            IntegerToStringViewConvertor convertor;
            convertor = new IntegerToStringViewConvertor(argument);
            return convertor.ToStringView();
        }

        /// <summary>
        /// Converts argument to string view
        /// </summary>
        /// <param name="argument">Value to convert</param>
        /// <returns>String view of value</returns>
        public static string ToStringView(this long argument)
        {
            IntegerToStringViewConvertor convertor;
            convertor = new IntegerToStringViewConvertor(argument);
            return convertor.ToStringView();
        }

        /// <summary>
        /// Converts argument to string view
        /// </summary>
        /// <param name="argument">Value to convert</param>
        /// <returns>String view of value</returns>
        public static string ToStringView(this uint argument)
        {
            IntegerToStringViewConvertor convertor;
            convertor = new IntegerToStringViewConvertor(argument);
            return convertor.ToStringView();
        }

        /// <summary>
        /// Converts argument to string view
        /// </summary>
        /// <param name="argument">Value to convert</param>
        /// <returns>String view of value</returns>
        public static string ToStringView(this int argument)
        {
            IntegerToStringViewConvertor convertor;
            convertor = new IntegerToStringViewConvertor(argument);
            return convertor.ToStringView();
        }

        /// <summary>
        /// Converts argument to string view
        /// </summary>
        /// <param name="argument">Value to convert</param>
        /// <returns>String view of value</returns>
        public static string ToStringView(this ushort argument)
        {
            IntegerToStringViewConvertor convertor;
            convertor = new IntegerToStringViewConvertor(argument);
            return convertor.ToStringView();
        }

        /// <summary>
        /// Converts argument to string view
        /// </summary>
        /// <param name="argument">Value to convert</param>
        /// <returns>String view of value</returns>
        public static string ToStringView(this short argument)
        {
            IntegerToStringViewConvertor convertor;
            convertor = new IntegerToStringViewConvertor(argument);
            return convertor.ToStringView();
        }

        /// <summary>
        /// Converts argument to string view
        /// </summary>
        /// <param name="argument">Value to convert</param>
        /// <returns>String view of value</returns>
        public static string ToStringView(this byte argument)
        {
            IntegerToStringViewConvertor convertor;
            convertor = new IntegerToStringViewConvertor(argument);
            return convertor.ToStringView();
        }

        /// <summary>
        /// Converts argument to string view
        /// </summary>
        /// <param name="argument">Value to convert</param>
        /// <returns>String view of value</returns>
        public static string ToStringView(this sbyte argument)
        {
            IntegerToStringViewConvertor convertor;
            convertor = new IntegerToStringViewConvertor(argument);
            return convertor.ToStringView();
        }
    }
}
