using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day25.ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 25 |");
            Console.WriteLine("+-------------------------+");
            Console.WriteLine();

            // Puzzle input
            int input_row = 2947;
            int input_column = 3029;
            const int input_seed = 20151125;

            // Factors for algoritem
            const ulong mulFactor = 252533;
            const ulong divFactor = 33554393;

            // The number of rows and columns are the same
            // Summing any coordinate components and subtracting with one seems to be the size
            int size = input_row + input_column - 1;

            // We will work with rows and columns as zero-index based
            --input_row;
            --input_column;
            
            // Create grid for us to work with
            var grid = new ulong[size, size];

            // Add first value
            grid[0,0] = input_seed;

            // Get position lut
            var lut = GenerateLookupTable(size);

            // Initialze algoritem with seed value
            ulong previousValue = input_seed;

            int it = 1;
            do
            {
                ++it;
                
                // Calculate next value from previous
                ulong s1 = previousValue * mulFactor;
                ulong s2 = s1 % divFactor;

                // Store value at appropiate coordinates from LUT
                var currentPos = lut[it];
                grid[currentPos.Item1, currentPos.Item2] = s2;

                // Prepare for next iteration
                previousValue = s2;

            } // Keep looping untill solution is found at coordinates
            while(lut[it].Item1 != input_column && lut[it].Item2 != input_row);

            // Print table from manual (should match values from puzzle description)
            Console.WriteLine("   |    1         2         3         4         5         6     ");
            Console.WriteLine("---+---------+---------+---------+---------+---------+---------+");
            for(int y=0; y<6; y++)
            {
                Console.Write($" {y} |");
                for(int x=0; x<6; x++)
                    Console.Write(grid[x, y].ToString().PadLeft(9) + " ");

                Console.WriteLine();
            }
            Console.WriteLine();

            // If table above matches then this is the solution
            Console.WriteLine($"Solution is {previousValue}");

            Console.WriteLine($"  -Gruss Gott");
        }

        static Dictionary<int, Tuple<int, int>> GenerateLookupTable(int size)
        {
            // Create lut instance
            var lookup = new Dictionary<int, Tuple<int, int>>(); 
            
            int key = 0;
            for(int y=0; y<size; ++y)
            {
                int tmpY = y, x = 0;
                while(x <=y)
                {
                    lookup.Add(++key, new Tuple<int, int>(x++, tmpY--));
                }
            }
            return lookup;
        }
    }
}