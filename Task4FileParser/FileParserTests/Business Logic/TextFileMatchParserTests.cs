namespace FileParser.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Diagnostics;
    using System.IO;

    [TestClass]
    public class TextFileMatchParserTests
    {
        [TestMethod]
        public void Parse_FindsEightMatches()
        {
            // Arrange
            Debug.WriteLine(Directory.GetCurrentDirectory());
            string targetFile = Directory.GetCurrentDirectory() + @"\TestFiles\Full.txt";
            string searchValue = "Sample";
            TextFileMatchParser parser = new TextFileMatchParser(targetFile, searchValue);
            int expected = 8;
            int actual;

            // Act
            actual = parser.Parse();
            parser.Dispose();

            // Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void Parse_FindsZeroMatches()
        {
            // Arrange
            Debug.WriteLine(Directory.GetCurrentDirectory());
            string targetFile = Directory.GetCurrentDirectory() + @"\TestFiles\Full.txt";
            string searchValue = "sample";
            TextFileMatchParser parser = new TextFileMatchParser(targetFile, searchValue);
            int expected = 0;
            int actual;

            // Act
            actual = parser.Parse();
            parser.Dispose();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parse_ThrowsFileToParseNotFoundException()
        {
            // Arrange
            string targetFile = Directory.GetCurrentDirectory() + @"\TestFiles\NotExistFile.txt";
            string searchValue = "Sample";
            TextFileMatchParser parser = new TextFileMatchParser(targetFile, searchValue);

            // Act
            // Assert
            Assert.ThrowsException<FileToParseNotFoundException>(() => parser.Parse());
            
        }

        [TestMethod]
        public void Parse_ThrowsFileIsEmptyException()
        {
            // Arrange
            string targetFile = Directory.GetCurrentDirectory() + @"\TestFiles\Empty.txt";
            string searchValue = "Sample";
            TextFileMatchParser parser = new TextFileMatchParser(targetFile, searchValue);

            // Act
            // Assert
            Assert.ThrowsException<FileIsEmptyException>(() => parser.Parse());

        }
    }
}