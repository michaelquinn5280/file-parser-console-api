using System.Collections.Generic;
using FileParser.Domain.Entities;

namespace FileParser.Domain
{
    public interface IPersonService
    {
        /// <summary>
        /// Get People
        /// </summary>
        /// <returns>People</returns>
        IEnumerable<Person> GetPeople();

        /// <summary>
        /// Get People Ordered By Gender (Female 1st), then last name ascending
        /// </summary>
        /// <returns>Sorted People</returns>
        IEnumerable<Person> GetPeopleOrderedByGenderAndLastName();

        /// <summary>
        /// Get People Ordered By Birth Date Ascending
        /// </summary>
        /// <returns>Sorted People</returns>
        IEnumerable<Person> GetPeopleOrderedByBirthDate();

        /// <summary>
        /// Get People Ordered By LastName descending.
        /// </summary>
        /// <returns>Sorted People</returns>
        IEnumerable<Person> GetPeopleOrderedByLastName();

        /// <summary>
        /// Add a person
        /// </summary>
        /// <param name="person">Person</param>
        void AddPerson(Person person);
    }
}