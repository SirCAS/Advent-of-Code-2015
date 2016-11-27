using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Day21.ConsoleApplication
{
    public class Program
    {
        static List<List<Item>> GetPermutations(IEnumerable<Item> items)
        {
            var result = items.Select(x => new List<Item> { x }).ToList();

            foreach(var item1 in items)
            {
                foreach(var item2 in items)
                {
                    if(item1 != item2)
                    {
                        result.Add(new List<Item> { item1, item2 });
                    }
                }
            }

            return result;
        }


        private static List<List<Item>> Mutations()
        {
            var result = new List<List<Item>>();

            var ringItems = RolePlayGame.ShopItems.Where(x => x.Class == ItemClass.Rings);
            var ringCombinations = GetPermutations(ringItems);

            foreach(var weapon in RolePlayGame.ShopItems.Where(x => x.Class == ItemClass.Weapon))
            {
                foreach(var armor in RolePlayGame.ShopItems.Where(x => x.Class == ItemClass.Armor))
                {
                    foreach(var rings in ringCombinations)
                    {
                        var combination = new List<Item> { weapon, armor };
                        combination.AddRange(rings);
                        result.Add(combination);
                    }
                }
            }
            
            return result;
        }


        public static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 21 |");
            Console.WriteLine("+-------------------------+");
            
            List<Tuple<string,int>> playerWins = new List<Tuple<string,int>>();
            List<Tuple<string,int>> bossWins = new List<Tuple<string,int>>();

            foreach(var inventory in Mutations().ToList())
            {
                var boss = new Player
                {
                    Name = "Boss",
                    HitPoints = 100,
                    Items = new List<Item>
                    {
                        new Item { Class = ItemClass.Boss, Name = "Special boss item", Damage = 8, Armor = 2 }
                    }
                };

                var me = new Player { Name = "Player", HitPoints = 100, Items = inventory };

                var winner = RolePlayGame.Fight(me, boss);

                var strBuilder = new StringBuilder();
                strBuilder.Append($"A: {winner.Armor}, D: {winner.Damage}, HP: {winner.HitPoints}, I: ");
                foreach(var item in winner.Items)
                {
                    strBuilder.Append($"[N: {item.Name}, C: {item.Class}, C: {item.Cost} ]");
                }

                if(winner.Name == me.Name)
                {                    
                    playerWins.Add(new Tuple<string, int>(strBuilder.ToString(), inventory.Sum(x => x.Cost)));
                } else {
                    bossWins.Add(new Tuple<string, int>(strBuilder.ToString(), inventory.Sum(x => x.Cost)));
                }
            }

            var part1 = playerWins.OrderByDescending(x => x.Item2).Last();
            Console.WriteLine($"Best deal costs {part1.Item2}: {part1.Item1}");

            var part2 = bossWins.OrderBy(x => x.Item2).Last();
            Console.WriteLine($"Worst deal costs {part2.Item2}: {part2.Item1}");
            
            Console.WriteLine($"  -Gruss Gott");
        }
    }
}
