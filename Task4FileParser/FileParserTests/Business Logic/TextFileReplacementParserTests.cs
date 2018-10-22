using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FileParser.Tests
{
    [TestClass]
    public class TextFileReplacementParserTests
    {
        [TestMethod]
        [DeploymentItem(@"TestFiles\FileForParserTests.txt")]
        [DataRow("Sample","Examples", 9)]
        public void ParseTest_ReturnMatchesCorrectly(string searchValue, string replaceValue, int matches)
        {
            // Arrange
            Debug.WriteLine(Directory.GetCurrentDirectory());

            string targetFilePath = Directory.GetCurrentDirectory() + @"\TestFiles\FileForParserTests.txt";
            
            TextFileReplacementParser parser = new TextFileReplacementParser(targetFilePath, searchValue, replaceValue);
            int expected = matches;
            int actual;

            // Act
            actual = parser.Parse();
            File.Delete(parser.FileCopy);
            parser.Dispose();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}