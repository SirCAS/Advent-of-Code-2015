using System;
using System.IO;
using System.Linq;

namespace Day12.ConsoleApplication
{
    public class Program
    {
        const string DataFileName = "input.txt";

        public static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 12 |");
            Console.WriteLine("+-------------------------+");

            var datafile = File.ReadAllText(DataFileName);

            var analyzer = new JsonAnalyzer();
            
            var allInt = analyzer.CountIntegers(datafile, false);
            var allIntSum = allInt.Sum(x => x);

            var intWithoutRed = analyzer.CountIntegers(datafile, true);
            var intWithoutRedSum = intWithoutRed.Sum(x => x);
            
            Console.WriteLine($"Sum of all int is: {allIntSum}");
            Console.WriteLine($"Sum of ints without red: {intWithoutRedSum}");
            Console.WriteLine($"  -Gruss Gott");
        }
    }
}
