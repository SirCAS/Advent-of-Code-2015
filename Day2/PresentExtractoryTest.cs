using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Day2
{
    [TestFixture]
    public class PresentExtractorTest
    {
        [Test]
        public void ExtractThreePresentsTest()
        {
            // 1. Arrange
            var data = "29x13x26 \n 11x11x14 \r\n 27x2x5";

            IList<PresentModel> result = null;

            // 2. Act + 3. Assert
            Assert.DoesNotThrow( delegate { result = PresentExtractor.ExtractPresents(data); });
            Assert.AreEqual(3, result.Count);
        }
    }
}
