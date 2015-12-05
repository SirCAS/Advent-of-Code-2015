using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Day4
{
    public class AdventCointMiner
    {
        private Stopwatch stopwatch;
        private readonly MD5 md5;
        private readonly TimeSpan maxTime;
        private readonly string hashPattern;

        public AdventCointMiner(string hashPattern)
        {
            this.hashPattern = hashPattern;
            this.md5 = MD5.Create();
            this.stopwatch = new Stopwatch();
            this.maxTime = new TimeSpan(0, 1, 30);
        }

        public MiningResult FindValidNumber(string secretKey)
        {
            stopwatch = Stopwatch.StartNew();

            int i = 0;
            do
            {
                var result = CalculateMd5Hash(secretKey + i);

                if (result.StartsWith(hashPattern))
                {
                    stopwatch.Stop();

                    return new MiningResult
                    {
                        LowestPossibleValue = i,
                        Hash = result,
                        ExecutionTime = stopwatch.Elapsed
                    };
                }

                ++i;

            } while (stopwatch.Elapsed < maxTime);

            stopwatch.Stop();

            throw new TimeoutException();
        }
     
        private string CalculateMd5Hash(string input)
        {
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(input));

            StringBuilder sb = new StringBuilder();
            foreach (byte t in hash)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}