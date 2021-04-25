using EscapeMines.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Services
{
    public interface IInputParser
    {
        public Input Parse(string input);
    }
}
