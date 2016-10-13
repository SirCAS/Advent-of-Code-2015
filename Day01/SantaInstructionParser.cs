using System.Linq;

namespace AdventOfCode.Day1
{
    public static class SantaInstructionParser
    {
        /// <summary>
        /// Find the ending floor no based on a string with instructions
        /// The instructions consists of a string containing the charcters ")" and "(".
        /// ")" means go up and "(" means go down.
        /// It assumed that there's no final floors in the building thus infinite levels is possible
        /// </summary>
        /// <param name="instructions">The intructions</param>
        /// <returns>The floor at which santa ends</returns>
        public static int FindEndingFloorNo(string instructions)
        {
            var ups = instructions.ToCharArray().Where(x => x == '(').Count();

            var downs = instructions.Length - ups;

            return ups - downs;
        }

        /// <summary>
        /// Find the position of which character that causes santa to enter the basement (floor -1)
        /// The first character in the instructions has position 1
        /// If the basement is never hit then zero is returned
        /// </summary>
        /// <param name="instructions">The instructions</param>
        /// <returns>The position of the character for the basement</returns>
        public static int FindFirstCharPositionForBasement(string instructions)
        {
            int floor = 0;

            for (int x = 0; x < instructions.Length; ++x)
            {
                if (instructions[x] == ')') --floor;
                if (instructions[x] == '(') ++floor;

                if (floor == -1) return x + 1;
            }

            return 0;
        }
    }
}
