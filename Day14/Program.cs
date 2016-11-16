using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day14.ConsoleApplication
{
    public class Reindeer
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int MoveTime { get; set; }
        public int RestTime { get; set; }
        public int TraveledDistance(int elapsedTime)
        {
            int distance = 0;

            int times = elapsedTime / (MoveTime + RestTime);

            int remainder = elapsedTime % ((MoveTime + RestTime) * times);

            if(remainder >= MoveTime)
            {
                ++times;
            }
            else
            {
                distance += remainder * Speed;
            }

            distance += times * Speed * MoveTime;

            return distance;
        }
    }

    public class Program
    {
        private const string DataFileName = "input.1.txt";

        public static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 14 |");
            Console.WriteLine("+-------------------------+");

            var datafile = File.ReadAllLines(DataFileName);

            var travelTime = 2503;
            //var travelTime = 1000;

            var reendeers = datafile
                .Select(x => x.Split(' '))
                .Select(x => new Reindeer
                {
                    Name = x[0],
                    Speed = int.Parse(x[3]),
                    MoveTime = int.Parse(x[6]),
                    RestTime = int.Parse(x[13])
                });
            
            foreach(var reendeer in reendeers)
            {
                Console.WriteLine("{0} has travled {1} km", reendeer.Name, reendeer.TraveledDistance(travelTime));
            }

            var winner = reendeers.OrderByDescending(x => x.TraveledDistance(travelTime)).First();
            Console.WriteLine("Winner is {0} with {1} km", winner.Name, winner.TraveledDistance(travelTime));

            Console.WriteLine($"  -Gruss Gott");
        }
    }
}
