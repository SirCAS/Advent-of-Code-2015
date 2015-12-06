using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day6
{
    internal class LightArraySimulator
    {
        private bool[,] grid = new bool[1000,1000];

        public void SimulateInstructions(IList<LightArrayInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                SimulateInstruction(instruction);
            }
        }

        public void SimulateInstruction(LightArrayInstruction instruction)
        {
            var start_row = instruction.Start.Item1;
            var start_col = instruction.Start.Item2;

            var end_row = instruction.End.Item1;
            var end_col = instruction.End.Item2;


            for (int row = start_row; row < end_row + 1; ++row)
            {
                for (int col = start_col; col < end_col + 1; ++col)
                {
                    switch (instruction.Action)
                    {
                        case LightArrayActionEnum.TurnOn:
                            grid[row, col] = true;
                            break;

                        case LightArrayActionEnum.TurnOff:
                            grid[row, col] = false;
                            break;

                        case LightArrayActionEnum.Toggle:
                            grid[row, col] = !grid[row, col];
                            break;
                    }
                }
            }
        }

        public int LightsOn
        {
            get
            {
                return grid.Cast<bool>().Count(b => b);
            }
        }
    }
}