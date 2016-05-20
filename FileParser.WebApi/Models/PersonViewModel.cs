using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileParser.Domain.Entities;
using Newtonsoft.Json;

namespace FileParser.WebApi.Models
{
    /// <summary>
    /// Person View Model
    /// </summary>
    public class PersonViewModel
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
        public string DateOfBirth { get; set; }

        /// <summary>
        /// Person Constructor
        /// </summary>
        /// <param name="person"></param>
        public PersonViewModel(Person person)
        {
            LastName = person.LastName;
            FirstName = person.FirstName;
            Gender = person.Gender;
            FavoriteColor = person.FavoriteColor;
            DateOfBirth = person.DateOfBirth.ToShortDateString();
        }
    }
}