using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Day21.ConsoleApplication
{
    public static class RolePlayGame
    {
        public static Player Fight(Player attacker, Player defender)
        {

            while(attacker.HitPoints > 0 && defender.HitPoints > 0)
            {
                int damage = attacker.Damage - defender.Armor;

                if(damage <= 0)
                {
                    damage = 1;
                }

                defender.HitPoints -= damage;
                Console.WriteLine($"{attacker.Name} deals {attacker.Damage} - {defender.Armor} = {damage} damage; {defender.Name} goes down to {defender.HitPoints} hitpoints");

                var tmp = defender;
                defender = attacker;
                attacker = tmp;
            }
            var winner = attacker.HitPoints > 0 ? attacker : defender;
            Console.WriteLine($"Winner is {winner.Name}");
            Console.WriteLine();
            return winner;
        }

        public static List<Item> ShopItems
        {
            get { return items; }
        }

        private static List<Item> items = new List<Item>
        {
            new Item { Class = ItemClass.Weapon, Name = "Dagger", Cost = 8, Damage = 4, Armor = 0 },
            new Item { Class = ItemClass.Weapon, Name = "Shortsword", Cost = 10, Damage = 5, Armor = 0 },
            new Item { Class = ItemClass.Weapon, Name = "Warhammer", Cost = 25, Damage = 6, Armor = 0 },
            new Item { Class = ItemClass.Weapon, Name = "Longsword", Cost = 40, Damage = 7, Armor = 0 },
            new Item { Class = ItemClass.Weapon, Name = "Greataxe", Cost = 74, Damage = 8, Armor = 0 },
            new Item { Class = ItemClass.Armor, Name = "None", Cost = 0, Damage = 0, Armor = 0 },
            new Item { Class = ItemClass.Armor, Name = "Leather", Cost = 13, Damage = 0, Armor = 1 },
            new Item { Class = ItemClass.Armor, Name = "Chainmail", Cost = 31, Damage = 0, Armor = 2 },
            new Item { Class = ItemClass.Armor, Name = "Splintmail", Cost = 53, Damage = 0, Armor = 3 },
            new Item { Class = ItemClass.Armor, Name = "Bandedmail", Cost = 75, Damage = 0, Armor = 4 },
            new Item { Class = ItemClass.Armor, Name = "Platemail", Cost = 102, Damage = 0, Armor = 5 },
            new Item { Class = ItemClass.Rings, Name = "None", Cost = 0, Damage = 0, Armor = 0 },
            new Item { Class = ItemClass.Rings, Name = "Damage +1", Cost = 25, Damage = 1, Armor = 0 },
            new Item { Class = ItemClass.Rings, Name = "Damage +2", Cost = 50, Damage = 2, Armor = 0 },
            new Item { Class = ItemClass.Rings, Name = "Damage +3", Cost = 100, Damage = 3, Armor = 0 },
            new Item { Class = ItemClass.Rings, Name = "Defense +1", Cost = 20, Damage = 0, Armor = 1 },
            new Item { Class = ItemClass.Rings, Name = "Defense +2", Cost = 40, Damage = 0, Armor = 2 },
            new Item { Class = ItemClass.Rings, Name = "Defense +3", Cost = 80, Damage = 0, Armor = 3 }
        };
    }
}