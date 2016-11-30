using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day24.ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 24 |");
            Console.WriteLine("+-------------------------+");

            const int CompartmentCounter = 4;
            const string DatafileName = "input.txt";

            var input = File.ReadLines(DatafileName).Select(x => int.Parse(x)).ToList();

            var sum = input.Sum();
            var compartmentSize = sum / CompartmentCounter;

            Console.WriteLine($"Total package weight is {sum} which means {compartmentSize} should be stored in each compartment");

            var bestMatch = UInt64.MaxValue;
            for (var i = CompartmentCounter; i < input.Count; ++i)
            {
                foreach (var compartment in GetPermutations(input, i))
                {
                    if (compartment.Sum() == compartmentSize)
                    {
                        var etq = PackageProduct(compartment);
                        if (bestMatch > etq)
                        {
                            Console.WriteLine("{0} => ETQ: {1}", String.Join(",", compartment), etq);
                            bestMatch = etq;
                        }
                    }
                }
            }  

            Console.WriteLine("Search ended... ");

            Console.WriteLine($"  -Gruss Gott");
        }

        static ulong PackageProduct(IEnumerable<int> list)
        {
            ulong result = 1;
            foreach(var item in list)
                result *= (ulong) item;

            return result;
        }

        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
                return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                                 (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}