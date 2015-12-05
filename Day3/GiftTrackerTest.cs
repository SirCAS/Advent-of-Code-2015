using NUnit.Framework;

namespace Day3
{
    [TestFixture]
    class GiftTrackerTest
    {
        [Test]
        public void DeliverOneGiftAtTwoHousesTest()
        {
            const string input = ">";

            var result = GiftTracker.CountHousesWithNumOfGifts(1, input);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void DeliverFiveGiftsAtFourHousesTest()
        {
            const string input = "^>v<";

            var result = GiftTracker.CountHousesWithNumOfGifts(1, input);

            Assert.AreEqual(4, result);
        }

        [Test]
        public void DeliverManyGiftsAtTwoHousesTest()
        {
            const string input = "^v^v^v^v^v";

            var result = GiftTracker.CountHousesWithNumOfGifts(1, input);

            Assert.AreEqual(2, result);
        }
    }
}
