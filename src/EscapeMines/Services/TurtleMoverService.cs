using EscapeMines.Exceptions;
using EscapeMines.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EscapeMines.Services
{
    public class TurtleMoverService : ITurtleMoverService
    {
        readonly IOutput _output;
        public TurtleMoverService(IOutput output)
        {
            _output = output;
        }

        public Result Run(Input input)
        {
            ValidateInput(input);

            var turtlePosition = input.Turtle.Coord;
            var turtleDirection = input.Turtle.Direction;
            var mines = input.Mines.ToHashSet();

            foreach(var sequence in input.Sequences)
            {
                var sequenceResult = DoSequence(sequence, turtlePosition, turtleDirection, mines, input.BoardSize, input.Exit);

                _output.LogSequence(sequence, sequenceResult.result, turtlePosition, sequenceResult.turtlePosition);

                if(sequenceResult.result != Result.StillInDanger)
                {
                    return sequenceResult.result;
                }

                turtlePosition = sequenceResult.turtlePosition;
                turtleDirection = sequenceResult.turtleDirection;
            }

            return Result.StillInDanger;
        }

        private (Result result, Coord turtlePosition, Direction turtleDirection) DoSequence(
            Sequence sequence, Coord turtlePosition, Direction turtleDirection, HashSet<Coord> mines, Coord boardSize, Coord exit)
        {
            foreach (var move in sequence.Moves)
            {
                switch (move)
                {
                    case Move.Left:
                    case Move.Right:
                        {
                            turtleDirection = TurnTurtle(turtleDirection, move);
                            continue;
                        }
                    case Move.Move:
                        turtlePosition = MoveTurtle(boardSize, turtlePosition, turtleDirection); break;
                }

                if (mines.Contains(turtlePosition))
                {
                    return (Result.MineHit, turtlePosition, turtleDirection);
                }

                if (turtlePosition == exit)
                {
                    return (Result.Success, turtlePosition, turtleDirection);
                }
            }

            return (Result.StillInDanger, turtlePosition, turtleDirection);
        }

        private void ValidateInput(Input input)
        {
            if(input.BoardSize.X <= 0 || input.BoardSize.Y <= 0)
            {
                throw new InvalidBoardSizeException(input.BoardSize);
            }

            if (input.Turtle.Coord.X < 0 || input.Turtle.Coord.Y < 0 || 
                input.Turtle.Coord.X > input.BoardSize.X || input.Turtle.Coord.Y > input.BoardSize.Y)
            {
                throw new ObjectOutOfBoardException("Turtle", input.BoardSize);
            }

            if (input.Exit.X < 0 || input.Exit.Y < 0 ||
                input.Exit.X > input.BoardSize.X || input.Exit.Y > input.BoardSize.Y)
            {
                throw new ObjectOutOfBoardException("Exit", input.BoardSize);
            }

            var outOfBoardMines = input.Mines.Where(x => x.X < 0 || x.Y < 0 || x.X > input.BoardSize.X || x.Y > input.BoardSize.Y);
            if(outOfBoardMines.Any())
            {
                throw new ObjectOutOfBoardException("Mine", outOfBoardMines.First());
            }
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
                case Direction.North: directionCoord = Coord.North; break;
                case Direction.East: directionCoord = Coord.East; break;
                case Direction.South: directionCoord = Coord.South; break;
                case Direction.West: directionCoord = Coord.West; break;
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
