using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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
            if(CookieCrafter.GetAwesomeCookie1(DataFileName).Score != 18965440)
            {
                throw new Exception("Wrong implementation");
            }
            stopWatch.Stop();
            Console.WriteLine($"For-loops took {stopWatch.ElapsedMilliseconds} ms");
            
            stopWatch.Reset();

            stopWatch.Start();
            if(CookieCrafter.GetAwesomeCookie2(DataFileName).Score != 18965440)
            {
                throw new Exception("Wrong implementation");
            }
            stopWatch.Stop();
            Console.WriteLine($"Recursion took {stopWatch.ElapsedMilliseconds} ms");

            Console.WriteLine($"  -Gruss Gott");
        }
    }
}
