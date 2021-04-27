using EscapeMines.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Services
{
    public interface IOutput
    {
        void LogSequence(Sequence sequence, Result result, Coord startingPos, Coord endPos);
    }
}
