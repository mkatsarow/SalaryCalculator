namespace TC.Core.Utilities.IO.Contracts
{
    public interface IWriter
    {
        void Write(string input);
        void Write(decimal input);
        void WriteLine(string input);
        void WriteLine(decimal input);
        void WriteLineRedColor(string input);
    }
}
