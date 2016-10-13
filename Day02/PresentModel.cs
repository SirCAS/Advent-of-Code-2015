using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day2
{
    public class PresentModel
    {
        public int Length { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public int NeededPaper
        {
            get
            {
                var data = new List<int> { Length * Width, Width * Height, Height * Length };

                return data.Select(x => x * 2).Sum() + data.Min();
            }
        }

        public int NeededRibbon
        {
            get
            {
                return new List<int> { Length , Width, Height }.OrderBy(x => x).Take(2).Select(x => x * 2).Sum() + Length*Height*Width;
            }
        }
    }
}
