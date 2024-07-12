using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObject
{
    public class World
    {
        public Point grid2DSize {  get; private set; }

        public World(int x, int y)
        {
            grid2DSize = new Point(x, y);
        }

        public static World CreateSmallWorld() => new World(4, 4);

        public static World CreateMediumWorld() => new World(6, 6);
        public static World CreateLargeWorld() => new World(8, 8);

    }
}