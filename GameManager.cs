using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObject
{
    public static class GameManager
    {
        public static Player Player { get; private set; }

        public static Entrance Entrance { get; private set; }

        public static TheFountain TheFountain { get; private set; }

        public static World World { get; private set; }

        private static bool IsWin { get; set; }
        public static bool IsFountainActive { get; set; }

        public static void Init()
        {
            Entrance = new Entrance();
            Player = new Player();
            TheFountain = new TheFountain();
            IsFountainActive = false;
            IsWin = false;
        }


        public static World MapGen()
        {
                Console.WriteLine("Choice size of the map you want to create");
                Console.WriteLine("1 - Create small map 4x4");
                Console.WriteLine("2 - Create medium map 6x6");
                Console.WriteLine("3 - Create large map 8x8");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        return World.CreateSmallWorld();
                    case 2:
                        return World.CreateMediumWorld();
                    case 3:
                        return World.CreateLargeWorld();
                    default:
                        Console.WriteLine("Wrong input");
                    return null;
                }
        }

        static World newWorld = MapGen(); 
        public static void Run()
        {
            Player.UpdateCurrentPlayerLocation(Player.playerLocation);
            Player.Sense(Player.playerLocation);
            while (true)
            {
                if (Player.IsAlive)
                {
                    Console.WriteLine("What do you want do do ?");
                    string input = Convert.ToString(Console.ReadLine());
                    if (input == "enable fountain" && Player.playerLocation.Equals(TheFountain.Point))
                    {
                        IsFountainActive = true;
                    }
                    Player.Move(input);
                    Player.isDead(Player.playerLocation, newWorld);
                    Player.UpdateCurrentPlayerLocation(Player.playerLocation);

                    if (Player.playerLocation.Equals(Entrance.Point) && IsFountainActive)
                    {
                        Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
                        Console.WriteLine("You Win!");
                        break;
                    }
                    else
                    {
                        Player.Sense(Player.playerLocation);
                    }
                }
                else
                {
                    Console.Write("YouDead");
                    break;
                }
            }
        }
    }
}