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
    }
}