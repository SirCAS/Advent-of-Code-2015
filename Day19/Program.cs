using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day19.ConsoleApplication
{
    public class Program
    {
        static IEnumerable<string> GetSolutions(string input, IEnumerable<Tuple<string, string>> mappings)
        {
            return
                Enumerable.Range(0, input.Length) // Index of all char pos in input string
                    .SelectMany( // Merge all results/solutions in to one collection
                        offset =>
                            mappings
                                .Where(map => input.Substring(offset).StartsWith(map.Item1)) // Find first occorence of atom (offset by incrementing index)
                                .Select(map => // Replace atom with substitue and add to results/soultions
                                    input.Substring(0, offset) +               // The first part of input untouched
                                    map.Item2 +                                // Substitute
                                    input.Substring(offset + map.Item1.Length) // Rest of the input untouched
                                )
                    );
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 19 |");
            Console.WriteLine("+-------------------------+");

            const string InputFileName = "input.txt";

            // Load data from input file
            var problemData = File.ReadAllLines(InputFileName);
            
            var mappings = problemData
                .Where(x => x.Contains(" => "))
                .Select(x => x.Split(' '))
                .Select(y => new Tuple<string, string>(y[0], y[2]))
                .ToList();
            
            var input = problemData.Last();

            var solutions = GetSolutions(input, mappings).Distinct().Count();
            Console.WriteLine($"There is {solutions}");

            Console.WriteLine($"  -Gruss Gott");
        }
    }
}
