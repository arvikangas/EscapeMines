using EscapeMines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscapeMines.Services
{
    public class ConsoleOutput : IOutput
    {
        public void LogSequence(Sequence sequence, Result result, Coord startingPos, Coord endPos)
        {
            var moves = sequence.Moves.Select(x => GetMove(x));
            var joinedMoves = string.Join(' ', moves);
            Console.WriteLine($"Sequence {joinedMoves}. Result {result}. From position {startingPos} to position {endPos}");
        }

        private string GetMove(Move move)
        {
            switch (move)
            {
                case Move.Right: return "R";
                case Move.Left: return "L";
                case Move.Move: return "M";
                default: throw new InvalidOperationException();
            }
        }
    }
}
