using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Exceptions
{
    public class InvalidInputStringException : Exception
    {
        public InvalidInputStringException(string message): base(message) { }
    }
}
