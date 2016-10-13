using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Day8.Converter;

namespace Day8.ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("+------------------------+");
            Console.WriteLine("| Advent of Code - Day 8 |");
            Console.WriteLine("+------------------------+");

            // Read input file
            const string InputFileName = "input.txt";
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), InputFileName);
            var inputFileLines = File.ReadAllLines(inputFilePath);

            // Pass data to LiteralDecoder and process input
            var decoder = new Decoder(inputFileLines);
            decoder.DecodeBackslash();
            decoder.DecodeQuotes();
            decoder.DecodeHexaDecimals();
            var decodedResult = decoder.GetResult();

            // Pass data to LiteralEncoder and process input
            var encode = new Encoder(inputFileLines);
            var encodedResult = encode.GetResult();

            // Get input string without new line chars to allow matching with output from parsers
            var inputString = new string(inputFileLines.SelectMany(x => x).ToArray());

            // Output result to console
            Console.WriteLine($"  Part 1 result: {(inputString.Length - decodedResult.Length)}"); // TODO: Write unittests. Answer is 1350
            Console.WriteLine($"  Rart 2 result: {(encodedResult.Length - inputString.Length)}"); // TODO: Write unittests. Answer is 2085
            Console.WriteLine($"     - Merry Christmas!");
        }
    }
}
