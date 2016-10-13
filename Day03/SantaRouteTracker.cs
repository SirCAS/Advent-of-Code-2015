using System;
using System.Collections.Generic;

namespace AdventOfCode.Day3
{
    public static class SantaRouteTracker
    {
        public static IDictionary<Tuple<int, int>, int> Run(char[] instructions)
        {
            IDictionary<Tuple<int, int>, int> routeStatistics = new Dictionary<Tuple<int, int>, int>
            {
                {new Tuple<int, int>(0, 0), 1 }
            };

            // Each house position is contained in Tuple<int, int> aka x,y
            // Each house position have a finite number of gifts as specified by the key in the IDictionary
            int x = 0, y = 0;

            // Loop through all instructions
            foreach (var instruction in instructions)
            {
                // Interpret instruction
                switch (instruction)
                {
                    case '>': ++x; break;
                    case '<': --x; break;
                    case '^': --y; break;
                    case 'v': ++y; break;
                    default: continue; // Skip if not reconized
                }

                // Determine if we're at already visited house - if so increment packages delivered
                if (routeStatistics.ContainsKey(new Tuple<int, int>(x, y)))
                {
                    ++routeStatistics[new Tuple<int, int>(x, y)];
                }
                else
                {
                    // New house thus we save adresse (x, y) and set present count to 1
                    routeStatistics.Add(new KeyValuePair<Tuple<int, int>, int>(new Tuple<int, int>(x, y), 1));
                }
            }

            return routeStatistics;
        }
    }
}
