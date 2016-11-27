using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day17.ConsoleApplication
{
    public class Program
    {
        private const string DataFileName = "input.txt";

        private const int Target = 150;

        public static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 17 |");
            Console.WriteLine("+-------------------------+");

            // Load data from input file
            var containers = File.ReadAllLines(DataFileName)
                .Select(int.Parse)
                .ToList();

            var solutions = GetSolutions(new List<int>(), containers, Target).ToList();

            var totalSolutions = solutions.Count;
            
            var min = solutions.Min(p => p.Count);
            var totalMinimumSolutions = solutions.Count(p => p.Count == min);

            Console.WriteLine($"There is {totalSolutions} solutions in total and {totalMinimumSolutions} minimum solutions");

            // Target = 25 l
            // Containers = 1:20, 2:15, 3:10, 4:5, and 5:5
            //
            // 2:15, 3:10
            // 1:20, 4:5
            // 1:20, 5:5
            // 2:15, 4:5, 5:5

            Console.WriteLine($"  -Gruss Gott");
        }

        public static IEnumerable<List<int>> GetSolutions(List<int> solution, List<int> containers, int remaining)
        {
            for(int x = 0; x < containers.Count; ++x)
            {
                var container = containers[x];
                if(container > remaining) // Skip if we have exceeded target
                {
                    continue;
                }

                // Create new solution set
                var copy = solution.ToList();
                copy.Add(container);

                // Check if it is a match
                if(container == remaining)
                {
                    yield return copy;
                }
                else
                {
                    // Keep iterating untill match or we exceed target
                    foreach(var s in GetSolutions(copy, containers.Skip(x + 1).ToList(), Target - copy.Sum()))
                    {
                        yield return s;
                    }
                }
           }
        }
    }
}
