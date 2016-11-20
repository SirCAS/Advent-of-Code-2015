using System;
using System.Diagnostics;

namespace Day15.ConsoleApplication
{
    public class Program
    {
        private const string DataFileName = "input.1.txt";

        public static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 15 |");
            Console.WriteLine("+-------------------------+");

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var syncCookieRecipice = HardcodedCookieCrafter.GetAwesomeCookie(DataFileName); 
            stopWatch.Stop();
            Console.WriteLine($"HardcodedCookieCrafter took {stopWatch.ElapsedMilliseconds} ms and found recipce with {syncCookieRecipice.Score} point");
            
            stopWatch.Reset();

            stopWatch.Start();
            var parallelCookieRecipice = ParallelCookieCrafter.GetAwesomeCookie(DataFileName); 
            stopWatch.Stop();
            Console.WriteLine($"ParallelCookieCrafter took {stopWatch.ElapsedMilliseconds} ms and found recipce with {parallelCookieRecipice.Score} point");

            Console.WriteLine($"  -Gruss Gott");
        }
    }
}
