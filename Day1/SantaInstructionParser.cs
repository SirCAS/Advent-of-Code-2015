using System.Linq;

namespace AdventOfCode
{
    public static class SantaInstructionParser
    {
        /// <summary>
        /// Parses instructions for an apartment building
        /// The instructions consists of a string containing the charcters ")" and "(".
        /// ")" means go up and "(" means go down.
        /// It assumed that there's no final floors in the building thus infinite levels is possible
        /// </summary>
        /// <param name="instructions">The intructions</param>
        /// <returns>The floor at which santa ends</returns>
        public static int ParseIntructions(string instructions)
        {
            var ups = instructions.ToCharArray().Where(x => x == '(').Count();

            var downs = instructions.Length - ups;

            return ups - downs;
        }

    }
}
