using System;
using NUnit.Framework;

namespace AdventOfCode.Day6
{
    [TestFixture]
    public class LightArraySimulatorTests
    {
        [Test]
        public void TurnOn10By10LightsTest()
        {
            // 1. Arrange
            var simulator = new LightArraySimulator();

            var instruction = new LightArrayInstruction
            {
                Action = LightArrayActionEnum.TurnOn,
                Start = new Tuple<int, int>(1, 1),
                End = new Tuple<int, int>(10, 10)
            };

            // 2. Act
            simulator.SimulateInstruction(instruction);

            // 3. Assert
            Assert.AreEqual(100, simulator.LightsOn);
        }

        [Test]
        public void TurnOff10By10LightsTest()
        {
            // 1. Arrange
            var simulator = new LightArraySimulator();

            var instruction = new LightArrayInstruction
            {
                Action = LightArrayActionEnum.TurnOff,
                Start = new Tuple<int, int>(1, 1),
                End = new Tuple<int, int>(9, 9)
            };

            // 2. Act
            simulator.SimulateInstruction(instruction);

            // 3. Assert
            Assert.AreEqual(0, simulator.LightsOn);
        }

        [Test]
        public void Toggle10By10LightsTest()
        {
            // 1. Arrange
            var simulator = new LightArraySimulator();

            var instruction = new LightArrayInstruction
            {
                Action = LightArrayActionEnum.Toggle,
                Start = new Tuple<int, int>(1, 1),
                End = new Tuple<int, int>(10, 10)
            };

            // 2. Act
            simulator.SimulateInstruction(instruction);

            // 3. Assert
            Assert.AreEqual(10*10, simulator.LightsOn);
        }

        [Test]
        public void TurnOnFirstLineOf1000LightsTest()
        {
            // 1. Arrange
            var simulator = new LightArraySimulator();

            var instruction = new LightArrayInstruction
            {
                Action = LightArrayActionEnum.TurnOn,
                Start = new Tuple<int, int>(0, 0),
                End = new Tuple<int, int>(999, 0)
            };

            // 2. Act
            simulator.SimulateInstruction(instruction);

            // 3. Assert
            Assert.AreEqual(1000, simulator.LightsOn);
        }
    }
}