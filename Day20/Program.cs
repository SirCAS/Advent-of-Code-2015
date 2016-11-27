using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day20.ConsoleApplication
{
    public class Program
    {
        static int LowestPresentCount(int timeout, int targetScore, int elfMultiplier, int? maxVisits = null)
        {
            int[] deliveredPresents = new int[timeout];
            for (int elf = 1; elf < timeout; elf++)
            {
                for (int houseNo = elf; houseNo < timeout && (maxVisits.HasValue ? (houseNo < elf * maxVisits.Value) : true); houseNo += elf)
                {
                    deliveredPresents[houseNo] += elf * elfMultiplier;
                }
            }

            for (int houseNo = 0; houseNo < timeout; ++houseNo)
            {
                if (targetScore <= deliveredPresents[houseNo])
                {
                    return houseNo;
                }
            }

            throw new TimeoutException("Didn't find a solution. Please adjust interval.");
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 20 |");
            Console.WriteLine("+-------------------------+");

            const int timeout = 1000000;

            const int input = 36000000;
            
            var result_part1 = LowestPresentCount(timeout, input, 10);
            var result_part2 = LowestPresentCount(timeout, input, 11, 50);

            Console.WriteLine($"Part1: {result_part1}");
            Console.WriteLine($"Part2: {result_part2}");
            
            Console.WriteLine($"  -Gruss Gott");
        }
    }
}
