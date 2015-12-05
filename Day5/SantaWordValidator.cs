using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day5
{
    public static class SantaWordValidator
    {
        public static bool IsNice(string input)
        {
            var word = input.ToLowerInvariant().Trim('\n', '\t', '\r');

            // At least three vowels is needed
            var vowels = new HashSet<char> { 'a','e','i','o','u' };
            var numVowels = word.Count(x => vowels.Contains(x));
            if (numVowels < 3) return false;

            // No bad substrings
            var badSubStr = new List<string> { "ab", "cd", "pq", "xy" };
            if (badSubStr.Any(word.Contains)) return false;

            // At least one letter twice in a row
            for (int x = 1; x < word.Length; ++x)
            {
                if(word[x-1] == word[x]) return true;
            }

            return false;
        }

        public static bool IsNewNice(string input)
        {
            var word = input.ToLowerInvariant().Trim('\n', '\t', '\r');

            return HasRepeatOfLetterWithExcatlyOneBetween(word) && HasDoublePairThatIsNotConsecqutive(word);
        }

        private static bool HasDoublePairThatIsNotConsecqutive(string word)
        {
            for (int x = 3; x < word.Length; ++x)
            {
                var first  = word[x - 3];
                var second = word[x - 2];

                for (int y = 0; y + x < word.Length; ++y)
                {
                    var third  = word[x + y - 1];
                    var fourth = word[x + y];

                    if (first == third && second == fourth) return true;
                }
            }

            return false;
        }

        private static bool HasRepeatOfLetterWithExcatlyOneBetween(string word)
        {
            for (int x = 2; x < word.Length; ++x)
            {
                if (word[x - 2] == word[x]) return true;
            }

            return false;
        }

    }
}