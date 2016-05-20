using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using FileParser.Domain;
using FileParser.Domain.Entities;

namespace FileParser.Test.DomainTests
{
    /// <summary>
    /// Person Service Tests
    /// </summary>
    [TestClass]
    public class PersonServiceTests
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
        /// Build Up Test Context
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _person = Helpers.MockPersonHelper.GetMockPerson();
            _people = Helpers.MockPersonHelper.GetMockPeople();
            _personService = new PersonService(_people);
        }

        /// <summary>
        /// Test Add Person
        /// </summary>
        [TestMethod]
        public void AddPerson()
        {
            _personService.AddPerson(_person);
            var result = _personService.GetPeople().FirstOrDefault(p => p.LastName == "King");
            Assert.IsNotNull(result);
            Assert.AreEqual(_person, result);
        }

        /// <summary>
        /// Get People Ordered By Gender (Female 1st) And LastName Ascending
        /// </summary>
        [TestMethod]
        public void GetPeopleOrderedByGenderAndLastName()
        {
            var result = _personService.GetPeopleOrderedByGenderAndLastName().ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual("Jones", result.First().LastName);
            Assert.AreEqual("West", result.Last().LastName);
        }

        /// <summary>
        /// Get People Ordered By Birth Date Ascending
        /// </summary>
        [TestMethod]
        public void GetPeopleOrderedByBirthDate()
        {
            var result = _personService.GetPeopleOrderedByBirthDate().ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual("Rogers", result.First().LastName);
            Assert.AreEqual("Jones", result.Last().LastName);
        }

        /// <summary>
        /// Get People Ordered By LastName Ascending
        /// </summary>
        [TestMethod]
        public void GetPeopleOrderedByLastName()
        {
            var result = _personService.GetPeopleOrderedByLastName().ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual("West", result.First().LastName);
            Assert.AreEqual("Jones", result.Last().LastName);
        }

        /// <summary>
        /// Tear Down
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            _personService = null;
            _people = null;
            _person = null;
        }
    }
}
