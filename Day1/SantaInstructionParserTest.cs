using NUnit.Framework;

namespace AdventOfCode
{
    /// <summary>
    /// Test for the SantaInstructionParser
    /// Test-cases are divided using equivalence class partitioning
    /// </summary>
    [TestFixture]
    public class SantaInstructionParserTest
    {
        [Test]
        public void InstructionsForGroundFloorTest()
        {
            // 1. Arrange
            const string instructions = "(())";

            // 2. Act
            var result = SantaInstructionParser.ParseIntructions(instructions);

            // 3. Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void InstructionsForThridFloorTest()
        {
            // 1. Arrange
            const string instructions = "(((";

            // 2. Act
            var result = SantaInstructionParser.ParseIntructions(instructions);

            // 3. Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void InstructionsForFirstBasementLevelTest()
        {
            // 1. Arrange
            const string instructions = "())";

            // 2. Act
            var result = SantaInstructionParser.ParseIntructions(instructions);

            // 3. Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void InstructionsForThirdBasementLevelTest()
        {
            // 1. Arrange
            const string instructions = ")())())";

            // 2. Act
            var result = SantaInstructionParser.ParseIntructions(instructions);

            // 3. Assert
            Assert.AreEqual(-3, result);
        }
    }
}
