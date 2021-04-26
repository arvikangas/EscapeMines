using EscapeMines.Exceptions;
using EscapeMines.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Services
{
    public class InputParser : IInputParser
    {
        public Input Parse(string input)
        {
            var lines = input.Split(Environment.NewLine);
            if(lines.Length < 4)
            {
                throw new InvalidInputStringException($"Line count {lines.Length}. Expected 4 or greater");
            }

            var result = new Input();
            var boardSize = lines[0].Split(' ');
            if(boardSize.Length != 2)
            {
                throw new InvalidInputStringException($"Board size data count {boardSize.Length}. Expected 2");
            }
            result.BoardSize = new Coord(int.Parse(boardSize[0]), int.Parse(boardSize[1]));

            var mines = lines[1].Split(' ');
            var minesList = new List<Coord>();
            foreach(var mine in mines)
            {
                var mineCoords = mine.Split(',');
                if(mineCoords.Length != 2)
                {
                    throw new InvalidInputStringException($"Mine data count {boardSize.Length}. Expected 2");
                }
                minesList.Add(new Coord(int.Parse(mineCoords[0]), int.Parse(mineCoords[1])));
            }
            result.Mines = minesList;

            var exit = lines[2].Split(' ');
            if (boardSize.Length != 2)
            {
                throw new InvalidInputStringException($"Exit data count {boardSize.Length}. Expected 2");
            }
            result.Exit = new Coord(int.Parse(exit[0]), int.Parse(exit[1]));

            result.Turtle = new Turtle();
            var turle = lines[3].Split(' ');
            if (turle.Length != 3)
            {
                throw new InvalidInputStringException($"Exit variable count {boardSize.Length}. Expected 3");
            }
            result.Turtle.Coord = new Coord(int.Parse(turle[0]), int.Parse(turle[1]));
            result.Turtle.Direction = GetDirection(turle[2]);

            var moves = new List<Move>();
            for (int i = 4; i < lines.Length; i++)
            {
                var line = lines[i].Split(" ");
                foreach (var item in line)
                {
                    moves.Add(GetMove(item));
                }
            }
            result.Moves = moves;

            return result;
        }

        private Direction GetDirection(string s)
        {
            switch(s)
            {
                case "N": return Direction.North; 
                case "S": return Direction.South;
                case "E": return Direction.East; 
                case "W": return Direction.West;
                default: throw new InvalidInputStringException($"Cannot parse string {s} to Direction");
            }
        }

        private Move GetMove(string s)
        {
            switch (s)
            {
                case "R": return Move.Right;
                case "L": return Move.Left;
                case "M": return Move.Move;
                default: throw new InvalidInputStringException($"Cannot parse string {s} to Move");
            }
        }
    }
}
