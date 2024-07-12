using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObject
{
    public class Player
    {
        public bool IsAlive { get; private set; }

        private const int STEP = 1;

        public Point playerLocation { get; private set; }

        TheFountain theFountain = new();
        Entrance entrance = new();

        public Player()
        {
            playerLocation = new Point(0, 0);
            IsAlive = true;
        }

        public void Move(string input)
        {
            switch (input)
            {
                case "east":
                    playerLocation = new (playerLocation.x + STEP, playerLocation.y);
                    break;

                case "west":
                    playerLocation = new (playerLocation.x - STEP, playerLocation.y);
                    break;

                case "south":
                    playerLocation = new (playerLocation.x, playerLocation.y - STEP);
                    break;

                case "north":
                    playerLocation = new ( playerLocation.x, playerLocation.y + STEP);
                    break;
            }
        }
        

        public void UpdateCurrentPlayerLocation(Point currentLocation)
        {
            Console.WriteLine("You are in the room at (Row = " + playerLocation.y +", Column = "+playerLocation.x +" )");
        }

        public void isDead(Point currentLocation, World currentWorld)
        {
            if(currentLocation.x > currentWorld.grid2DSize.x || currentLocation.y > currentWorld.grid2DSize.y ||
                currentLocation.x < 0 || currentLocation.y < 0)
            {
                IsAlive = false;
            }
        }

        public void Sense(Point currentLocation)
        {
            
            if (currentLocation.Equals(entrance.Point))
            {
                Console.WriteLine("You see light coming from the cavern entrance.");
            }
            else if (currentLocation.Equals(theFountain.Point) && !GameManager.IsFountainActive)
            {
                Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here! ");
            }
            else if (currentLocation.Equals(theFountain.Point) && GameManager.IsFountainActive)
            {
                Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
            }
        }
    }
   
}