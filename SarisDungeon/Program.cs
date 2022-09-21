using System.Numerics;
using System.Xml.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SarisDungeon
{
    public class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainloop = true;
        static void Main(string[] args)
        {
            Start();
            Encounters.FirstEncounter();
            while (mainloop)
            {
                Encounters.RandomEncounter();
            }

        }

        static Player Start()
        {
            Console.Clear();
            Player p = new Player();
            Console.WriteLine("Sari's Dungeon!");
            Console.WriteLine("Name:");
            p.name = Console.ReadLine();
            Console.WriteLine("Class: Mage  Ranger  Warrior");
            bool flag = false;
            while (flag == false)
            {
                flag = true;
                string input = Console.ReadLine().ToLower();
                if (input == "mage")
                    p.currentClass = Player.PlayerClass.Mage;
                else if (input == "ranger")
                    p.currentClass = Player.PlayerClass.Ranger;
                else if (input == "Warrior")
                    p.currentClass = Player.PlayerClass.Warrior;
                else
                {
                    Console.WriteLine("Please choose a existing class!");
                    flag = false;
                }
            }
            Console.Clear();
            Console.WriteLine("You awake in a cold, stone, dark room. You feel dazed and are having trouble remembering");
            Console.WriteLine("anything about your past.");
            if (p.name == "")
                Console.WriteLine("You can't even remember your own namee...");
            else
                Console.WriteLine("You know your name is " + p.name);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You grope around in the darkness until you find a door handle. You feel some resistance as");
            Console.WriteLine("you turn the handle but the rusty lock breaks with little effort. You see your captor");
            Console.WriteLine("standing with his back to you outside the door.");
            return p;

        }

        public static void Quit()
        {
            Environment.Exit(0);
        }
    }
}