using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using FileParser.Console;
using FileParser.Domain;
using FileParser.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileParser.Test.ConsoleTests
{
    /// <summary>
    /// Summary description for ProgramTests
    /// </summary>
    [TestClass]
    [DeploymentItem("Helpers\\TestFiles\\comma.txt")]
    [DeploymentItem("Helpers\\TestFiles\\pipe.txt")]
    [DeploymentItem("Helpers\\TestFiles\\whitespace.txt")]
    public class ProgramTests
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
            _people = Helpers.MockPersonHelper.GetMockPeople();
            _personService = new PersonService(_people);
            _fileService = new FileService(_personService);
        }

        /// <summary>
        /// Run Main Default Test
        /// </summary>
        [TestMethod]
        public void RunMain()
        {
            using (StringWriter sw = new StringWriter())
            {
                System.Console.SetOut(sw);
                Program.Main(new string[] { });
                string expected = $"{Environment.NewLine}Available Options:";
                var result = sw.ToString();
                Assert.IsNotNull(result);
                Assert.IsTrue(result.StartsWith(expected));
            }
        }

        /// <summary>
        /// Test loading of commandline input filepath args
        /// </summary>
        [TestMethod]
        public void LoadFilesFromCommandArgs()
        {
            using (StringWriter sw = new StringWriter())
            {
                System.Console.SetOut(sw);
                Program.Main(new string[] { "comma.txt", "pipe.txt", "whitespace.txt" });
                string expected = string.Format("{0}{1}{0}{1}{0}", "File loaded successfully.", Environment.NewLine);
                var result = sw.ToString();
                Assert.IsNotNull(result);
                Assert.IsTrue(result.StartsWith(expected));
            }
        }

        /// <summary>
        /// View Option 1 Test
        /// </summary>
        [TestMethod]
        public void ViewOption1()
        {
            var program = new Program(_personService, _fileService); //unused private variable triggers DI with instantiation
            using (StringWriter sw = new StringWriter())
            {
                System.Console.SetOut(sw);
                using (StringReader sr = new StringReader("1"))
                {
                    System.Console.SetIn(sr);
                    Program.Main(new string[] { });
                    string expected = string.Format("{0}Available Options:{0}{0}To load files: enter /load <file_path>{0}{0}Enter 1 to view data sorted by gender (females before males) then by last name ascending.{0}{0}Enter 2 to view data sorted by birth date, ascending.{0}{0}Enter 3 to view data sorted by last name, descending.{0}{0}Enter /quit to end session.{0}{0}Sorted by gender (females before males) then by last name ascending.{0}Last Name First Name Gender Favorite Color Date of Birth{0}Jones Jane Female Blue 10/1/1984{0}Powell Allison Female Green 2/15/1975{0}Rogers Mick Male Green 2/15/1950{0}Smith John Male Blue 1/21/1980{0}West Jeff Male Red 12/3/1970{0}", Environment.NewLine);
                    var results = sw.ToString();

                    Assert.IsNotNull(results);
                    Assert.AreEqual(expected, results);
                }
            }
            program = null;
        }

        /// <summary>
        /// View Option 2 Test
        /// </summary>
        [TestMethod]
        public void ViewOption2()
        {
            var program = new Program(_personService, _fileService); //unused private variable triggers DI with instantiation
            using (StringWriter sw = new StringWriter())
            {
                System.Console.SetOut(sw);
                using (StringReader sr = new StringReader("2"))
                {
                    System.Console.SetIn(sr);
                    Program.Main(new string[] { });
                    string expected = string.Format("{0}Available Options:{0}{0}To load files: enter /load <file_path>{0}{0}Enter 1 to view data sorted by gender (females before males) then by last name ascending.{0}{0}Enter 2 to view data sorted by birth date, ascending.{0}{0}Enter 3 to view data sorted by last name, descending.{0}{0}Enter /quit to end session.{0}{0}Sorted by birth date, ascending.{0}Last Name First Name Gender Favorite Color Date of Birth{0}Rogers Mick Male Green 2/15/1950{0}West Jeff Male Red 12/3/1970{0}Powell Allison Female Green 2/15/1975{0}Smith John Male Blue 1/21/1980{0}Jones Jane Female Blue 10/1/1984{0}", Environment.NewLine);
                    var results = sw.ToString();

                    Assert.IsNotNull(results);
                    Assert.AreEqual(expected, results);
                }
            }
            program = null;
        }

        /// <summary>
        /// View Option 3 Test
        /// </summary>
        [TestMethod]
        public void ViewOption3()
        {
            var program = new Program(_personService, _fileService); //unused private variable triggers DI with instantiation
            using (StringWriter sw = new StringWriter())
            {
                System.Console.SetOut(sw);
                using (StringReader sr = new StringReader("3"))
                {
                    System.Console.SetIn(sr);
                    Program.Main(new string[] { });
                    string expected = string.Format("{0}Available Options:{0}{0}To load files: enter /load <file_path>{0}{0}Enter 1 to view data sorted by gender (females before males) then by last name ascending.{0}{0}Enter 2 to view data sorted by birth date, ascending.{0}{0}Enter 3 to view data sorted by last name, descending.{0}{0}Enter /quit to end session.{0}{0}Sorted by last name, descending.{0}Last Name First Name Gender Favorite Color Date of Birth{0}West Jeff Male Red 12/3/1970{0}Smith John Male Blue 1/21/1980{0}Rogers Mick Male Green 2/15/1950{0}Powell Allison Female Green 2/15/1975{0}Jones Jane Female Blue 10/1/1984{0}", Environment.NewLine);
                    var results = sw.ToString();

                    Assert.IsNotNull(results);
                    Assert.AreEqual(expected, results);
                }
            }
            program = null;
        }

        /// <summary>
        /// Test Cleanup
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            _people = null;
            _personService = null;
            _fileService = null;
        }
    }
}
