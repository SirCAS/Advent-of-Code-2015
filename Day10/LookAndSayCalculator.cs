using System.Text;

namespace Day10
{
    public class LookAndSayCalculator
    {
        public string Process(int times, string input)
        {
            for(int x=0; x<times; ++x)
            {
                input = ProcessOneIteration(input);
            }

            return input;
        }

        private string ProcessOneIteration(string input)
        {
            StringBuilder result = new StringBuilder();

            char pre = input[0];
            int occurence = 1;
            for(int x=1; x<input.Length; ++x)
            {
                if(pre == input[x])
                {
                    ++occurence;
                } else {
                    result.Append(occurence);
                    result.Append(pre);
                    
                    pre = input[x];
                    occurence = 1;
                }
            }

            result.Append(occurence);
            result.Append(pre);

            return result.ToString();
        }
    }
}