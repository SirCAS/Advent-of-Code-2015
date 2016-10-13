using System;

namespace AdventOfCode.Day6
{
    public class LightArrayInstruction
    {
        public LightArrayActionEnum Action { get; set; }
        public Tuple<int, int> Start { get; set; }
        public Tuple<int, int> End { get; set; }
    }
}