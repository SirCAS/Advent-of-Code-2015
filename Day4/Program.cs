using System;

namespace AdventOfCode.Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AdventCoin miner 1.1");
            Console.WriteLine("----------------------------");

            Console.Write("Find with (S)ix or (F)ive leading zeros: ");
            string isSixLeadingZerosStr = Console.ReadLine();

            var miner = new AdventCointMiner(isSixLeadingZerosStr.Contains("S"));

            Console.Write("Please enter your secret key: ");
            var secretKey = Console.ReadLine();

            try
            {
                Console.WriteLine("Executing bruteforce attempt...");
                Console.WriteLine("Please wait...");
                Console.WriteLine();

                var result = miner.FindValidNumber(secretKey);

                Console.WriteLine("Lowest possible value is: {0}", result.LowestPossibleValue);
                Console.WriteLine("         The MD5 hash is: {0}", result.Hash);
                Console.WriteLine("      Execution time was: {0} minutes and {1} seconds", result.ExecutionTime.Minutes, result.ExecutionTime.Seconds);
            }
            catch (TimeoutException e)
            {
                Console.WriteLine();
                Console.WriteLine("Bruteforce took longer than 3 minutes - terminating execution...");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }
    }
}
