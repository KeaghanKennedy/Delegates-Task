using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ObjectLibrary;


namespace FileParserNetStandard {

    public class PersonHandler {
        public List<Person> People;
        
        DataParser _dp = new DataParser();

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people) {
            People = new List<Person>();

            people = _dp.StripHash(people);
            people = _dp.StripQuotes(people);
            people = _dp.StripWhiteSpace(people);

            foreach (var person in people)
            {
                int res;
                if (!int.TryParse(person[0], out res)) continue;
                People.Add(new Person(int.Parse(person[0]), person[1], person[2], new DateTime(Convert.ToInt64(person[3]))));
            }
        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest() {
            return People.Where(x => x.Dob == People.Min(y => y.Dob)).ToList();
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id) {
            var returnString = People.Find(person => person.Id == id).ToString();
            return returnString;
        }

        public List<Person> GetOrderBySurname() {
            return new List<Person> (People.OrderBy(person => person.Surname));
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive) {
            return People.Where(person => person.Surname.StartsWith(
                searchTerm, caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase)).Count();
        }
        
        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate() {
            List<string> result = new List<string>();

            return result;  //-- return result here
        }
    }
}