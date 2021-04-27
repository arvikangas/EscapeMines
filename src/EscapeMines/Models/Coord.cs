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
        public static bool operator == (Coord c1, Coord c2) => c1.X == c2.X && c1.Y == c2.Y;
        public static bool operator !=(Coord c1, Coord c2) => c1.X != c2.X || c1.Y != c2.Y;

        public static Coord North = new Coord(-1, 0);
        public static Coord South = new Coord(1, 0);
        public static Coord East = new Coord(0, 1);
        public static Coord West = new Coord(0, -1);

        public override string ToString() => $"X:{X} Y:{Y}";
    }
}
