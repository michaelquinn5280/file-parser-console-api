using FileParser.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileParser.Test.DomainTests
{
    /// <summary>
    /// Parser Helper Tests
    /// </summary>
    [TestClass]
    public class ParserTests
    {
        /// <summary>
        /// Comma Delimited Line
        /// </summary>
        private string _commaDelimitedLine;

        /// <summary>
        /// Pipe Delimited Line
        /// </summary>
        private string _pipeDelimitedLine;

        /// <summary>
        /// Whitespace Delimited Line
        /// </summary>
        private string _whitespaceDelimitedLine;

        /// <summary>
        /// Mock Person
        /// </summary>
        private Person _person;

        /// <summary>
        /// Build Up
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _commaDelimitedLine = @"King,Robert,Male,Blue,1960-05-29";
            _pipeDelimitedLine = @"King|Robert|Male|Blue|1960-05-29";
            _whitespaceDelimitedLine = @"King Robert Male Blue 1960-05-29";
            _person = Helpers.MockPersonHelper.GetMockPerson();
        }

        /// <summary>
        /// Test Parser Parse Person
        /// </summary>
        [TestMethod]
        public void ParsePerson()
        {
            var result = Domain.Helpers.Parser.ParsePerson(_commaDelimitedLine, null);
            Assert.AreEqual(_person.FirstName, result.FirstName);
            Assert.AreEqual(_person.LastName, result.LastName);
            Assert.AreEqual(_person.Gender, result.Gender);
            Assert.AreEqual(_person.FavoriteColor, result.FavoriteColor);
            Assert.AreEqual(_person.DateOfBirth, result.DateOfBirth);

            result = Domain.Helpers.Parser.ParsePerson(_commaDelimitedLine, Constants.CommaDelimiter);
            Assert.AreEqual(_person.FirstName, result.FirstName);
            Assert.AreEqual(_person.LastName, result.LastName);
            Assert.AreEqual(_person.Gender, result.Gender);
            Assert.AreEqual(_person.FavoriteColor, result.FavoriteColor);
            Assert.AreEqual(_person.DateOfBirth, result.DateOfBirth);

            result = Domain.Helpers.Parser.ParsePerson(_pipeDelimitedLine, null);
            Assert.AreEqual(_person.FirstName, result.FirstName);
            Assert.AreEqual(_person.LastName, result.LastName);
            Assert.AreEqual(_person.Gender, result.Gender);
            Assert.AreEqual(_person.FavoriteColor, result.FavoriteColor);
            Assert.AreEqual(_person.DateOfBirth, result.DateOfBirth);

            result = Domain.Helpers.Parser.ParsePerson(_pipeDelimitedLine, Constants.PipeDelimiter);
            Assert.AreEqual(_person.FirstName, result.FirstName);
            Assert.AreEqual(_person.LastName, result.LastName);
            Assert.AreEqual(_person.Gender, result.Gender);
            Assert.AreEqual(_person.FavoriteColor, result.FavoriteColor);
            Assert.AreEqual(_person.DateOfBirth, result.DateOfBirth);

            result = Domain.Helpers.Parser.ParsePerson(_whitespaceDelimitedLine, null);
            Assert.AreEqual(_person.FirstName, result.FirstName);
            Assert.AreEqual(_person.LastName, result.LastName);
            Assert.AreEqual(_person.Gender, result.Gender);
            Assert.AreEqual(_person.FavoriteColor, result.FavoriteColor);
            Assert.AreEqual(_person.DateOfBirth, result.DateOfBirth);

            result = Domain.Helpers.Parser.ParsePerson(_whitespaceDelimitedLine, Constants.WhitespaceDelimiter);
            Assert.AreEqual(_person.FirstName, result.FirstName);
            Assert.AreEqual(_person.LastName, result.LastName);
            Assert.AreEqual(_person.Gender, result.Gender);
            Assert.AreEqual(_person.FavoriteColor, result.FavoriteColor);
            Assert.AreEqual(_person.DateOfBirth, result.DateOfBirth);
        }

        /// <summary>
        /// Test Parser Get Delimiter
        /// </summary>
        [TestMethod]
        public void GetDelimeter()
        {
            var result = Domain.Helpers.Parser.GetDelimeter(_commaDelimitedLine);
            Assert.AreEqual(Constants.CommaDelimiter, result);

            result = Domain.Helpers.Parser.GetDelimeter(_pipeDelimitedLine);
            Assert.AreEqual(Constants.PipeDelimiter, result);

            result = Domain.Helpers.Parser.GetDelimeter(_whitespaceDelimitedLine);
            Assert.AreEqual(Constants.WhitespaceDelimiter, result);
        }

        /// <summary>
        /// Test Cleanup
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            _commaDelimitedLine = null;
            _pipeDelimitedLine = null;
            _whitespaceDelimitedLine = null;
            _person = null;
        }
    }
}
