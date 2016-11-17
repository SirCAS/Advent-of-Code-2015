using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day14.ConsoleApplication
{
    public static class OlympicsSimulator
    {
        public static IEnumerable<Reindeer> Simulate(string dataFile, int ticks)
        {
            // Load data from input file
            var reendeers = File.ReadAllLines(dataFile)
                .Select(x => x.Split(' '))
                .Select(x => new Reindeer(x[0], int.Parse(x[3]), int.Parse(x[6]), int.Parse(x[13])))
                .ToList();
            
            // Simulate
            for(int tick=0; tick<ticks; ++tick)
            {
                // Update odometers
                reendeers.ForEach(x => x.Tick());

                // Reward winners for this tick
                reendeers.Where(x => x.Odometer == reendeers.Max(y => y.Odometer)).ForEach(z => z.IncrementScore());
            }

            return reendeers;
        }
    }
}