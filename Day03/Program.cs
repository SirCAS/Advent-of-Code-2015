using System;
using System.IO;

namespace AdventOfCode.Day3
{
    // The assignment description is not clear on the situation where both Robo-Santa and Santa are to the same house.
    // Do they recognize each other and only drop a single present?
    // It really doesn't make any difference in regard to the asked question in the assignment because we're only counting
    // houses that have presents thus it doesn't matter if there multiple. However this difference is important in this
    // specific implementation because I've have added the minimumRequiredGifts parameter.
    //
    // The following is my addition to the story in order to make a decision on the subject:
    // The existence of RoboSanta is a secret as Santa Corp Inc.don't want the public to know about the growing problem
    // with elf being eggnoggedly at work.Santa Corp Inc. have developed an invisibility cloak for RoboSanta in cooperation
    // with Hogwarts School of Witchcraft and Wizardry. The invisibility cloak is automatically activated during operation.
    // This way no one will see the metallic look of RoboSanta, nor will they see both Santa and RoboSanta at the same time.
    // The invisibility cloak however poses some problems for Santa as he also can't see RoboSanta. This also implies that
    // some houses might get presents from both Santa and RoboSata, even at the same time.Infact the first house on the route
    // is guaranteed to get at least two presents, one from Santa and RoboSanta.

    class Program
    {
        const string PuzzleInputFileName = "PuzzleInput.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Santa Statics 1.0");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Parsing presents from:  {0}", PuzzleInputFileName);

            var instructionString = File.ReadAllText(PuzzleInputFileName);

            var statistics = new SantaStatistics();

            Console.WriteLine("Adding route from file to simulator...");
            statistics.SetRoute(instructionString);

            Console.WriteLine("Adding Santa to simulator...");
            statistics.AddSanta("Santa");

            Console.WriteLine("Running simulation...");
            Console.WriteLine("There's {0} houses with atleast one gift", statistics.CountHousesWithGifts(1));
            Console.WriteLine("There's {0} houses with atleast two gift", statistics.CountHousesWithGifts(2));
            Console.WriteLine("There's {0} houses with atleast four gift", statistics.CountHousesWithGifts(4));

            Console.WriteLine("-------");

            Console.WriteLine("Adding RoboSanta to simulator...");
            statistics.AddSanta("RoboSanta");

            Console.WriteLine("Running simulation...");
            Console.WriteLine("There's {0} houses with atleast one gift", statistics.CountHousesWithGifts(1));
            Console.WriteLine("There's {0} houses with atleast two gift", statistics.CountHousesWithGifts(2));
            Console.WriteLine("There's {0} houses with atleast four gift", statistics.CountHousesWithGifts(4));

            Console.WriteLine();
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }
    }
}
