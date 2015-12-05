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

            var presents = PresentExtractor.ExtractPresents(presentsString);

            var paper = WrappingCalculator.CalculateNeededPaper(presents);
            var ribbon = WrappingCalculator.CalculateNeededRibbon(presents);

            Console.WriteLine("The needed amount of wrapping paper is {0} square feets and {1} feets of wrapping ribbon", paper, ribbon);

            Console.WriteLine();
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }
    }
}
