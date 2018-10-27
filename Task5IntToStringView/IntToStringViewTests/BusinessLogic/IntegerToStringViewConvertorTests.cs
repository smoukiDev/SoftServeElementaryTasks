using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntToStringView.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntToStringView.BusinessLogic.Tests
{
    [TestClass]
    public class IntegerToStringViewConvertorTests
    {
        [TestMethod]
        public void ToStringViewTest_ConvertNeggativeValueCorrectly()
        {
            // Arrange
            long convertedValue = -9_223_372_036_854_775_807;
            IntegerToStringViewConvertor convertor;
            convertor = new IntegerToStringViewConvertor(convertedValue);

            string actual;

            StringBuilder result = new StringBuilder(250);
            result.Append("minus nine quintillion ");
            result.Append("two hundred twenty three quadrillion ");
            result.Append("three hundred seventy two trillion ");
            result.Append("thirty six billion ");
            result.Append("eight hundred fifty four million ");
            result.Append("seven hundred seventy five thousand ");
            result.Append("eight hundred seven");
            string expected = result.ToString();

            // Act            
            actual = convertor.ToStringView();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToStringViewTest_ConvertPositiveValueCorrectly()
        {
            // Arrange
            ulong convertedValue = 18_223_372_036_854_775_807;
            IntegerToStringViewConvertor convertor;
            convertor = new IntegerToStringViewConvertor(convertedValue);

            string actual;

            StringBuilder result = new StringBuilder(250);
            result.Append("eighteen quintillion ");
            result.Append("two hundred twenty three quadrillion ");
            result.Append("three hundred seventy two trillion ");
            result.Append("thirty six billion ");
            result.Append("eight hundred fifty four million ");
            result.Append("seven hundred seventy five thousand ");
            result.Append("eight hundred seven");
            string expected = result.ToString();

            // Act            
            actual = convertor.ToStringView();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}