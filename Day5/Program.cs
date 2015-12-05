using System;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day5
{
    class Program
    {
        private const string inputFileName = "PuzzleInput.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Santa Word Validator - Nice or Naughty 1.0");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Parsing words from:  {0}", inputFileName);

            var input = File.ReadAllLines(inputFileName);

            var niceWords = input.Count(SantaWordValidator.IsNice);

            Console.WriteLine("There's {0} nice words in the list", niceWords);

            Console.WriteLine();
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }
    }
}
