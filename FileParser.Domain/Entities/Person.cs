using System;

namespace FileParser.Domain.Entities
{
    /// <summary>
    /// Person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Favorite Color
        /// </summary>
        public string FavoriteColor { get; set; }

        /// <summary>
        /// Date of Birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Person() { }

        /// <summary>
        /// Property Constructor
        /// </summary>
        /// <param name="lastName">Last Name</param>
        /// <param name="firstName">First Name</param>
        /// <param name="gender">Gender</param>
        /// <param name="favoriteColor">Favorite Color</param>
        /// <param name="dateOfBirth">Date of Birth</param>
        public Person(string lastName, string firstName, string gender, string favoriteColor, DateTime dateOfBirth)
        {
            LastName = lastName;
            FirstName = firstName;
            Gender = gender;
            FavoriteColor = favoriteColor;
            DateOfBirth = dateOfBirth;
        }
    }
}
