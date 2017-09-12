using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses
{
    public class GameBoard
    {
        private char[,] board = new char[3,3];

        public GameBoard()
        {
            CreateBoard();
        }

        private void CreateBoard()
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    SetValue(i, j, 'e');
                }
            }       
        }

        public bool SetValue(int i, int j, char value)
        {
            bool result = false;

            var validValues = new char[] { 'x', 'o', 'e', 'X', 'O', 'E' };
            if (!validValues.Contains(value))
            {
                Console.WriteLine("Invalid Character");
                //result = false;
            }
            else
            {
                board[i, j] = value;
                result = true;
            }

            return result;
        }

        public int GetLegnth()
        {
            return board.Length;
        }

        public void PrintBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write("[");

                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{board[i, j]}," );
                }

                Console.WriteLine("]");
            }
        }

        [Obsolete("Please use the new method instead")]
        public char[,] GetBoard()
        {
            return board;
        }
    }
}

