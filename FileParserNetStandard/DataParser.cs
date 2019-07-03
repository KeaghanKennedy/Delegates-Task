using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace FileParserNetStandard {
    public class DataParser {
        

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data)
        {
            var stringList = new List<List<string>>();

            foreach (var line in data)
            {
                var newLine = new List<string>();
                foreach (var value in line)
                {
                    newLine.Add(value.Trim());
                }

                stringList.Add(newLine);
            }
            return stringList;
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data) {
            var stringList = new List<List<string>>();

            foreach (var line in data)
            {
                var newLine = new List<string>();
                foreach (var value in line)
                {
                    newLine.Add(value.Replace("\"", ""));
                }
                stringList.Add(newLine);
            }
            return stringList;
        }

        public List<List<string>> StripHash(List<List<string>> data)
        {
            var stringList = new List<List<string>>();

            foreach (var line in data)
            {
                var newLine = new List<string>();
                foreach (var value in line)
                {
                    newLine.Add(value.Replace("#", ""));
                }
                stringList.Add(newLine);
            }
            return stringList;
        }
    }
}