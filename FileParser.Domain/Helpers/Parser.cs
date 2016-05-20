using System;
using System.Linq;
using FileParser.Domain.Entities;

namespace FileParser.Domain.Helpers
{
    /// <summary>
    /// Parsing Helper
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// Parse Person Record
        /// </summary>
        /// <param name="personText">Person Delimited Text String</param>
        /// <param name="delimeter">Delimeter</param>
        /// <returns>Person</returns>
        public static Person ParsePerson(string personText, char? delimeter)
        {
            delimeter = delimeter ?? GetDelimeter(personText);
            if (delimeter == null) return null;

            var properties = personText.Split(delimeter.Value);
            return properties.Length == 5 ? new Person(properties[0], properties[1], properties[2], properties[3], DateTime.Parse(properties[4])) : null;
        }

        /// <summary>
        /// Determine Delimeter
        /// Will likely need a reg ex match instead of contains check
        /// </summary>
        /// <param name="text">Text to be parsed</param>
        /// <returns>Char or null for delimeter</returns>
        public static char? GetDelimeter(string text)
        {
            if (text.Contains(Constants.CommaDelimiter)) { return Constants.CommaDelimiter; }
            if (text.Contains(Constants.PipeDelimiter)) { return Constants.PipeDelimiter; }
            if (text.Contains(Constants.WhitespaceDelimiter)) { return Constants.WhitespaceDelimiter; }
            return null;
        }
    }
}
