using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day14.ConsoleApplication
{
    public class Program
    {
        private const string DataFileName = "input.1.txt";
        //private const string DataFileName = "input.txt";

        public static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 14 |");
            Console.WriteLine("+-------------------------+");

            var travelTime = 2503;
            //var travelTime = 1000;

            var result = OlympicsSimulator.Simulate(DataFileName, travelTime);

            var oldWinner = result.OrderByDescending(x => x.Odometer).First();
            var newWinner = result.OrderByDescending(x => x.Score).First();

            Console.WriteLine($"The old winner is {oldWinner.Name} who have travled {oldWinner.Odometer} km");
            Console.WriteLine($"The new winner is {newWinner.Name} who has a score of {newWinner.Score}");

            Console.WriteLine($"  -Gruss Gott");
        }
    }
}
