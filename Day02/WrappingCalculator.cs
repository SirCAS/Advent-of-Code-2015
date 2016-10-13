using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day2
{
    public static class WrappingCalculator
    {
        public static int CalculateNeededPaper(IList<PresentModel> model)
        {
            return model.Sum(x => x.NeededPaper);
        }

        public static int CalculateNeededRibbon(IList<PresentModel> model)
        {
            return model.Sum(x => x.NeededRibbon);
        }

    }
}
