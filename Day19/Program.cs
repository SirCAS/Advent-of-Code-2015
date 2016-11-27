using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

        static int CountSubstitions(string input, string target, IEnumerable<Tuple<string, string>> mappings)
        {
            var random = new Random();
            var inputCopy = input;
            var substitions = 0;
            
            while (inputCopy != target) // Keep trying until solution are found 
            {
                var tmp = inputCopy;
                foreach (var map in mappings) 
                {
                    var index = inputCopy.IndexOf(map.Item2);
                    if (index >= 0)
                    {
                        inputCopy = inputCopy.Substring(0, index) + map.Item1 + inputCopy.Substring(index + map.Item2.Length);
                        ++substitions;
                    }
                }

                if (tmp == inputCopy) // Fail - no changes since last iteration - shuffle mappings and retry
                {
                    inputCopy = input;
                    substitions = 0;
                    mappings = mappings.OrderBy(x => random.Next()).ToList(); // Shuffle input and try again
                }
            }    
            return substitions;
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

            var part1 = GetSolutions(input, mappings).Distinct().Count();
            Console.WriteLine($"Part1: There is {part1} solutions");

            var part2 = CountSubstitions(input, "e", mappings);
            Console.WriteLine($"Part2: {part2} substitions was made to reach target molecule from atoms");

            Console.WriteLine($"  -Gruss Gott");
        }
    }
}
