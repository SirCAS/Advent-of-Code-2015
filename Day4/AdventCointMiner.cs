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

        public AdventCointMiner()
        {
            md5 = MD5.Create();
            stopwatch = new Stopwatch();
            maxTime = new TimeSpan(0, 1, 0);
        }

        public int FindValidNumber(string secretKey)
        {
            stopwatch = Stopwatch.StartNew();

            int i = 0;
            do
            {
                var result = CalculateMd5Hash(secretKey + i);

                if (result.StartsWith("00000"))
                {
                    stopwatch.Stop();

                    return i;
                }

                ++i;

            } while (stopwatch.Elapsed < maxTime);

            stopwatch.Stop();

            throw new TimeoutException("Execution time was longer than one minute - giving up...");
        }
     
        private string CalculateMd5Hash(string input)
        {
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(input));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}