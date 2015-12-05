using NUnit.Framework;

namespace AdventOfCode.Day4
{
    [TestFixture]
    public class AdventCointMinerTest
    {
        [Test]
        public void FindKnownGoodKeyNo1Test()
        {
            // 1. Arrange
            const string secretKey = "abcdef";
            var miner = new AdventCointMiner();

            // 2. Act
            var number = miner.FindValidNumber(secretKey);

            // 3. Assert
            Assert.AreEqual(609043, number);
        }

        [Test]
        public void FindKnownGoodKeyNo2Test()
        {
            // 1. Arrange
            const string secretKey = "pqrstuv";
            var miner = new AdventCointMiner();

            // 2. Act
            var number = miner.FindValidNumber(secretKey);

            // 3. Assert
            Assert.AreEqual(1048970, number);
        }
    }
}