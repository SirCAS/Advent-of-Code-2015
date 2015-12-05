using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day2
{
    public static class WrappingPaperCalculator
    {
        public static int CalculateNeededPaperFromStrList(string presentList)
        {
            var presents = ExtractPresents(presentList);

            return CalculateNeededPaperFromList(presents);
        }

        public static int CalculateNeededPaperForModel(PresentModel model)
        {
            var data = new List<int> { model.Length * model.Width, model.Width * model.Height, model.Height * model.Length };

            return 2 * data.ElementAt(0) + 2 * data.ElementAt(1) + 2 * data.ElementAt(2) + data.Min();
        }

        public static int CalculateNeededPaperFromList(IList<PresentModel> model)
        {
            return model.Sum(x => CalculateNeededPaperForModel(x));
        }

        private static IList<PresentModel> ExtractPresents(string input)
        {
            // Find lines in input and divide them into a list
            var presentStrs = input.Split('\n').Select(x => x.Trim());

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
