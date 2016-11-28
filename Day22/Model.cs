using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Day22.ConsoleApplication
{
    public class Boss
    {
        public int HitPoints { get; set; }
        public int Damage { get; set;}
    }

    public class Player
    {
        public int HitPoints { get; set; }
        public int Mana { get; set; }
    }

    public class Spell
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }
        public int Damage { get; set; }
        public int Heal { get; set; }
        public int Armor { get; set; }
        public int Mana { get; set; }
        public int Timer { get; set; }
    }

   public enum GameResult
    {
        NotFinished,
        PlayerWon,
        BossWon
    }
}