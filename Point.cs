using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObject
{
    public struct Point(int x, int y)
    {
        public int x { get; set; } = x;
        public int y { get; set; } = y;
    }
}
