namespace FileParser.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Diagnostics;
    using System.IO;

    [TestClass]
    public class TextFileReplacementParserTests
    {
        [TestMethod]
        public void Parse_ReplacesEightMatchesAndWritesInCopyFile()
        {
            // Arrange
            Debug.WriteLine(Directory.GetCurrentDirectory());
            string targetFile = Directory.GetCurrentDirectory() + @"\TestFiles\Full.txt";
            string searchValue = "Sample";
            string replaceValue = "Example";
            bool mode = false;
            TextFileReplacementParser parser = new TextFileReplacementParser(targetFile, searchValue, replaceValue, mode);
            int expected = 8;
            int actual;

            // Act
            actual = parser.Parse();
            // Delete File Copy with replacements
            File.Delete(parser.FileCopy);
            parser.Dispose();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parse_ReplacesEightMatchesAndWritesInOriginalFile()
        {
            // Arrange
            Debug.WriteLine(Directory.GetCurrentDirectory());
            string targetFile = Directory.GetCurrentDirectory() + @"\TestFiles\Full.txt";
            string searchValue = "Sample";
            string replaceValue = "Example";
            bool mode = true;
            TextFileReplacementParser parser = new TextFileReplacementParser(targetFile, searchValue, replaceValue, mode);
            int expected = 8;
            int actual;

            // Act
            actual = parser.Parse();
            parser.Dispose();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parse_ReplacesNothing()
        {
            // Arrange
            Debug.WriteLine(Directory.GetCurrentDirectory());
            string targetFile = Directory.GetCurrentDirectory() + @"\TestFiles\Full.txt";
            string searchValue = "sample";
            string relaceValue = "example";
            bool mode = true;
            TextFileReplacementParser parser = new TextFileReplacementParser(targetFile, searchValue, relaceValue, mode);
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
            string replaceValue = "Example";
            bool mode = true;

            TextFileReplacementParser parser = new TextFileReplacementParser(targetFile, searchValue, replaceValue, mode);

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
            string replaceValue = "Example";
            bool mode = true;

            TextFileReplacementParser parser = new TextFileReplacementParser(targetFile, searchValue, replaceValue, mode);

            // Act
            // Assert
            Assert.ThrowsException<FileIsEmptyException>(() => parser.Parse());

        }
    }
}