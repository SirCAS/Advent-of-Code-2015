using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Day22.ConsoleApplication
{
    public class Program
    {
        private static Random random = new Random();
        private static int? minimumManaWin = null;
        private static int usedMana;
        private static Player player;
        private static Boss boss;
        private static List<Spell> spells;
        private static List<Spell> activeSpells;

        public static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 22 |");
            Console.WriteLine("+-------------------------+");
            
            for(int x=0; x< 100000; ++x)
            {
                Restart();
                var result = PlayGame();
                if(result == GameResult.PlayerWon)
                {
                    if(!minimumManaWin.HasValue || usedMana < minimumManaWin.Value)
                    {
                        minimumManaWin = usedMana;
                    }
                }
            }

            Console.WriteLine($"Best game costs {minimumManaWin.GetValueOrDefault()} mana");
            
            Console.WriteLine($"  -Gruss Gott");
        }

        public static void ApplyEffects()
        {
            int effectDamage = activeSpells.Sum(x => x.Damage);
            int effectMana = activeSpells.Sum(x => x.Mana);

            if(effectDamage > 0)
            {
                boss.HitPoints -= effectDamage;
            }

            if(effectMana > 0)
            {
                player.Mana += effectMana;
            }

            // Update timer on effects
            foreach(var effect in activeSpells) effect.Timer++;

            // Remove timedout effect
            activeSpells = activeSpells.Where(x => x.Timer < x.Duration).ToList();
        }

        public static void PlayerTurn(Spell spell)
        {
            if(spell.Duration > 1)
            {
                spell.Timer = 0;
                activeSpells.Add(spell);
            }
            else
            {
                boss.HitPoints -= spell.Damage;
                player.HitPoints += spell.Heal;
            }
        }

        public static void BossTurn()
        {
            int effectArmor = activeSpells.Sum(x => x.Armor);

            var damage = boss.Damage - effectArmor;
            
            if(damage < 1)
                damage = 1;

            player.HitPoints -= damage;
        }

        public static GameResult CheckWinner()
        {
            if(player.HitPoints <= 0)
            {
                return GameResult.BossWon;
            }

            if(boss.HitPoints <= 0)
            {
                return GameResult.PlayerWon;
            }

            return GameResult.NotFinished;
        }

        public static GameResult PlayGame()
        {
            GameResult result;
            while(true)
            {
                // Quick and dirty part 2 implementation...
                // player.HitPoints--;
                // result = CheckWinner();
                // if(result != GameResult.NotFinished) return result;

                ApplyEffects();

                result = CheckWinner();
                if(result != GameResult.NotFinished) return result;

                var spell = BuySpell();
                if(spell == null) return GameResult.NotFinished;

                PlayerTurn(spell);

                result = CheckWinner();
                if(result != GameResult.NotFinished) return result;

                ApplyEffects();

                result = CheckWinner();
                if(result != GameResult.NotFinished) return result;

                BossTurn();

                result = CheckWinner();
                if(result != GameResult.NotFinished) return result;
            }
        }

        public static void Restart()
        {
            usedMana = 0;
            player = new Player { HitPoints = 50, Mana = 500 };
            boss = new Boss { HitPoints = 55, Damage = 8 };
            activeSpells = new List<Spell>();
            spells = new List<Spell>
            {
                new Spell { Name = "Magic Missile", Cost = 53,  Duration = 1, Damage = 4, Armor = 0, Heal = 0, Mana = 0   },
                new Spell { Name = "Drain",         Cost = 73,  Duration = 1, Damage = 2, Armor = 0, Heal = 2, Mana = 0   },
                new Spell { Name = "Shield",        Cost = 113, Duration = 6, Damage = 0, Armor = 7, Heal = 0, Mana = 0   },
                new Spell { Name = "Poison",        Cost = 173, Duration = 6, Damage = 3, Armor = 0, Heal = 0, Mana = 0   },
                new Spell { Name = "Recharge",      Cost = 229, Duration = 5, Damage = 0, Armor = 0, Heal = 0, Mana = 101 }
            };
        }

        public static Spell BuySpell()
        {
            var possibleSpells = spells
                .Where(x => activeSpells.All(y => y.Name != x.Name)) // Active spells cannot be added
                .Where(x => x.Cost <= player.Mana) // Must be affordable
                .Where(x => minimumManaWin.HasValue ? (minimumManaWin.Value > x.Mana + usedMana) : true) // Must be a better solution
                .ToList();

            if(possibleSpells.Any())
            {
                var spell = possibleSpells[random.Next(possibleSpells.Count)];
                player.Mana -= spell.Cost;
                usedMana += spell.Cost;
                return spell;
            }

            return null;
        }
    }
}