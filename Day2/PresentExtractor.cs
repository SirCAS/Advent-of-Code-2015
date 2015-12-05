using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day2
{
    public class PresentExtractor
    {
        public static IList<PresentModel> ExtractPresents(string presentStrings)
        {
            // Find lines in input and divide them into a list
            var presentStrs = presentStrings.Split('\n').Select(x => x.Trim());

            // For each line find x'es and divide them into chunks
            var dimensionsStrs = presentStrs.Select(x => x.Split('x'));

            // Take all chucks for each line and convert them into a present model accordingly
            return dimensionsStrs.Select(x => new PresentModel
            {
                Height = Int32.Parse(x[0]),
                Length = Int32.Parse(x[1]),
                Width = Int32.Parse(x[2])
            }).ToList();
        }

    }
}
