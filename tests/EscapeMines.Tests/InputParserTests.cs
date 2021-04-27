using EscapeMines.Exceptions;
using EscapeMines.Models;
using EscapeMines.Services;
using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace EscapeMines.Tests
{
    public class InputParserTests
    {
        [Fact]
        public void parser_should_return_correct_data_fixture1()
        {
            var inputString = @"5 4
1,1 1,3 3,3
4 2
0 1 N
R M L M M
R M M M";
            var result = _inputParser.Parse(inputString);

            result.ShouldNotBeNull();

            result.BoardSize.X.ShouldBe(4);
            result.BoardSize.Y.ShouldBe(5);

            result.Mines.ShouldContain(new Coord(1, 1));
            result.Mines.ShouldContain(new Coord(1, 3));
            result.Mines.ShouldContain(new Coord(3, 3));

            result.Exit.ShouldBe(new Coord(2, 4));

            result.Turtle.Coord.ShouldBe(new Coord(1, 0));
            result.Turtle.Direction.ShouldBe(Direction.North);

            var movesList = result.Moves.ToList();
            movesList.Count.ShouldBe(9);
            movesList[0].ShouldBe(Move.Right);
            movesList[1].ShouldBe(Move.Move);
            movesList[2].ShouldBe(Move.Left);
            movesList[3].ShouldBe(Move.Move);
            movesList[4].ShouldBe(Move.Move);
            movesList[5].ShouldBe(Move.Right);
            movesList[6].ShouldBe(Move.Move);
            movesList[7].ShouldBe(Move.Move);
            movesList[8].ShouldBe(Move.Move);
        }

        [Fact]
        public void parser_should_return_correct_data_fixture2()
        {
            var inputString = @"100 23456
1,1 1,3 3,3 6,6 7,7 8,8 9,9 10,10
98 78
0 1 S
R M L M M M M M M M M M M M";
            var result = _inputParser.Parse(inputString);

            result.ShouldNotBeNull();

            result.BoardSize.Y.ShouldBe(100);
            result.BoardSize.X.ShouldBe(23456);

            result.Mines.ShouldContain(new Coord(1, 1));
            result.Mines.ShouldContain(new Coord(1, 3));
            result.Mines.ShouldContain(new Coord(3, 3));
            result.Mines.ShouldContain(new Coord(6, 6));
            result.Mines.ShouldContain(new Coord(7, 7));
            result.Mines.ShouldContain(new Coord(8, 8));
            result.Mines.ShouldContain(new Coord(9, 9));
            result.Mines.ShouldContain(new Coord(10, 10));

            result.Exit.ShouldBe(new Coord(78, 98));

            result.Turtle.Coord.ShouldBe(new Coord(1, 0));
            result.Turtle.Direction.ShouldBe(Direction.South);

            var movesList = result.Moves.ToList();
            movesList.Count.ShouldBe(14);
            movesList[0].ShouldBe(Move.Right);
            movesList[1].ShouldBe(Move.Move);
            movesList[2].ShouldBe(Move.Left);
            movesList[3].ShouldBe(Move.Move);
            movesList[4].ShouldBe(Move.Move);
            movesList[5].ShouldBe(Move.Move);
            movesList[6].ShouldBe(Move.Move);
            movesList[7].ShouldBe(Move.Move);
            movesList[9].ShouldBe(Move.Move);
            movesList[10].ShouldBe(Move.Move);
            movesList[11].ShouldBe(Move.Move);
            movesList[12].ShouldBe(Move.Move);
            movesList[13].ShouldBe(Move.Move);
        }

        [Fact]
        public void parser_should_throw_exception_with_invalid_line_count()
        {
            var inputString = @"100 23456
1,1 1,3 3,3 6,6 7,7 8,8 9,9 10,10
98 78";
            Should.Throw<InvalidInputStringException>(() => _inputParser.Parse(inputString));
        }

        [Fact]
        public void parser_should_throw_exception_with_direction_symbol()
        {
            var inputString = @"5 4
1,1 1,3 3,3
4 2
0 1 N
R M L X M
R M M M";
            Should.Throw<InvalidInputStringException>(() => _inputParser.Parse(inputString));
        }


        private readonly IInputParser _inputParser;

        public InputParserTests()
        {
            _inputParser = new InputParser();
        }
    }
}
