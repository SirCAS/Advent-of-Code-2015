using System;

namespace Day10.ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 10 |");
            Console.WriteLine("+-------------------------+");

            var calculator = new LookAndSayCalculator();
            var result40times = calculator.Process(40, "1321131112");

            Console.WriteLine($"Length of 1321131112 processed 40 times is: {result40times.Length}");

            // Using ConwaysConstant could be fun now feasible due to the max val of integers :-)
            // const double ConwaysConstant = 1.303577269;
            // var result50times = int.Parse(result40times) * ConwaysConstant * 10;
            
            var result50times = calculator.Process(50, "1321131112");
            Console.WriteLine($"Length of 1321131112 processed 50 times is: {result50times.Length}");

        }
    }
}
