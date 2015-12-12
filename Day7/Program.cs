using System;
using System.Collections;
using System.IO;
using AdventOfCode.Day7.Parser;
using AdventOfCode.Day7.Simulator;
using NUnit.Framework.Constraints;

namespace AdventOfCode.Day7
{
    class Program
    {
        private const string inputFileName = "PuzzleInput.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Day 7: Some Assembly Required");
            Console.WriteLine("----------------------------");

            Console.WriteLine("Reading setup from:  {0}", inputFileName);
            var input = File.ReadAllLines(inputFileName);

            Console.WriteLine("Paring instructions...");
            ICircuitParser parser = new CircuitParser();
            var components = parser.PaseComponents(input);

            Console.WriteLine("Running simulation...");
            CircuitSimulator simulator = new CircuitSimulator();
            var result = simulator.RunSimulation(components);

            var a = result["a"];
            
            Console.WriteLine("Value of a is : " + a);

            Console.WriteLine();
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }
    }

}
