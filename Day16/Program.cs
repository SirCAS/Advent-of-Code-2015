using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day16.ConsoleApplication
{
    public class Program
    {
        private const string DataFileName = "input.txt";

        public static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 16 |");
            Console.WriteLine("+-------------------------+");

            // Load data from input file
            var sues = File.ReadAllLines(DataFileName)
                .Select(x => x.Split(':'))
                .ToDictionary(
                    x => x[0],
                    y => String.Join(":", y.Skip(1)).Trim())
                .ToDictionary(
                    x => x.Key.Trim(),
                    y => y.Value
                          .Split(',')
                          .ToDictionary(
                              o => o.Split(':')[0].Trim(),
                              u => int.Parse(u.Split(':')[1].Trim())
                          )
                );

            var bestMatch = sues.Select(x => Test(new Tuple<string, Dictionary<string, int>>(x.Key, x.Value)))
                .OrderByDescending(x => x.Item2).First();

            Console.WriteLine($"Best match is {bestMatch.Item1} with {bestMatch.Item2} matching details");


            Console.WriteLine($"  -Gruss Gott");
        }

            /*
            children: 3
            cats: 7
            samoyeds: 2
            pomeranians: 3
            akitas: 0
            vizslas: 0
            goldfish: 5
            trees: 3
            cars: 2
            perfumes: 1
            */

        private static Tuple<string, int> Test(Tuple<string, Dictionary<string, int>> sue)
        {
            int score = 0;
            if(IsGood(sue.Item2, "children", 3)) ++score;
            if(IsGreater(sue.Item2, "cats", 7)) ++score;
            if(IsGood(sue.Item2, "samoyeds", 2)) ++score;
            if(IsLess(sue.Item2, "pomeranians", 3)) ++score;
            if(IsGood(sue.Item2, "akitas", 0)) ++score;
            if(IsGood(sue.Item2, "vizslas", 0)) ++score;
            if(IsLess(sue.Item2, "goldfish", 5)) ++score;
            if(IsGreater(sue.Item2, "trees", 3)) ++score;
            if(IsGood(sue.Item2, "cars", 2)) ++score;
            if(IsGood(sue.Item2, "perfumes", 1)) ++score;
            return new Tuple<string, int>(sue.Item1, score);
        }

        private static bool IsGood(Dictionary<string, int> item, string key, int value)
        {
            return item.Any(y => y.Key == key && y.Value == value);
        }

        private static bool IsGreater(Dictionary<string, int> item, string key, int value)
        {
            return item.Any(y => y.Key == key && y.Value >= value);
        }

        private static bool IsLess(Dictionary<string, int> item, string key, int value)
        {
            return item.Any(y => y.Key == key && y.Value <= value);
        }
    }
}
