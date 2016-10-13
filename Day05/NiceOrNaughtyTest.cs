using NUnit.Framework;

namespace AdventOfCode.Day5
{
    [TestFixture]
    public class NiceOrNaughtyTest
    {
        #region Old Nice Tests

        [Test]
        public void NiceWordNo1Test()
        {
            // 1. Arrange
            const string word = "ugknbfddgicrmopn";

            // 2. Act
            var result = SantaWordValidator.IsNice(word);

            // 3. Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void NiceWordNo2Test()
        {
            // 1. Arrange
            const string word = "aaa";

            // 2. Act
            var result = SantaWordValidator.IsNice(word);

            // 3. Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void NiceWordNo3Test()
        {
            // 1. Arrange
            const string word = "aeiouu";

            // 2. Act
            var result = SantaWordValidator.IsNice(word);

            // 3. Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void NaughtyWordNo1Test()
        {
            // 1. Arrange
            const string word = "jchzalrnumimnmhp";

            // 2. Act
            var result = SantaWordValidator.IsNice(word);

            // 3. Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void NaughtyWordNo2Test()
        {
            // 1. Arrange
            const string word = "haegwjzuvuyypxyu";

            // 2. Act
            var result = SantaWordValidator.IsNice(word);

            // 3. Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void NaughtyWordNo3Test()
        {
            // 1. Arrange
            const string word = "dvszwmarrgswjxmb";

            // 2. Act
            var result = SantaWordValidator.IsNice(word);

            // 3. Assert
            Assert.IsFalse(result);
        }

        #endregion

        #region New Nice Tests

        [Test]
        public void NewNiceWordNo1Test()
        {
            // 1. Arrange
            const string word = "qjhvhtzxzqqjkmpb";

            // 2. Act
            var result = SantaWordValidator.IsNewNice(word);

            // 3. Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void NewNiceWordNo2Test()
        {
            // 1. Arrange
            const string word = "xxyxx";

            // 2. Act
            var result = SantaWordValidator.IsNewNice(word);

            // 3. Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void NewNaughtyWordNo1Test()
        {
            // 1. Arrange
            const string word = "uurcxstgmygtbstg";

            // 2. Act
            var result = SantaWordValidator.IsNewNice(word);

            // 3. Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void NewNaughtyWordNo2Test()
        {
            // 1. Arrange
            const string word = "ieodomkazucvgmuy";

            // 2. Act
            var result = SantaWordValidator.IsNewNice(word);

            // 3. Assert
            Assert.IsFalse(result);
        }

        #endregion
    }
}