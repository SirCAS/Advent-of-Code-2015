using System.Collections.Generic;
using AdventOfCode.Day7.Model.Components;
using AdventOfCode.Day7.Model.Interfaces;
using AdventOfCode.Day7.Simulator;
using NUnit.Framework;

namespace AdventOfCode.Day7.Tests
{
    [TestFixture]
    public class CircuitSimulatorTests
    {
        [Test]
        public void RunSimulation_SimpleScenario()
        {
            // 1. Arrange
            var input = new List<IComponent>
            {
                new InputComponent("123", "x"),
                new InputComponent("456", "y"),
                new AndComponent(new[] {"x", "y"}, "d"),
                new OrComponent(new[] {"x", "y"}, "e"),
                new LshiftComponent("x", "f", 2),
                new RshiftComponent("y", "g", 2),
                new NotComponent("x", "h"),
                new NotComponent("y", "i")
            };

            ICircuitSimulator simulator = new CircuitSimulator();

            // 2. Act
            var result = simulator.RunSimulation(input);

            // 3. Assert
            Assert.AreEqual(72, result["d"]);
            Assert.AreEqual(507, result["e"]);
            Assert.AreEqual(492, result["f"]);
            Assert.AreEqual(114, result["g"]);
            Assert.AreEqual(65412, result["h"]);
            Assert.AreEqual(65079, result["i"]);
            Assert.AreEqual(123, result["x"]);
            Assert.AreEqual(456, result["y"]);
        }
    }
}