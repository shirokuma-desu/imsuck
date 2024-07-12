using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObject
{
    public abstract class Room
    {
        public Point Point { get; private set; }

        protected Room(Point p)
        {
            this.Point = p;
        }

    }
}
