using NUnit.Framework;

namespace AdventOfCode.Day2
{
    [TestFixture]
    public class WrappingPaperCalculatorTest
    {
        [Test]
        public void CalculateNeededPaper_SingleStringTest()
        {
            // 1. Arrange
            const string package = "2x3x4";

            // 2. Act
            var result = WrappingPaperCalculator.CalculateNeededPaperFromStrList(package);

            // 3. Assert
            Assert.AreEqual(58, result);
        }

        [Test]
        public void CalculateNeededPaper_SingleStringNo2Test()
        {
            // 1. Arrange
            const string package = "1x1x10";

            // 2. Act
            var result = WrappingPaperCalculator.CalculateNeededPaperFromStrList(package);

            // 3. Assert
            Assert.AreEqual(43, result);
        }

        [Test]
        public void CalculateNeededPaper_MultipleStringTest()
        {
            // 1. Arrange
            const string packages = "1x1x10\n2x3x4";

            // 2. Act
            var result = WrappingPaperCalculator.CalculateNeededPaperFromStrList(packages);

            // 3. Assert
            Assert.AreEqual(58 + 43, result);
        }
    }
}
