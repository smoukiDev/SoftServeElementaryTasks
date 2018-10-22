using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Tests
{
    [TestClass]
    public class TextFileMatchParserTests
    {
        [TestMethod]
        [DeploymentItem(@"TestFiles\FileForParserTests.txt")]
        [DataRow("Sample", 9)]
        public void ParseTest_ReturnMatchesCorrectly(string searchValue, int matches)
        {
            // Arrange
            TextFileMatchParser parser = new TextFileMatchParser("FileForParserTests.txt", searchValue);
            int expected = matches;
            int actual;

            // Act
            actual = parser.Parse();
            parser.Dispose();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}