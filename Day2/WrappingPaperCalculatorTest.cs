using System.Collections.Generic;
using NUnit.Framework;

namespace AdventOfCode.Day2
{
    [TestFixture]
    public class WrappingPaperCalculatorTest
    {
        #region Wrapping Paper Tests

        [Test]
        public void CalculateNeededPaperForLargePresentTest()
        {
            // 1. Arrange
            var presents = CreateLargePresent();

            // 2. Act
            var result = WrappingCalculator.CalculateNeededPaper(presents);

            // 3. Assert
            Assert.AreEqual(58, result);
        }

        [Test]
        public void CalculateNeededPaperForSmallPresentTest()
        {
            // 1. Arrange
            var presents = CreateSmallPresent();

            // 2. Act
            var result = WrappingCalculator.CalculateNeededPaper(presents);

            // 3. Assert
            Assert.AreEqual(43, result);
        }

        [Test]
        public void CalculateNeededPaperForPresentsTest()
        {
            // 1. Arrange
            var presents = CreatePresents();

            // 2. Act
            var result = WrappingCalculator.CalculateNeededPaper(presents);

            // 3. Assert
            Assert.AreEqual(58 + 43, result);
        }

        #endregion

        #region Wrapping Ribbon Tests

        [Test]
        public void CalculateNeededRibbonForLargePresentTest()
        {
            // 1. Arrange
            var presents = CreateLargePresent();

            // 2. Act
            var result = WrappingCalculator.CalculateNeededRibbon(presents);
            // 3. Assert
            Assert.AreEqual(34, result);
        }

        [Test]
        public void CalculateNeededRibbonForSmallPresentTest()
        {
            // 1. Arrange
            var presents = CreateSmallPresent();

            // 2. Act
            var result = WrappingCalculator.CalculateNeededRibbon(presents);

            // 3. Assert
            Assert.AreEqual(14, result);
        }

        [Test]
        public void CalculateNeededRibbonForPresentsTest()
        {
            // 1. Arrange
            var presents = CreatePresents();

            // 2. Act
            var result = WrappingCalculator.CalculateNeededRibbon(presents);

            // 3. Assert
            Assert.AreEqual(34 + 14, result);
        }

        #endregion

        #region Test Factories

        private IList<PresentModel> CreateLargePresent()
        {
            return new List<PresentModel> { new PresentModel { Height = 2, Length = 3, Width = 4 } };
        }

        private IList<PresentModel> CreateSmallPresent()
        {
            return new List<PresentModel> { new PresentModel { Height = 1, Length = 1, Width = 10 } };
        }

        private IList<PresentModel> CreatePresents()
        {
            return new List<PresentModel>
            {
                new PresentModel { Height = 2, Length = 3, Width = 4 },
                new PresentModel { Height = 1, Length = 1, Width = 10 }
            };
        }

        #endregion

    }
}
