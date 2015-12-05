using System;
using System.IO;

namespace Day3
{
    class Program
    {
        const string PuzzleInputFileName = "PuzzleInput.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Gift tracker 1.0");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Parsing presents from:  {0}", PuzzleInputFileName);

            var instructionString = File.ReadAllText(PuzzleInputFileName);

            var numOfHousesWithOneGiftAndAbove = GiftTracker.CountHousesWithNumOfGifts(1 ,instructionString);

            Console.WriteLine("There's {0} houses with atleast one gift", numOfHousesWithOneGiftAndAbove);

            Console.WriteLine();
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }
    }
}
