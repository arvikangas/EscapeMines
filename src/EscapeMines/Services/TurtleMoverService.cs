using EscapeMines.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EscapeMines.Services
{
    public class TurtleMoverService : ITurtleMoverService
    {
        public Result Run(Input input)
        {
            var turtle = new Turtle() { Coord = new Coord(input.Turtle.Coord.X, input.Turtle.Coord.Y), Direction = input.Turtle.Direction };
            var mines = input.Mines.ToHashSet();

            foreach (var move in input.Moves)
            {
                switch (move)
                {
                    case Move.Left:
                    case Move.Right:
                        turtle.Direction = TurnTurtle(turtle.Direction, move); break;
                    case Move.Move:
                        turtle.Coord = MoveTurtle(input.BoardSize, turtle.Coord, turtle.Direction); break;
                }

                if(mines.Contains(turtle.Coord))
                {
                    return Result.MineHit;
                }

                if(turtle.Coord.X == input.Exit.X && turtle.Coord.Y == input.Exit.Y)
                {
                    return Result.Success;
                }
            }

            return Result.StillInDanger;
        }

        private Direction TurnTurtle(Direction direction, Move move)
        {
            switch (direction)
            {
                case Direction.North: return (move == Move.Left ? Direction.West : Direction.East);
                case Direction.East: return (move == Move.Left ? Direction.North : Direction.South);
                case Direction.South: return (move == Move.Left ? Direction.East : Direction.West);
                case Direction.West: return (move == Move.Left ? Direction.South : Direction.North);
                default: throw new InvalidOperationException();
            }
        }

        private Coord MoveTurtle(Coord board, Coord from, Direction direction)
        {
            Coord directionCoord;
            switch (direction)
            {
                case Direction.North: directionCoord = Coord.Up; break;
                case Direction.East: directionCoord = Coord.Right; break;
                case Direction.South: directionCoord = Coord.Down; break;
                case Direction.West: directionCoord = Coord.Left; break;
                default: throw new InvalidOperationException();
            }

            var newCoord = from + directionCoord;
            if (newCoord.X < 0 || newCoord.Y < 0 || newCoord.X > board.X || newCoord.Y > board.Y)
            {
                return from;
            }

            return newCoord;
        }
    }
}
