using System;

namespace NoughtsAndCrosses
{
    public class ConsolePrinter : IInputOutput
    {
        public void Print(string text, bool printAsLine = false)
        {
            if (!printAsLine)
                Console.Write(text);
            else
                Console.WriteLine(text);
        }
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}