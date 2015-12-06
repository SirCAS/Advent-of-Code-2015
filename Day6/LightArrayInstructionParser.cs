using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day6
{
    internal static class LightArrayInstructionParser
    {
        public static IList<LightArrayInstruction> ParseActions(IList<string> actions)
        {
            return actions.Select(ParseAction).ToList();
        }

        public static LightArrayInstruction ParseAction(string action)
        {
            var str = action.Trim('\n', '\t', '\r', ' ');

            var result = new LightArrayInstruction { Action = LightArrayActionEnum.Unknown, Start = null, End = null };

            {
                var instruction = "turn off";

                if (str.Contains(instruction))
                {
                    str = str.Remove(0, instruction.Length);
                    result.Action = LightArrayActionEnum.TurnOff;
                }
            }

            {
                var instruction = "turn on";

                if (str.Contains(instruction))
                {
                    str = str.Remove(0, instruction.Length);
                    result.Action = LightArrayActionEnum.TurnOn;
                }
            }

            {
                var instruction = "toggle";

                if (str.Contains(instruction))
                {
                    str = str.Remove(0, instruction.Length);
                    result.Action = LightArrayActionEnum.Toggle;
                }
            }

            str = str.Replace(" through ", ",");
            
            var numbers = str.Split(',').Select(Int32.Parse).ToArray();

            result.Start = new Tuple<int, int>(numbers[0], numbers[1]);
            result.End = new Tuple<int, int>(numbers[2], numbers[3]);

            return result;
        }
    }
}