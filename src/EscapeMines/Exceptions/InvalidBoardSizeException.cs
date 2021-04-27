using EscapeMines.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Exceptions
{
    public class InvalidBoardSizeException : Exception
    {
        public Coord Coord { get; set; }
        public InvalidBoardSizeException(Coord coord) : base($"Invalid board size {coord}")
        {
            Coord = coord;
        }
    }
}
