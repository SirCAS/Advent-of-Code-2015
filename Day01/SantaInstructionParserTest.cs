using NUnit.Framework;

namespace AdventOfCode.Day1
{
    /// <summary>
    /// Test for the SantaInstructionParser
    /// Test-cases are divided using equivalence class partitioning
    /// </summary>
    [TestFixture]
    public class SantaInstructionParserTest
    {
        [Test]
        public void FindEndingFloorNo_InstructionsForGroundFloorTest()
        {
            // 1. Arrange
            const string instructions = "(())";

            // 2. Act
            var result = SantaInstructionParser.FindEndingFloorNo(instructions);

            // 3. Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void FindEndingFloorNo_InstructionsForThridFloorTest()
        {
            // 1. Arrange
            const string instructions = "(((";

            // 2. Act
            var result = SantaInstructionParser.FindEndingFloorNo(instructions);

            // 3. Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void FindEndingFloorNo_InstructionsForFirstBasementLevelTest()
        {
            // 1. Arrange
            const string instructions = "())";

            // 2. Act
            var result = SantaInstructionParser.FindEndingFloorNo(instructions);

            // 3. Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void FindEndingFloorNo_InstructionsForThirdBasementLevelTest()
        {
            // 1. Arrange
            const string instructions = ")())())";

            // 2. Act
            var result = SantaInstructionParser.FindEndingFloorNo(instructions);

            // 3. Assert
            Assert.AreEqual(-3, result);
        }

        [Test]
        public void FindFirstCharPositionForBasement_FirstCharGivesBasementTest()
        {
            // 1. Arrange
            const string instructions = ")";

            // 2. Act
            var result = SantaInstructionParser.FindFirstCharPositionForBasement(instructions);

            // 3. Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void FindFirstCharPositionForBasement_FifthCharGivesBasementTest()
        {
            // 1. Arrange
            const string instructions = "()())";

            // 2. Act
            var result = SantaInstructionParser.FindFirstCharPositionForBasement(instructions);

            // 3. Assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void FindFirstCharPositionForBasement_BasementIsNeverReachedTest()
        {
            // 1. Arrange
            const string instructions = "((((";

            // 2. Act
            var result = SantaInstructionParser.FindFirstCharPositionForBasement(instructions);

            // 3. Assert
            Assert.AreEqual(0, result);
        }

    }
}
