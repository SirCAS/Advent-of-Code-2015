using System;

namespace AdventOfCode.Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var miner = new AdventCointMiner();

            Console.WriteLine("AdventCoin miner 1.0");
            Console.WriteLine("----------------------------");

            Console.Write("Please enter your secret key: ");
            var secretKey = Console.ReadLine();

            try
            {
                Console.WriteLine("Starting bruteforce attack...");

                var number = miner.FindValidNumber(secretKey);

                Console.WriteLine("Lowest possible value is: " + number);
            }
            catch (TimeoutException e)
            {
                Console.WriteLine();
                Console.WriteLine("Bruteforce took longer than 1 minute - terminating execution...");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }
    }
}
