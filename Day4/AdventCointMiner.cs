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
        private readonly bool isSixDigit;

        public AdventCointMiner(bool isSixDigit)
        {
            this.isSixDigit = isSixDigit;
            this.md5 = MD5.Create();
            this.stopwatch = new Stopwatch();
            this.maxTime = new TimeSpan(0, 3, 0);
        }

        public MiningResult FindValidNumber(string secretKey)
        {
            return isSixDigit? FindValidNumberWithSixZeros(secretKey) : FindValidNumberWithFiveZeros(secretKey);
        }

        public MiningResult FindValidNumberWithSixZeros(string secretKey)
        {
            stopwatch = Stopwatch.StartNew();

            int i = 0;
            do
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(secretKey + i));

                if (result[0] == (byte) 0 &&
                    result[1] == (byte) 0 &&
                    result[2] == (byte) 0)
                {
                    stopwatch.Stop();

                    StringBuilder sb = new StringBuilder();
                    foreach (byte t in result)
                    {
                        sb.Append(t.ToString("X2"));
                    }

                    return new MiningResult
                    {
                        LowestPossibleValue = i,
                        Hash = sb.ToString(),
                        ExecutionTime = stopwatch.Elapsed
                    };
                }

                ++i;

            } while (stopwatch.Elapsed < maxTime);

            stopwatch.Stop();

            throw new TimeoutException();
        }

        public MiningResult FindValidNumberWithFiveZeros(string secretKey)
        {
            stopwatch = Stopwatch.StartNew();

            int i = 0;
            do
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(secretKey + i));

                if (result[0] == (byte) 0 &&
                    result[1] == (byte) 0 &&
                    result[2] <= (byte) 14) // The max value in hex
                {
                    stopwatch.Stop();

                    StringBuilder sb = new StringBuilder();
                    foreach (byte t in result)
                    {
                        sb.Append(t.ToString("X2"));
                    }

                    return new MiningResult
                    {
                        LowestPossibleValue = i,
                        Hash = sb.ToString(),
                        ExecutionTime = stopwatch.Elapsed
                    };
                }

                ++i;

            } while (stopwatch.Elapsed < maxTime);

            stopwatch.Stop();

            throw new TimeoutException();
        }
    }
}