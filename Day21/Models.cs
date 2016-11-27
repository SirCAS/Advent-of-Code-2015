using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Day21.ConsoleApplication
{
    public class Player
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Damage { get { return Items.Sum(x => x.Damage); } }
        public int Armor { get { return Items.Sum(x => x.Armor); } }
        public List<Item> Items { get; set;}
    }

    public enum ItemClass
    {
        Weapon, Armor, Rings, Boss
    }

    public class Item
    {
        public string Name { get; set; }
        public ItemClass Class { get; set; }
        public int Cost { get; set;}
        public int Damage { get; set; }
        public int Armor { get; set; }
    }
}
