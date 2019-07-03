using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise {
 
    
    internal class Delegate_Exercise {
        public static void Main(string[] args)
        {
            var filePath = "///home/keags/Development/delegates_task/data.csv";
            var writePath = "///home/keags/Development/delegates_task/write.csv";
            
            var _ch = new CsvHandler();
            
            _ch.ProcessCsv(filePath, writePath, (x) => x);

            Console.Read();
        }
    }
}