using System;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        const string InstructionFile = "PuzzleInput.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Santa Instruction Parser 1.0");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Parsing instructions from:  {0}", InstructionFile);

            var instructionString = File.ReadAllText(InstructionFile);
            var endFloorNo = SantaInstructionParser.FindEndingFloorNo(instructionString);

            Console.WriteLine("Resulting floor is: {0}", endFloorNo);
            Console.WriteLine();
            Console.WriteLine("Press any key to end parser");
            Console.ReadKey();
        }
    }
}
