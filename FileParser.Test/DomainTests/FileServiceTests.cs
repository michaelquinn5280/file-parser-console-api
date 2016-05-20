using System.Collections.Generic;
using FileParser.Domain;
using FileParser.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileParser.Test.DomainTests
{
    /// <summary>
    /// File Service Tests
    /// </summary>
    [TestClass]
    [DeploymentItem("Helpers\\TestFiles\\comma.txt")]
    [DeploymentItem("Helpers\\TestFiles\\pipe.txt")]
    [DeploymentItem("Helpers\\TestFiles\\whitespace.txt")]
    public class FileServiceTests
    {
        /// <summary>
        /// People
        /// </summary>
        private List<Person> _people;

        /// <summary>
        /// Person Service
        /// </summary>
        private IPersonService _personService;

        /// <summary>
        /// File Service
        /// </summary>
        private IFileService _fileService;

        /// <summary>
        /// Build Up
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _people = new List<Person>();
            _personService = new PersonService(_people);
            _fileService = new FileService(_personService);
        }

        /// <summary>
        /// Test Load File
        /// </summary>
        [TestMethod]
        public void LoadFile()
        {
            var result = _fileService.LoadFile(@"comma.txt");
            Assert.AreEqual(true, result);
            Assert.AreEqual(3, _people.Count);

            result = _fileService.LoadFile(@"pipe.txt");
            Assert.AreEqual(true, result);
            Assert.AreEqual(6, _people.Count);

            result = _fileService.LoadFile(@"whitespace.txt");
            Assert.AreEqual(true, result);
            Assert.AreEqual(9, _people.Count);
        }

        /// <summary>
        /// Test Cleanup
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            _fileService = null;
            _personService = null;
            _people = null;
        }
    }
}
