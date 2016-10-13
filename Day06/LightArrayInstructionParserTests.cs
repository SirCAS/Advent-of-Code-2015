using System;
using NUnit.Framework;

namespace AdventOfCode.Day6
{
    [TestFixture]
    public class LightArrayInstructionParserTests
    {
        [Test]
        public void TurnOffLightsTest()
        {
            // 1. Arrange
            const string input = "turn off 660,55 through 986,197";

            // 2. Act
            var result = LightArrayInstructionParser.ParseAction(input);

            // 3. Assert
            Assert.AreEqual(LightArrayActionEnum.TurnOff, result.Action);
            Assert.AreEqual(new Tuple<int, int>(660, 55), result.Start);
            Assert.AreEqual(new Tuple<int, int>(986, 197), result.End);
        }

        [Test]
        public void TurnOnLightsTest()
        {
            // 1. Arrange
            const string input = "turn on 957,736 through 977,890";

            // 2. Act
            var result = LightArrayInstructionParser.ParseAction(input);

            // 3. Assert
            Assert.AreEqual(LightArrayActionEnum.TurnOn, result.Action);
            Assert.AreEqual(new Tuple<int, int>(957, 736), result.Start);
            Assert.AreEqual(new Tuple<int, int>(977, 890), result.End);
        }

        [Test]
        public void ToggleLightsTest()
        {
            // 1. Arrange
            const string input = "toggle 322,558 through 977,958";

            // 2. Act
            var result = LightArrayInstructionParser.ParseAction(input);

            // 3. Assert
            Assert.AreEqual(LightArrayActionEnum.Toggle, result.Action);
            Assert.AreEqual(new Tuple<int, int>(322, 558), result.Start);
            Assert.AreEqual(new Tuple<int, int>(977, 958), result.End);
        }
    }
}