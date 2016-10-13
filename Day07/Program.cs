using System;
using System.IO;
using System.Linq;
using AdventOfCode.Day7.Model.Components;
using AdventOfCode.Day7.Parser;
using AdventOfCode.Day7.Simulator;

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
            ICircuitSimulator simulator = new CircuitSimulator();
            var result1 = simulator.RunSimulation(components);

            var a1 = result1["a"];
            
            Console.WriteLine("Value of a is : " + a1);
            Console.WriteLine();

            Console.WriteLine("Overriding wire b with the value of a");

            var wireB = components.Single(x => x.OutputName == "b");
            components.Remove(wireB);
            components.Add(new InputComponent(a1.ToString(), "b"));

            Console.WriteLine("Rerunning simulation");
            var result2 = simulator.RunSimulation(components);

            var a2 = result2["a"];
            Console.WriteLine("Value of a is : " + a2);

            Console.WriteLine();
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }
    }

}
