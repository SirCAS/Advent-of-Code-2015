namespace AdventOfCode.Day7.Common
{
    public static class StringExtension
    {
        public static string GetPartBetween(this string input, int startPos, int endPos)
        {
            return input.Substring(startPos, endPos - startPos).Trim();
        }

        public static string GetComponentMiddlePart(this string input, string type, string arrow)
        {
            return input.GetPartBetween(input.IndexOf(type) + type.Length, input.IndexOf(arrow));
        }

        public static string GetComponentFirstPart(this string input, string type)
        {
            return input.GetPartBetween(0, input.IndexOf(type));
        }

        public static string GetComponentLastPart(this string input, string type)
        {
            return input.GetPartBetween(input.IndexOf(type) + type.Length, input.Length);
        }
    }
}