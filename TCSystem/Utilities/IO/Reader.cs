using System;
using TC.Core.Utilities.IO.Contracts;

namespace TC.Core.Utilities.IO
{
    public class Reader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
