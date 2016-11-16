using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day13.ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 13 |");
            Console.WriteLine("+-------------------------+");

            Console.WriteLine("Calculating please be patient...");

            var bestPart1 = BestScore("input.txt");
            var bestPart2 = BestScore("input.part2.txt");

            Console.WriteLine("Best setting for part 1 is {0}", bestPart1);
            Console.WriteLine("Best setting for part 2 is {0}", bestPart2);

            Console.WriteLine($"  -Gruss Gott");
        }

        private static int BestScore(string filename)
        {
            var datafile = File.ReadAllLines(filename);

            var scores = datafile
                .Select(x => x.Split(' ')) // Split strings when space
                .GroupBy(x => x[0])        // Group strings by the first word (the name)
                .ToDictionary(             // Convert to dictionary
                    x => x.Key,            // Use first name as key
                    x => x.ToDictionary(   // Create dictionary with scores of other persons
                        y => y[10].TrimEnd('.'), // The name of the person without the last '.'
                        y => y[2] == "lose" ? -int.Parse(y[3]) : int.Parse(y[3]) // Add sign to score
                    ));

            return GetPermutations(scores, scores.Count).Select(x => TotalHappiness(x)).Max();
        }

        private static int TotalHappiness(IEnumerable<KeyValuePair<string, Dictionary<string, int>>> setting)
        {
            int totalHappiness = 0;
            var settingList = setting.ToList();

            for(int x=0; x < settingList.Count; ++x)
            {    
                totalHappiness += settingList[x].Value[settingList[ x == 0 ? (settingList.Count - 1) : x-1].Key];
                totalHappiness += settingList[x].Value[settingList[ x == (settingList.Count - 1) ? 0 : x+1].Key];
            }
            
            return totalHappiness;
        }

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
            {
                return list.Select(t => new T[] { t });
            }
            
            return GetPermutations(list, length - 1)
                .SelectMany(
                    x => list.Where(e => !x.Contains(e)), (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
