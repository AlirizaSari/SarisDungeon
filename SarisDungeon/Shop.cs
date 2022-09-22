using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SarisDungeon
{
    public class Shop
    {
        public static void LoadShop(Player p)
        {
            RunShop(p);
        }

        public static void RunShop(Player p)
        {
            int potionP;
            int armorP;
            int weaponP;
            int difP;

            while (true)
            {
                potionP = 20 + 10 * p.mods;
                armorP = 100 * (p.armorValue + 1);
                weaponP = 100 * p.weaponValue;
                difP = 300 + 100 * p.mods;

                Console.Clear();
                Console.WriteLine("          Shop          ");
                Console.WriteLine("========================");
                Console.WriteLine("(W)eapon:         $" + weaponP);
                Console.WriteLine("(A)rmor:          $" + armorP);
                Console.WriteLine("(P)otions:        $" + potionP);
                Console.WriteLine("(D)ifficulty Mod: $" + difP);
                Console.WriteLine("========================");
                Console.WriteLine("(E)xit");
                Console.WriteLine("(Q)uit");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(          "Stats"         );
                Console.WriteLine("========================");
                Console.WriteLine("Current Health: " + p.health);
                Console.WriteLine("Coins: " + p.coins);
                Console.WriteLine("Weapon Strength: " + p.weaponValue);
                Console.WriteLine("Weapon Toughness: " + p.armorValue);
                Console.WriteLine("Potions: " + p.potion);
                Console.WriteLine("Difficulty Mods: " + p.mods);

                Console.WriteLine("Xp:");
                Console.Write("[");
                Program.ProgressBar("+", " ", ((decimal)p.xp / (decimal)p.GetLevelUpValue()),25);
                Console.WriteLine("]");

                Console.WriteLine("Level: " + p.level);
                Console.WriteLine("========================");

                string input = Console.ReadLine().ToLower();
                if (input == "w" || input == "weapon")
                {
                    TryBuy("weapon", weaponP, p);
                }
                else if (input == "a" || input == "armor")
                {
                    TryBuy("armor", armorP, p);
                }
                else if (input == "p" || input == "potion")
                {
                    TryBuy("potion", potionP, p);
                }
                else if (input == "d" || input == "difficulty mod")
                {
                    TryBuy("dif", difP, p);
                }
                else if (input == "q" || input == "quit")
                {
                    Program.Quit();
                }
                else if (input == "e" || input == "exit")
                    break;
            }
        }
        static void TryBuy(string item, int cost, Player p)
        {
            if (p.coins >= cost)
            {
                if (item == "weapon")
                    p.weaponValue++;
                else if (item == "armor")
                    p.armorValue++;
                else if (item == "potion")
                    p.potion++;
                else if (item == "dif")
                    p.mods++;

                p.coins -= cost;
            }
            else
            {
                Console.WriteLine("Ya don't have enough gold!");
                Console.ReadKey();
            }
        }
    }
}
