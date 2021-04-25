using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Models
{
    public struct Coord
    {
        public int X { get; }
        public int Y { get; }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
