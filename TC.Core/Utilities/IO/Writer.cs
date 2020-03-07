using System;
using TC.Core.Utilities.IO.Contracts;

namespace TC.Core.Utilities.IO
{
    public class Writer : IWriter
    {
        public void Write(string input) => Console.Write(input);
        public void Write(decimal input) => Console.WriteLine(input);
        public void WriteLine(string input) => Console.WriteLine(input);
        public void WriteLine(decimal input) => Console.WriteLine(input);
        public void WriteLineRedColor(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(input);
            Console.ResetColor();
        }
    }
}
