using System.Collections.Generic;
using System.Linq;
using FileParser.Domain.Entities;

namespace FileParser.Domain
{
    /// <summary>
    /// Person Service
    /// </summary>
    public class PersonService : IPersonService
    {
        /// <summary>
        /// People Data Source to simulate persistence
        /// </summary>
        private readonly List<Person> _people;

        /// <summary>
        /// DI Person Service
        /// Since no persistence exists, we must pass in
        /// </summary>
        /// <param name="people">People</param>
        public PersonService(List<Person> people)
        {
            _people = people ?? new List<Person>();
        }

        /// <summary>
        /// Get People
        /// </summary>
        /// <returns>People</returns>
        public IEnumerable<Person> GetPeople()
        {
            return _people.ToList();
        }

        /// <summary>
        /// Get People Ordered By Gender (Female 1st), then last name ascending
        /// </summary>
        /// <returns>Sorted People</returns>
        public IEnumerable<Person> GetPeopleOrderedByGenderAndLastName()
        {
            return _people.OrderBy(p => p.Gender).ThenBy(p => p.LastName);
        }

        /// <summary>
        /// Get People Ordered By Birth Date Ascending
        /// </summary>
        /// <returns>Sorted People</returns>
        public IEnumerable<Person> GetPeopleOrderedByBirthDate()
        {
            return _people.ToList().OrderBy(p=>p.DateOfBirth);
        }

        /// <summary>
        /// Get People Ordered By LastName descending.
        /// </summary>
        /// <returns>Sorted People</returns>
        public IEnumerable<Person> GetPeopleOrderedByLastName()
        {
            return _people.ToList().OrderByDescending(p => p.LastName);
        }

        /// <summary>
        /// Add a person
        /// </summary>
        /// <param name="person">Person</param>
        public void AddPerson(Person person)
        {
            _people.Add(person);
        }
    }
}
