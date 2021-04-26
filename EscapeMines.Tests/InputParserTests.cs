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
        public void Test1()
        {
            var inputString = @"5 4
1,1 1,3 3,3
4 2
0 1 N
R M L M M
R M M M";
            var result = _inputParser.Parse(inputString);

            result.ShouldNotBeNull();

            result.BoardSize.X.ShouldBe(5);
            result.BoardSize.X.ShouldBe(4);

            result.Mines.ShouldContain(new Coord(1, 1));
            result.Mines.ShouldContain(new Coord(1, 3));
            result.Mines.ShouldContain(new Coord(3, 3));

            result.Exit.ShouldBe(new Coord(4, 2));

            result.Turtle.Coord.ShouldBe(new Coord(0, 1));
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

        private readonly IInputParser _inputParser;

        public InputParserTests()
        {
            _inputParser = new InputParser();
        }
    }
}
