using EscapeMines.Exceptions;
using EscapeMines.Models;
using EscapeMines.Services;
using NSubstitute;
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
                BoardSize = new Coord(4, 5),
                Mines = new List<Coord> { new Coord(1, 1), new Coord(1, 3), new Coord(3, 3) },
                Exit = new Coord(2, 4),
                Turtle = new Turtle { Coord = new Coord(1, 0), Direction = Direction.North },
                Sequences = new List<Sequence> { new Sequence { Moves = new List<Move> { Move.Move, Move.Right, Move.Move, Move.Right, Move.Move } } }
            };
            var result = _service.Run(input);
            result.ShouldBe(Result.MineHit);
        }

        [Fact]
        public void service_should_return_correct_data_fixture2()
        {
            var input = new Input
            {
                BoardSize = new Coord(4, 5),
                Mines = new List<Coord> { new Coord(1, 1), new Coord(1, 3), new Coord(3, 3) },
                Exit = new Coord(2, 4),
                Turtle = new Turtle { Coord = new Coord(1, 0), Direction = Direction.North },
                Sequences = new List<Sequence>
                {
                    new Sequence
                    {
                        Moves = new List<Move> { Move.Move, Move.Right, Move.Move, Move.Move }
                    },
                    new Sequence
                    {
                        Moves = new List<Move> { Move.Move, Move.Move, Move.Right, Move.Move, Move.Move }
                    }
                }
            };
            var result = _service.Run(input);
            result.ShouldBe(Result.Success);
        }

        [Fact]
        public void service_should_return_correct_data_fixture3()
        {
            var input = new Input
            {
                BoardSize = new Coord(4, 5),
                Mines = new List<Coord> { new Coord(1, 1), new Coord(1, 3), new Coord(3, 3) },
                Exit = new Coord(4, 2),
                Turtle = new Turtle { Coord = new Coord(1, 0), Direction = Direction.North },
                Sequences = new List<Sequence>
                {
                    new Sequence
                    {
                        Moves = new List<Move> { Move.Move, Move.Right, Move.Move, Move.Move }
                    },
                    new Sequence
                    {
                        Moves = new List<Move> { Move.Move, Move.Move, Move.Right, Move.Move }
                    }
                }
            };
            var result = _service.Run(input);
            result.ShouldBe(Result.StillInDanger);
        }

        [Fact]
        public void service_should_throw_exception_with_invalid_turtle_position()
        {
            var input = new Input
            {
                BoardSize = new Coord(4, 5),
                Mines = new List<Coord> { new Coord(1, 1), new Coord(1, 3), new Coord(3, 3) },
                Exit = new Coord(4, 2),
                Turtle = new Turtle { Coord = new Coord(5, 6), Direction = Direction.North },
                Sequences = new List<Sequence>()
            };
            Should.Throw<ObjectOutOfBoardException>(() => _service.Run(input));
        }

        [Fact]
        public void service_should_throw_exception_with_invalid_exit_position()
        {
            var input = new Input
            {
                BoardSize = new Coord(4, 5),
                Mines = new List<Coord> { new Coord(1, 1), new Coord(1, 3), new Coord(3, 3) },
                Exit = new Coord(-1, 2),
                Turtle = new Turtle { Coord = new Coord(1, 1), Direction = Direction.North },
                Sequences = new List<Sequence>()
            };
            Should.Throw<ObjectOutOfBoardException>(() => _service.Run(input));
        }

        [Fact]
        public void service_should_throw_exception_with_invalid_mine_position()
        {
            var input = new Input
            {
                BoardSize = new Coord(4, 5),
                Mines = new List<Coord> { new Coord(1, 1), new Coord(1, 44), new Coord(3, 55) },
                Exit = new Coord(-1, 2),
                Turtle = new Turtle { Coord = new Coord(1, 1), Direction = Direction.North },
                Sequences = new List<Sequence>()
            };
            Should.Throw<ObjectOutOfBoardException>(() => _service.Run(input));
        }

        private readonly IOutput _output;
        private readonly ITurtleMoverService _service;

        public TurtleMoverServiceTests()
        {
            _output = Substitute.For<IOutput>();
            _service = new TurtleMoverService(_output);
        }
    }
}
