using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Day12
{
    [TestFixture]
    public class JsonAnalyzerTests
    {
        [Test]
        public void CountAllIntegers_Part1_Test()
        {
            // 1. Arrange
            var analyzer = new JsonAnalyzer();
            var datafile = File.ReadAllText("input.txt");

            // 2. Act
            var result = analyzer.CountIntegers(datafile, false);

            // 3. Assert
            Assert.AreEqual(156366, result.Sum(x => x));
        }

        [Test]
        public void CountAllIntegers_Part2_Test()
        {
            // 1. Arrange
            var analyzer = new JsonAnalyzer();
            var datafile = File.ReadAllText("input.txt");

            // 2. Act
            var result = analyzer.CountIntegers(datafile, true);

            // 3. Assert
            Assert.AreEqual(96852, result.Sum(x => x));
        }

        [TestCase("{\"a\":2,\"b\":4}", 6)]
        [TestCase("[1,2,3]", 6)]
        [TestCase("{\"a\":{\"b\":4},\"c\":-1}", 3)]
        [TestCase("[[[3]]]", 3)]
        [TestCase("{\"a\":[-1,1]}", 0)]
        [TestCase("[-1,{\"a\":1}]", 0)]
        [TestCase("{}", 0)]
        [TestCase("[]", 0)]
        [Test]
        public void CountAllIntegers_Samples_Test(string data, int sum)
        {
            // 1. Arrange
            var analyzer = new JsonAnalyzer();

            // 2. Act
            var result = analyzer.CountIntegers(data).Sum(x => x);

            // 3. Assert
            Assert.AreEqual(sum, result);
        }

        [TestCase("[1,2,3]", 6)]
        [TestCase("[1,{\"c\":\"red\",\"b\":2},3]", 4)]
        [TestCase("{\"d\":\"red\",\"e\":[1,2,3,4],\"f\":5}", 0)]
        [TestCase("[1,\"red\",5]", 6)]
        [TestCase("{\"c\": [\"red\", 1], \"c\":1}", 1)]
        [Test]
        public void CountIntegersWithOutRed_Samples_Test(string data, int sum)
        {
            // 1. Arrange
            var analyzer = new JsonAnalyzer();

            // 2. Act
            var result = analyzer.CountIntegers(data, true).Sum(x => x);

            // 3. Assert
            Assert.AreEqual(sum, result);
        }
    }
}
