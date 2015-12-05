using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day3
{
    public class SantaStatistics
    {
        private readonly IDictionary<string, char[]> santaData = new Dictionary<string, char[]>();

        private char[] instructions;

        public void AddSanta(string name)
        {
            santaData.Add(new KeyValuePair<string, char[]>(name, null));
        }

        public void SetRoute(string completeRoute)
        {
            instructions = completeRoute.Trim('\n', '\r', '\t').ToCharArray();
        }

        private void UpdateRoute()
        {
            var dividedInstructions = instructions.ToList()
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index % santaData.Count)
                .ToDictionary(x => x.Key, y => y.Select(u => u.Value).ToArray());

            int routeIndex = 0;
            foreach (var santaKey in santaData.Keys.ToList())
            {
                santaData[santaKey] = dividedInstructions[routeIndex++];
            }
        }

        public int CountHousesWithGifts(int minimumRequiredGifts)
        {
            if (santaData.Values.Any(x => x == null)) { UpdateRoute(); }

            IEnumerable<KeyValuePair<Tuple<int, int>, int>> coveredHouses = new Dictionary<Tuple<int, int>, int>();

            coveredHouses = santaData.Aggregate(coveredHouses, (current, santa) => current.Concat(SantaRouteTracker.Run(santa.Value)));

            return coveredHouses
                .GroupBy(x => x.Key, x => x.Value)
                .ToDictionary(y => y.Key, y => y.Sum(z => z))
                .Values.Count(x => x >= minimumRequiredGifts);
        }
    }
}