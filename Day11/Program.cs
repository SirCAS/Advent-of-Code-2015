using System;

namespace Day11.ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 11 |");
            Console.WriteLine("+-------------------------+");

            string currentPass = "vzbxkghb";

            string newPass = currentPass.GenerateNextPassword();
            string newPassAgain = newPass.GenerateNextPassword();

            Console.WriteLine($"Santas current password is: {currentPass}");
            Console.WriteLine($"           ... the next is: {newPass}");
            Console.WriteLine($"           ... followed by: {newPassAgain}");
        }
    }
}
