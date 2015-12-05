using System;
using System.IO;

namespace AdventOfCode.Day2
{
    class Program
    {
        const string PresentsFile = "PuzzleInput.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Wrapping paper calculator 1.0");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Parsing presents from:  {0}", PresentsFile);

            var presentsString = File.ReadAllText(PresentsFile);

            var totalWrappingPaperNeeded = WrappingPaperCalculator.CalculateNeededPaperFromStrList(presentsString);

            Console.WriteLine("The needed wrapping paper in square feets are: {0}", totalWrappingPaperNeeded);

            Console.WriteLine();
            Console.WriteLine("Press any key to end parser");
            Console.ReadKey();
        }
    }
}
