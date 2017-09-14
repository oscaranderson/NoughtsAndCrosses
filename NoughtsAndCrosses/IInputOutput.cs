namespace NoughtsAndCrosses
{
    public interface IInputOutput
    {
        void Print(string text, bool printAsLine = false);
        string Read();
    }
}