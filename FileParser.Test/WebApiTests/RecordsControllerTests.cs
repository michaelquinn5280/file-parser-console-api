using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using FileParser.Domain;
using FileParser.Domain.Entities;
using FileParser.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileParser.Test.WebApiTests
{
    /// <summary>
    /// Summary description for RecordsControllerTests
    /// </summary>
    [TestClass]
    public class RecordsControllerTests
    {
        /// <summary>
        /// Mock Person
        /// </summary>
        private Person _person;

        /// <summary>
        /// Mock People
        /// </summary>
        private List<Person> _people;

        /// <summary>
        /// Person Service
        /// </summary>
        private IPersonService _personService;
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

        private RecordsController _controller;

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
            _people = Helpers.MockPersonHelper.GetMockPeople();
            _personService = new PersonService(_people);
            _controller = new RecordsController(_personService)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        /// <summary>
        /// Get Records Ordered By Gender And Last Name
        /// </summary>
        /// <returns>People</returns>
        [TestMethod]
        public void GetRecordsOrderedByGenderAndLastName()
        {
            var expectedResponse =
                "[{\"LastName\":\"Jones\",\"FirstName\":\"Jane\",\"Gender\":\"Female\",\"FavoriteColor\":\"Blue\",\"DateOfBirth\":\"10/1/1984\"},{\"LastName\":\"Powell\",\"FirstName\":\"Allison\",\"Gender\":\"Female\",\"FavoriteColor\":\"Green\",\"DateOfBirth\":\"2/15/1975\"},{\"LastName\":\"Rogers\",\"FirstName\":\"Mick\",\"Gender\":\"Male\",\"FavoriteColor\":\"Green\",\"DateOfBirth\":\"2/15/1950\"},{\"LastName\":\"Smith\",\"FirstName\":\"John\",\"Gender\":\"Male\",\"FavoriteColor\":\"Blue\",\"DateOfBirth\":\"1/21/1980\"},{\"LastName\":\"West\",\"FirstName\":\"Jeff\",\"Gender\":\"Male\",\"FavoriteColor\":\"Red\",\"DateOfBirth\":\"12/3/1970\"}]";

            var response = _controller.GetRecordsOrderedByGenderAndLastName().ExecuteAsync(new CancellationToken()).Result;
            Assert.IsTrue(response.IsSuccessStatusCode);

            var result = response.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResponse, result);
        }

        /// <summary>
        /// Get Records Ordered By Birth Date
        /// </summary>
        /// <returns>Records</returns>
        [TestMethod]
        public void GetRecordsOrderedByBirthDate()
        {
            var expectedResponse = "[{\"LastName\":\"Jones\",\"FirstName\":\"Jane\",\"Gender\":\"Female\",\"FavoriteColor\":\"Blue\",\"DateOfBirth\":\"10/1/1984\"},{\"LastName\":\"Powell\",\"FirstName\":\"Allison\",\"Gender\":\"Female\",\"FavoriteColor\":\"Green\",\"DateOfBirth\":\"2/15/1975\"},{\"LastName\":\"Rogers\",\"FirstName\":\"Mick\",\"Gender\":\"Male\",\"FavoriteColor\":\"Green\",\"DateOfBirth\":\"2/15/1950\"},{\"LastName\":\"Smith\",\"FirstName\":\"John\",\"Gender\":\"Male\",\"FavoriteColor\":\"Blue\",\"DateOfBirth\":\"1/21/1980\"},{\"LastName\":\"West\",\"FirstName\":\"Jeff\",\"Gender\":\"Male\",\"FavoriteColor\":\"Red\",\"DateOfBirth\":\"12/3/1970\"}]";
            var response = _controller.GetRecordsOrderedByGenderAndLastName().ExecuteAsync(new CancellationToken()).Result;
            Assert.IsTrue(response.IsSuccessStatusCode);

            var result = response.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResponse, result);
        }

        /// <summary>
        /// Get Records Ordered By Last Name
        /// </summary>
        /// <returns>Records</returns>
        [TestMethod]
        public void GetRecordsOrderedByLastName()
        {
            var expectedResponse = "[{\"LastName\":\"West\",\"FirstName\":\"Jeff\",\"Gender\":\"Male\",\"FavoriteColor\":\"Red\",\"DateOfBirth\":\"1970-12-03T00:00:00\"},{\"LastName\":\"Smith\",\"FirstName\":\"John\",\"Gender\":\"Male\",\"FavoriteColor\":\"Blue\",\"DateOfBirth\":\"1980-01-21T00:00:00\"},{\"LastName\":\"Rogers\",\"FirstName\":\"Mick\",\"Gender\":\"Male\",\"FavoriteColor\":\"Green\",\"DateOfBirth\":\"1950-02-15T00:00:00\"},{\"LastName\":\"Powell\",\"FirstName\":\"Allison\",\"Gender\":\"Female\",\"FavoriteColor\":\"Green\",\"DateOfBirth\":\"1975-02-15T00:00:00\"},{\"LastName\":\"Jones\",\"FirstName\":\"Jane\",\"Gender\":\"Female\",\"FavoriteColor\":\"Blue\",\"DateOfBirth\":\"1984-10-01T00:00:00\"}]";
            var response = _controller.GetRecordsOrderedByLastName().ExecuteAsync(new CancellationToken()).Result;
            Assert.IsTrue(response.IsSuccessStatusCode);

            var result = response.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResponse, result);
        }

        /// <summary>
        /// Add Person Record with Comma Delimited String
        /// </summary>
        /// <returns>Success Indicator</returns>
        [TestMethod]
        public void AddPersonRecordCommaString()
        {
            var expectedResponse = "[{\"LastName\":\"West\",\"FirstName\":\"Jeff\",\"Gender\":\"Male\",\"FavoriteColor\":\"Red\",\"DateOfBirth\":\"1970-12-03T00:00:00\"},{\"LastName\":\"Smith\",\"FirstName\":\"John\",\"Gender\":\"Male\",\"FavoriteColor\":\"Blue\",\"DateOfBirth\":\"1980-01-21T00:00:00\"},{\"LastName\":\"Rogers\",\"FirstName\":\"Mick\",\"Gender\":\"Male\",\"FavoriteColor\":\"Green\",\"DateOfBirth\":\"1950-02-15T00:00:00\"},{\"LastName\":\"Powell\",\"FirstName\":\"Allison\",\"Gender\":\"Female\",\"FavoriteColor\":\"Green\",\"DateOfBirth\":\"1975-02-15T00:00:00\"},{\"LastName\":\"King\",\"FirstName\":\"Robert\",\"Gender\":\"Male\",\"FavoriteColor\":\"Blue\",\"DateOfBirth\":\"1960-05-29T00:00:00\"},{\"LastName\":\"Jones\",\"FirstName\":\"Jane\",\"Gender\":\"Female\",\"FavoriteColor\":\"Blue\",\"DateOfBirth\":\"1984-10-01T00:00:00\"}]";
            var response = _controller.AddPersonRecord(_commaDelimitedLine).ExecuteAsync(new CancellationToken()).Result;
            Assert.IsTrue(response.IsSuccessStatusCode);

            response = _controller.GetRecordsOrderedByLastName().ExecuteAsync(new CancellationToken()).Result;
            Assert.IsTrue(response.IsSuccessStatusCode);

            var result = response.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResponse, result);
        }

        /// <summary>
        /// Add Person Record with Pipe Delimited String
        /// </summary>
        /// <returns>Success Indicator</returns>
        [TestMethod]
        public void AddPersonRecordPipeString()
        {
            var expectedResponse = "[{\"LastName\":\"West\",\"FirstName\":\"Jeff\",\"Gender\":\"Male\",\"FavoriteColor\":\"Red\",\"DateOfBirth\":\"1970-12-03T00:00:00\"},{\"LastName\":\"Smith\",\"FirstName\":\"John\",\"Gender\":\"Male\",\"FavoriteColor\":\"Blue\",\"DateOfBirth\":\"1980-01-21T00:00:00\"},{\"LastName\":\"Rogers\",\"FirstName\":\"Mick\",\"Gender\":\"Male\",\"FavoriteColor\":\"Green\",\"DateOfBirth\":\"1950-02-15T00:00:00\"},{\"LastName\":\"Powell\",\"FirstName\":\"Allison\",\"Gender\":\"Female\",\"FavoriteColor\":\"Green\",\"DateOfBirth\":\"1975-02-15T00:00:00\"},{\"LastName\":\"King\",\"FirstName\":\"Robert\",\"Gender\":\"Male\",\"FavoriteColor\":\"Blue\",\"DateOfBirth\":\"1960-05-29T00:00:00\"},{\"LastName\":\"Jones\",\"FirstName\":\"Jane\",\"Gender\":\"Female\",\"FavoriteColor\":\"Blue\",\"DateOfBirth\":\"1984-10-01T00:00:00\"}]";
            var response = _controller.AddPersonRecord(_pipeDelimitedLine).ExecuteAsync(new CancellationToken()).Result;
            Assert.IsTrue(response.IsSuccessStatusCode);

            response = _controller.GetRecordsOrderedByLastName().ExecuteAsync(new CancellationToken()).Result;
            Assert.IsTrue(response.IsSuccessStatusCode);

            var result = response.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResponse, result);
        }

        /// <summary>
        /// Add Person Record with Whitespace Delimited String
        /// </summary>
        /// <returns>Success Indicator</returns>
        [TestMethod]
        public void AddPersonRecordWhitespaceString()
        {
            var expectedResponse = "[{\"LastName\":\"West\",\"FirstName\":\"Jeff\",\"Gender\":\"Male\",\"FavoriteColor\":\"Red\",\"DateOfBirth\":\"1970-12-03T00:00:00\"},{\"LastName\":\"Smith\",\"FirstName\":\"John\",\"Gender\":\"Male\",\"FavoriteColor\":\"Blue\",\"DateOfBirth\":\"1980-01-21T00:00:00\"},{\"LastName\":\"Rogers\",\"FirstName\":\"Mick\",\"Gender\":\"Male\",\"FavoriteColor\":\"Green\",\"DateOfBirth\":\"1950-02-15T00:00:00\"},{\"LastName\":\"Powell\",\"FirstName\":\"Allison\",\"Gender\":\"Female\",\"FavoriteColor\":\"Green\",\"DateOfBirth\":\"1975-02-15T00:00:00\"},{\"LastName\":\"King\",\"FirstName\":\"Robert\",\"Gender\":\"Male\",\"FavoriteColor\":\"Blue\",\"DateOfBirth\":\"1960-05-29T00:00:00\"},{\"LastName\":\"Jones\",\"FirstName\":\"Jane\",\"Gender\":\"Female\",\"FavoriteColor\":\"Blue\",\"DateOfBirth\":\"1984-10-01T00:00:00\"}]";
            var response = _controller.AddPersonRecord(_whitespaceDelimitedLine).ExecuteAsync(new CancellationToken()).Result;
            Assert.IsTrue(response.IsSuccessStatusCode);

            response = _controller.GetRecordsOrderedByLastName().ExecuteAsync(new CancellationToken()).Result;
            Assert.IsTrue(response.IsSuccessStatusCode);

            var result = response.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResponse, result);
        }

        /// <summary>
        /// Tear Down
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            _commaDelimitedLine = null;
            _pipeDelimitedLine = null;
            _whitespaceDelimitedLine = null;
            _person = null;
            _people = null;
            _personService = null;
            _controller = null;
        }
    }
}
