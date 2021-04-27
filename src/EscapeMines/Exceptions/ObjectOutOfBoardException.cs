using EscapeMines.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Exceptions
{
    public class ObjectOutOfBoardException : Exception
    {
        public string ObjectType { get; set; }
        public Coord Coord { get; set; }
        public ObjectOutOfBoardException(string objectType, Coord coord) : base($"Object {objectType} coord {coord} out of board") 
        {
            ObjectType = objectType;
            Coord = coord;
        }
    }
}
