using System;
using System.Collections.Generic;
using FileParser.Domain.Entities;

namespace FileParser.Test.Helpers
{
    /// <summary>
    /// Helper class to generate mock data
    /// </summary>
    public static class MockPersonHelper
    {
        /// <summary>
        /// Get Signle Mock Person
        /// </summary>
        /// <returns></returns>
        public static Person GetMockPerson()
        {
            return new Person
            {
                LastName = "King",
                FirstName = "Robert",
                Gender = "Male",
                FavoriteColor = "Blue",
                DateOfBirth = new DateTime(1960, 05, 29)
            };
        }

        /// <summary>
        /// Get Mock People
        /// </summary>
        /// <returns></returns>
        public static List<Person> GetMockPeople()
        {
            return new List<Person>
            {
                new Person
                {
                    LastName = "Smith",
                    FirstName = "John",
                    Gender = "Male",
                    FavoriteColor = "Blue",
                    DateOfBirth = new DateTime(1980, 1, 21)
                },
                new Person
                {
                    LastName = "Jones",
                    FirstName = "Jane",
                    Gender = "Female",
                    FavoriteColor = "Blue",
                    DateOfBirth = new DateTime(1984, 10, 1)
                },
                new Person
                {
                    LastName = "Rogers",
                    FirstName = "Mick",
                    Gender = "Male",
                    FavoriteColor = "Green",
                    DateOfBirth = new DateTime(1950, 2, 15)
                },
                new Person
                {
                    LastName = "West",
                    FirstName = "Jeff",
                    Gender = "Male",
                    FavoriteColor = "Red",
                    DateOfBirth = new DateTime(1970, 12, 3)
                },
                new Person
                {
                    LastName = "Powell",
                    FirstName = "Allison",
                    Gender = "Female",
                    FavoriteColor = "Green",
                    DateOfBirth = new DateTime(1975, 2, 15)
                },
            };
        }
    }
}
