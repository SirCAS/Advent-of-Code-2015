using System.IO;
using AdventOfCode.Day7.Parser;
using AdventOfCode.Day7.Simulator;
using NUnit.Framework;

namespace AdventOfCode.Day7.Tests
{
    [TestFixture]
    public class BigBangTests
    {
        [Test]
        public void BigBangTest()
        {
            // 1. Arrange
            const string inputFileName = "PuzzleInput.txt";
            var input = File.ReadAllLines(inputFileName);

            ICircuitParser parser = new CircuitParser();
            ICircuitSimulator simulator = new CircuitSimulator();

            // 2. Act
            var components = parser.PaseComponents(input);
            var result = simulator.RunSimulation(components);

            // 3. Assert
            var a = result["a"];
            Assert.AreEqual(956, a);
        }
    }
}
