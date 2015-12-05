using NUnit.Framework;

namespace Day3
{
    [TestFixture]
    public class SantaStatisticsTest
    {
        #region One Santa Tests

        [Test]
        public void OneSanta_OneMoveTest()
        {
            // 1. Arrange
            var statistics = new SantaStatistics();
            statistics.AddSanta("Santa");
            statistics.SetRoute(">");

            // 2. Act
            var result = statistics.CountHousesWithGifts(1);

            // 3. Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void OneSanta_CircleMoveTest()
        {
            // 1. Arrange
            var statistics = new SantaStatistics();
            statistics.AddSanta("Santa");
            statistics.SetRoute("^>v<");

            // 2. Act
            var result = statistics.CountHousesWithGifts(1);

            // 3. Assert
            Assert.AreEqual(4, result);
        }

        [Test]
        public void OneSanta_MoveBackAndForwardTest()
        {
            // 1. Arrange
            var statistics = new SantaStatistics();
            statistics.AddSanta("Santa");
            statistics.SetRoute("^v^v^v^v^v");

            // 2. Act
            var result = statistics.CountHousesWithGifts(1);

            // 3. Assert
            Assert.AreEqual(2, result);
        }

        #endregion

        #region Two Santa Tests

        [Test]
        public void TwoSanta_OneMoveEachTest()
        {
            // 1. Arrange
            var statistics = new SantaStatistics();
            statistics.AddSanta("Santa");
            statistics.AddSanta("RoboSanta");
            statistics.SetRoute("^v");

            // 2. Act
            var result = statistics.CountHousesWithGifts(1);

            // 3. Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void TwoSanta_OneStepForwardOneStepBackTest()
        {
            // 1. Arrange
            var statistics = new SantaStatistics();
            statistics.AddSanta("Santa");
            statistics.AddSanta("RoboSanta");
            statistics.SetRoute("^>v<");

            // 2. Act
            var result = statistics.CountHousesWithGifts(1);

            // 3. Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void TwoSanta_GoingOppsiteDirectionsTest()
        {
            // 1. Arrange
            var statistics = new SantaStatistics();
            statistics.AddSanta("Santa");
            statistics.AddSanta("RoboSanta");
            statistics.SetRoute("^v^v^v^v^v");

            // 2. Act
            var result = statistics.CountHousesWithGifts(1);

            // 3. Assert
            Assert.AreEqual(11, result);
        }

        #endregion
    }
}
