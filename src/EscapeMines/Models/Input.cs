using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Models
{
    public class Input
    {
        public Coord BoardSize { get; set; }
        public IEnumerable<Coord> Mines { get; set; }
        public Turtle Turtle { get; set; }
        public Coord Exit { get; set; }
        public IEnumerable<Sequence> Sequences { get; set; }
    }
}
