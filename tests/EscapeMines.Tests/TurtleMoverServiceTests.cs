using EscapeMines.Exceptions;
using EscapeMines.Models;
using EscapeMines.Services;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EscapeMines.Tests
{
    public class TurtleMoverServiceTests
    {
        [Fact]
        public void service_should_return_correct_data_fixture1()
        {
            var input = new Input
            {
                BoardSize = new Coord(5, 4),
                Mines = new List<Coord> { new Coord(1, 1), new Coord(1, 3), new Coord(3, 3) },
                Exit = new Coord(4, 2),
                Turtle = new Turtle { Coord = new Coord(0, 1), Direction = Direction.North },
                Moves = new List<Move> { Move.Move, Move.Right, Move.Move, Move.Right, Move.Move }
            };
            var result = _service.Run(input);
            result.ShouldBe(Result.MineHit);
        }

        [Fact]
        public void service_should_return_correct_data_fixture2()
        {
            var input = new Input
            {
                BoardSize = new Coord(5, 4),
                Mines = new List<Coord> { new Coord(1, 1), new Coord(1, 3), new Coord(3, 3) },
                Exit = new Coord(4, 2),
                Turtle = new Turtle { Coord = new Coord(0, 1), Direction = Direction.North },
                Moves = new List<Move> { Move.Move, Move.Right, Move.Move, Move.Move, Move.Move, Move.Move, Move.Right, Move.Move, Move.Move }
            };
            var result = _service.Run(input);
            result.ShouldBe(Result.Success);
        }

        [Fact]
        public void service_should_return_correct_data_fixture3()
        {
            var input = new Input
            {
                BoardSize = new Coord(5, 4),
                Mines = new List<Coord> { new Coord(1, 1), new Coord(1, 3), new Coord(3, 3) },
                Exit = new Coord(4, 2),
                Turtle = new Turtle { Coord = new Coord(0, 1), Direction = Direction.North },
                Moves = new List<Move> { Move.Move, Move.Right, Move.Move, Move.Move, Move.Move, Move.Move, Move.Right, Move.Move }
            };
            var result = _service.Run(input);
            result.ShouldBe(Result.StillInDanger);
        }

        private readonly ITurtleMoverService _service;

        public TurtleMoverServiceTests()
        {
            _service = new TurtleMoverService();
        }
    }
}
