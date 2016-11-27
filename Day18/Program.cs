using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day18.ConsoleApplication
{
    public static class ExtensionMethods
    {
        public static void Print(this bool[][] grid)
        {
            foreach(var line in grid)
            {
                foreach(var light in line)
                {
                    Console.Write(light ? '#' : '.');
                }
                Console.WriteLine();
            }
            
            Console.WriteLine();
        }

        public static void Tick(this bool[][] grid, int ticks)
        {
            for(int x = 0; x<ticks; ++x)
            {
                Tick(grid);
            }
        }

        public static int TurnedOnLights(this bool[][] grid)
        {
            return grid.SelectMany(x => x).Count(x => x);
        }

        public static void Tick(this bool[][] grid)
        {
            // All of the lights update simultaneously; they all consider the same current state before moving to the next.
            int size = grid.Length;
            var newGrid = new bool[size][];

            for(int x=0; x<size; ++x)
            {
                newGrid[x] = new bool[size];
                for(int y=0; y<size; ++y)
                {
                    var isOn = grid[x][y];
                    var neighbors = GetNeighbors(grid, x, y);

                    if(isOn) // A light which is on stays on when 2 or 3 neighbors are on, and turns off otherwise.
                    {                    
                        if(neighbors == 2 || neighbors == 3)
                        {
                            newGrid[x][y] = true;
                        } else {
                            newGrid[x][y] = false;
                        }
                    }
                    else
                    { // A light which is off turns on if exactly 3 neighbors are on, and stays off otherwise.
                        if(neighbors == 3)
                        {
                            newGrid[x][y] = true;
                        } else {
                            newGrid[x][y] = false;
                        }
                    }
                }
            }

            // Defective bulbs
            newGrid[0][0] = true;
            newGrid[0][size-1] = true;
            newGrid[size-1][0] = true;
            newGrid[size-1][size-1] = true;

            // Overwrite exsisting grid
            for(int x=0; x<size; ++x)
                grid[x] = newGrid[x];
        }

        private static int GetNeighbors(bool[][] grid, int x, int y)
        {
            int neighbors = 0;
            int s = grid.Length - 1;
            //      x           
            //  +--------
            //  | 1  2  3
            // y| 4  X  5
            //  | 6  7  8 
            //
            if(x > 0 && y > 0 && grid[x - 1][y - 1]) ++neighbors; // 1
            if(y > 0 &&          grid[  x  ][y - 1]) ++neighbors; // 2
            if(x < s && y > 0 && grid[x + 1][y - 1]) ++neighbors; // 3
            if(x > 0 &&          grid[x - 1][  y  ]) ++neighbors; // 4
            if(x < s &&          grid[x + 1][  y  ]) ++neighbors; // 5
            if(x > 0 && y < s && grid[x - 1][y + 1]) ++neighbors; // 6
            if(y < s &&          grid[  x  ][y + 1]) ++neighbors; // 7
            if(x < s && y < s && grid[x + 1][y + 1]) ++neighbors; // 8
            return neighbors;
        }

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 18 |");
            Console.WriteLine("+-------------------------+");

            //const int steps = 4;
            //const string DataFileName = "input.1.txt";
            const int steps = 100;
            const string DataFileName = "input.txt";

            // Load data from input file
            var grid = File.ReadAllLines(DataFileName)
                .Select(
                    x => x.Select(y => y == '#' ? true : false)
                          .ToArray())
                .ToArray();


            // Defective bulbs
            var size = grid.Length; 
            grid[0][0] = true;
            grid[0][size-1] = true;
            grid[size-1][0] = true;
            grid[size-1][size-1] = true;

            grid.Tick(steps);

            var turnedOnLights = grid.TurnedOnLights();

            Console.WriteLine($"There is {turnedOnLights} after {steps}");

            Console.WriteLine($"  -Gruss Gott");
        }
    }
}
