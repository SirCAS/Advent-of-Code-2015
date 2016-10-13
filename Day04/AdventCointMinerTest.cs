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
            var miner = new AdventCointMiner(false);

            // 2. Act
            var result = miner.FindValidNumber(secretKey);

            // 3. Assert
            Assert.AreEqual(609043, result.LowestPossibleValue);
            Assert.AreEqual("000001DBBFA3A5C83A2D506429C7B00E", result.Hash);
        }

        [Test]
        public void FindKnownGoodKeyNo2Test()
        {
            // 1. Arrange
            const string secretKey = "pqrstuv";
            var miner = new AdventCointMiner(false);

            // 2. Act
            var result = miner.FindValidNumber(secretKey);

            // 3. Assert
            Assert.AreEqual(1048970, result.LowestPossibleValue);
            Assert.AreEqual("000006136EF2FF3B291C85725F17325C", result.Hash);
        }

        [Test]
        public void FindKnownGoodKeyNo3Test()
        {
            // 1. Arrange
            const string secretKey = "yzbqklnj";
            var miner = new AdventCointMiner(true);

            // 2. Act
            var result = miner.FindValidNumber(secretKey);

            // 3. Assert
            Assert.AreEqual(9962624, result.LowestPossibleValue);
            Assert.AreEqual("0000004B347BF4B398B3F62ACE7CD301", result.Hash);
        }

        [Test]
        public void FindKnownGoodKeyNo4Test()
        {
            // 1. Arrange
            const string secretKey = "test";
            var miner = new AdventCointMiner(true);

            // 2. Act
            var result = miner.FindValidNumber(secretKey);

            // 3. Assert
            Assert.AreEqual(9159751, result.LowestPossibleValue);
            Assert.AreEqual("00000057252E17F3FC1823D3C8930DC2", result.Hash);
        }
    }
}