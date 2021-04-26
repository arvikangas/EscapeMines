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

        public static Coord operator +(Coord c1, Coord c2) => new Coord(c1.X + c2.X, c1.Y + c2.Y);

        public static Coord Up = new Coord(0, 1);
        public static Coord Down = new Coord(0, -1);
        public static Coord Left = new Coord(-1, 0);
        public static Coord Right = new Coord(1, 0);
    }
}
