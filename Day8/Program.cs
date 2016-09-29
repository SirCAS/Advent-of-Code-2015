using System;
using System.IO;
using System.Linq;
using Day8.Model;
using Day8.Converter;

namespace Day8.ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Read input file
            const string InputFileName = "input.txt";
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), InputFileName);
            var inputFileLines = File.ReadAllLines(inputFilePath);

            // Pass input data to liter conveter for processing
            var converter = new LiteralConverter(inputFileLines);
            converter.FixBackslash();
            converter.FixQuotes();
            converter.FixHexaDecimals();
            
            // Get the final string after processing (i.e. converting escapes etc.)
            var parsedInput = converter.GetResult();

            // Get input string without new line chars to allow matching with output from parser
            var inputString = new string(inputFileLines.SelectMany(x => x).ToArray());

            // Output result to console
            Console.WriteLine($"The result is: {(inputString.Length - parsedInput.Length)}");
        }
    }
}
