// <copyright file="IntegerToStringViewConvertor.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace IntToStringView.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Represent convertor of any integer number
    /// to string reprecentation by words
    /// </summary>
    public class IntegerToStringViewConvertor : TypeToStringViewConvertor<ulong>
    {
        /// <summary>
        /// Dictionary with units string view.
        /// </summary>
        private static readonly Dictionary<int, string> Units =
            new Dictionary<int, string>()
            {
                { 0, "zero" },
                { 1, "one" },
                { 2, "two" },
                { 3, "three" },
                { 4, "four" },
                { 5, "five" },
                { 6, "six" },
                { 7, "seven" },
                { 8, "eight" },
                { 9, "nine" },
                { 10, "ten" },
                { 11, "eleven" },
                { 12, "twelve" },
                { 13, "thirteen" },
                { 14, "fourteen" },
                { 15, "fifteen" },
                { 16, "sixteen" },
                { 17, "seventeen" },
                { 18, "eighteen" },
                { 19, "nineteen" }
            };

        /// <summary>
        /// Dictionary with tens string view.
        /// </summary>
        private static readonly Dictionary<int, string> Tens =
            new Dictionary<int, string>()
            {
                { 2, "twenty" },
                { 3, "thirty" },
                { 4, "forty" },
                { 5, "fifty" },
                { 6, "sixty" },
                { 7, "seventy" },
                { 8, "eighty" },
                { 9, "ninety" }
            };

        /// <summary>
        /// Dictionary with unique keywords like thousand, million etc.
        /// </summary>
        private static readonly Dictionary<int, string> Keywords =
            new Dictionary<int, string>()
            {
                { 0, string.Empty },
                { 1, "thousand" },
                { 2, "million" },
                { 3, "billion" },
                { 4, "trillion" },
                { 5, "quadrillion" },
                { 6, "quintillion" },
            };

        private const byte STRING_MAX_SIZE = 250;
        private const string MINUS_KEYWORD = "minus";

        private bool isNegative;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerToStringViewConvertor"/> class.
        /// </summary>
        /// <param name="argument">Value to convert</param>
        public IntegerToStringViewConvertor(ulong argument)
            : base(argument)
        {
            this.isNegative = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerToStringViewConvertor"/> class.
        /// </summary>
        /// <param name="argument">Value to convert</param>
        public IntegerToStringViewConvertor(long argument)
            : base(0UL)
        {
            if (argument < 0)
            {
                argument *= -1;
                this.isNegative = true;
                this.BaseConvertedValue = (ulong)argument;
            }
            else
            {
                this.isNegative = false;
                this.BaseConvertedValue = (ulong)argument;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerToStringViewConvertor"/> class.
        /// </summary>
        /// <param name="argument">Value to convert</param>
        public IntegerToStringViewConvertor(uint argument)
            : base(argument)
        {
            this.isNegative = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerToStringViewConvertor"/> class.
        /// </summary>
        /// <param name="argument">Value to convert</param>
        public IntegerToStringViewConvertor(int argument)
            : base(0UL)
        {
            if (argument < 0)
            {
                argument *= -1;
                this.isNegative = true;
                this.BaseConvertedValue = (ulong)argument;
            }
            else
            {
                this.isNegative = false;
                this.BaseConvertedValue = (ulong)argument;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerToStringViewConvertor"/> class.
        /// </summary>
        /// <param name="argument">Value to convert</param>
        public IntegerToStringViewConvertor(ushort argument)
            : base(argument)
        {
            this.isNegative = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerToStringViewConvertor"/> class.
        /// </summary>
        /// <param name="argument">Value to convert</param>
        public IntegerToStringViewConvertor(short argument)
            : base(0UL)
        {
            if (argument < 0)
            {
                argument *= -1;
                this.isNegative = true;
                this.BaseConvertedValue = (ulong)argument;
            }
            else
            {
                this.isNegative = false;
                this.BaseConvertedValue = (ulong)argument;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerToStringViewConvertor"/> class.
        /// </summary>
        /// <param name="argument">Value to convert</param>
        public IntegerToStringViewConvertor(byte argument)
            : base(argument)
        {
            this.isNegative = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerToStringViewConvertor"/> class.
        /// </summary>
        /// <param name="argument">Value to convert</param>
        public IntegerToStringViewConvertor(sbyte argument)
            : base(0UL)
        {
            if (argument < 0)
            {
                argument *= -1;
                this.isNegative = true;
                this.BaseConvertedValue = (ulong)argument;
            }
            else
            {
                this.isNegative = false;
                this.BaseConvertedValue = (ulong)argument;
            }
        }

        /// <summary>
        /// Converts value specified base converted value
        /// into string view
        /// </summary>
        /// <returns>String view of integer value</returns>
        public override string ToStringView()
        {
            ulong number = this.BaseConvertedValue;

            StringBuilder result = new StringBuilder(STRING_MAX_SIZE);

            if (number == 0)
            {
                result.Append($"{Units[0]}");
            }
            else
            {
                try
                {
                    for (int index = 0; number != 0; ++index)
                    {
                        ulong temp = number % 1000;
                        number /= 1000;
                        if (temp != 0)
                        {
                            result.Insert(0, $"{ConvertBaseValuePart(temp)} {Keywords[index]} ");
                        }
                    }

                    if (this.isNegative)
                    {
                        result.Insert(0, $"{MINUS_KEYWORD} ");
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw;
                }
            }

            return result.ToString().Trim();
        }

        /// <summary>
        /// Method for converting part of
        /// huge base converted value
        /// </summary>
        /// <param name="number">
        /// Value from 0 to 999
        /// </param>
        /// <returns>String view of number</returns>
        private static string ConvertBaseValuePart(ulong number)
        {
            StringBuilder result = new StringBuilder(string.Empty);

            if (number >= 0 && number <= 999)
            {
                if (number != 0)
                {
                    int hundreds_count = (int)number / 100;
                    int dozens_count = (int)(number % 100) / 10;
                    int units_count = (int)number % 10;
                    if (hundreds_count > 0)
                    {
                        result.Append($"{Units[hundreds_count]} hundred");
                    }

                    if (number % 100 >= 1 && number % 100 <= 19)
                    {
                        result.Append($" {Units[(int)number % 100]}");
                    }
                    else if (dozens_count > 1)
                    {
                        if (result.Length != 0)
                        {
                            result.Append($" ");
                        }

                        result.Append(Tens[dozens_count]);
                        if (units_count != 0)
                        {
                            result.Append($" {Units[units_count]}");
                        }
                    }
                }
            }

            return result.ToString().Trim();
        }
    }
}
