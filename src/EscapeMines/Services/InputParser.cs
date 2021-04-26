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
                throw new InvalidInputStringException($"Board size variable count {boardSize.Length}. Expected 2");
            }
            result.BoardSize = new Coord(int.Parse(boardSize[0]), int.Parse(boardSize[1]));

            var mines = lines[1].Split(' ');
            var minesList = new List<Coord>();
            foreach(var mine in mines)
            {
                var mineCoords = mine.Split(',');
                if(mineCoords.Length != 2)
                {
                    throw new InvalidInputStringException($"Mine variable count {boardSize.Length}. Expected 2");
                }
                minesList.Add(new Coord(int.Parse(mineCoords[0]), int.Parse(mineCoords[1]));
            }

            return input;
        }
    }
}
