using System;
using System.IO;

namespace AdventOfCode.Day6
{
    class Program
    {
        private const string inputFileName = "PuzzleInput.txt";

        static void Main(string[] args)
        {
            var simulator = new LightArraySimulator();

            Console.WriteLine("Day 6: Probably a Fire Hazard");
            Console.WriteLine("----------------------------");

            Console.WriteLine("Reading instructions from:  {0}", inputFileName);
            var input = File.ReadAllLines(inputFileName);

            Console.WriteLine("Paring instructions...");
            var instructions = LightArrayInstructionParser.ParseActions(input);

            Console.WriteLine("Running simulation...");
            simulator.SimulateInstructions(instructions);

            Console.WriteLine("Lights turned on after instructions are {0}", simulator.LightsOn);

            Console.WriteLine();
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }
    }
}
