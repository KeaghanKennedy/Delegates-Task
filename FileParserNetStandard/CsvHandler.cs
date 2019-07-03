using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FileParserNetStandard;

namespace Delegate_Exercise {
    
    
    public class CsvHandler {
        
        /// <summary>
        /// Reads a csv file (readfile) and applies datahandling via dataHandler delegate and writes result as csv to writeFile.
        /// </summary>
        /// <param name="readFile"></param>
        /// <param name="writeFile"></param>
        /// <param name="dataHandler"></param>
        public void ProcessCsv(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>> dataHandler) {
            
            var _fh = new FileHandler();
            var _dp = new DataParser();

            var lines = _fh.ReadFile(readFile);
            var parsedLines = _fh.ParseCsv(lines);

            parsedLines = _dp.StripHash(parsedLines);
            parsedLines = _dp.StripQuotes(parsedLines);
            parsedLines = _dp.StripWhiteSpace(parsedLines);

            var cleanLines = dataHandler(parsedLines);

            _fh.WriteFile(writeFile, ',', cleanLines);

            foreach (var line in cleanLines)
            {
                Console.WriteLine(line);
            }
        }
    }
}