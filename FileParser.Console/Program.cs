using System.Collections.Generic;
using System.Linq;
using FileParser.Domain;
using FileParser.Domain.Entities;

namespace FileParser.Console
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// People List injected into services to persist data in memory
        /// </summary>
        private static List<Person> _people;

        /// <summary>
        /// Person Service
        /// </summary>
        private static IPersonService _personService;

        /// <summary>
        /// File Service
        /// </summary>
        private static IFileService _fileService;

        /// <summary>
        /// DI Constructor
        /// </summary>
        /// <param name="personService">Person Service</param>
        /// <param name="fileService">File Service</param>
        public Program(IPersonService personService, IFileService fileService)
        {
            _personService = personService ?? new PersonService(_people);
            _fileService = fileService ?? new FileService(_personService);
        }
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args">Args - whitespace delimeted</param>
        public static void Main(string[] args)
        {
            _people = _people ?? new List<Person>();
            _personService = _personService ?? new PersonService(_people);
            _fileService = _fileService ?? new FileService(_personService);

            // load files if filepaths supplied as args on startup
            foreach (var arg in args)
                LoadFile(arg);

            PrintInstructions();

            AcceptInput();
        }

        /// <summary>
        /// Print Instructions
        /// </summary>
        public static void PrintInstructions()
        {
            System.Console.WriteLine("");
            System.Console.WriteLine("Available Options:");
            System.Console.WriteLine("");
            System.Console.WriteLine("To load files: enter /load <file_path>");
            System.Console.WriteLine("");
            System.Console.WriteLine("Enter 1 to view data sorted by gender (females before males) then by last name ascending.");
            System.Console.WriteLine("");
            System.Console.WriteLine("Enter 2 to view data sorted by birth date, ascending.");
            System.Console.WriteLine("");
            System.Console.WriteLine("Enter 3 to view data sorted by last name, descending.");
            System.Console.WriteLine("");
            System.Console.WriteLine("Enter /quit to end session.");
            System.Console.WriteLine("");
        }

        /// <summary>
        /// Accept Input From User
        /// </summary>
        public static void AcceptInput()
        {
            var quit = false;
            while (!quit)
            {
                var command = System.Console.ReadLine();
                if (command == null)
                    break;
                if (!string.IsNullOrWhiteSpace(command) && command.StartsWith("/load"))
                {
                    LoadFile(command.Replace("/load ", ""));
                }
                else
                {
                    switch (command)
                    {
                        case "1":
                            PrintResults(_personService.GetPeopleOrderedByGenderAndLastName().ToList(), @"Sorted by gender (females before males) then by last name ascending.");
                            break;

                        case "2":
                            PrintResults(_personService.GetPeopleOrderedByBirthDate().ToList(), @"Sorted by birth date, ascending.");
                            break;

                        case "3":
                            PrintResults(_personService.GetPeopleOrderedByLastName().ToList(), @"Sorted by last name, descending.");
                            break;

                        case "/quit":
                            quit = true;
                            break;

                        default:
                            System.Console.WriteLine("Unknown Command " + command);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Load File from file path provided
        /// </summary>
        /// <param name="filePath">Full file path</param>
        public static void LoadFile(string filePath)
        {
            var success = _fileService.LoadFile(filePath);
            System.Console.WriteLine(success ? "File loaded successfully." : "File load failed.");
        }

        /// <summary>
        /// Print Results Views
        /// </summary>
        /// <param name="people">List of People</param>
        /// <param name="message">Message</param>
        public static void PrintResults(List<Person> people, string message)
        {
            if (people.Any())
            {
                System.Console.WriteLine(message);
                System.Console.WriteLine("Last Name First Name Gender Favorite Color Date of Birth");
                people.ForEach(p =>
                {
                    System.Console.WriteLine($"{p.LastName} {p.FirstName} {p.Gender} {p.FavoriteColor} {p.DateOfBirth.ToShortDateString()}");
                });
            }
            else
                System.Console.WriteLine("No data available.");

        }
    }
}
