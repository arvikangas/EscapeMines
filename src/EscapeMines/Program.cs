using EscapeMines.Services;
using System;
using System.IO;

namespace EscapeMines
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter file location: ");
            var path = Console.ReadLine();

            var s = File.ReadAllText(path);

            IInputParser parser = new InputParser();
            var input = parser.Parse(s);

            ITurtleMoverService mover = new TurtleMoverService();
            var result = mover.Run(input);

            Console.WriteLine($"Result: {result}");
        }
    }
}
