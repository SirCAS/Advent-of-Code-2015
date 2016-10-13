using System;
using System.IO;
using System.Linq;

namespace Day9.ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("+------------------------+");
            Console.WriteLine("| Advent of Code - Day 9 |");
            Console.WriteLine("+------------------------+");

            // Read input file
            const string InputFileName = "input.txt";
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), InputFileName);
            var inputFileLines = File.ReadAllLines(inputFilePath);

            // Fire up route planner
            var routePlanner = new RoutePlanner(inputFileLines);

            // Get all possible plans
            var plans = routePlanner.GetPlans();

            // Determine the shorest route
            var shortestRoute = plans.Min(x => x.TotalLength);
            Console.WriteLine($"Shortest route is: {shortestRoute}");
            
            // Determine the longest route
            var longestRoute = plans.Max(x => x.TotalLength);
            Console.WriteLine($"Longest route is: {longestRoute}");
        }
    }
}
