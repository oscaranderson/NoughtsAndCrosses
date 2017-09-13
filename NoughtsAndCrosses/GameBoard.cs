using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses
{
    public class GameBoard : IGameBoard
    {
        public int[] UserInputTile()
        {
            Console.Write("\nInput X coordinate of tile\n\n>>> ");
            int tileX = Int32.Parse(Console.ReadLine());

            Console.Write("Input Y coordinate of tile\n\n>>> ");
            int tileY = Int32.Parse(Console.ReadLine());
            
            int[] TileCoords = new int[] { tileX, tileY };

            if (tileX < Math.Sqrt(board.Length) && tileY < Math.Sqrt(board.Length))
            {
                if (board[tileX, tileY] == 'E')
                {
                    return TileCoords;
                }

                else
                {                    
                    return null;
                }
            }
            else
            {                
                return null;
            }
            
        }

        public char UserInputValue()
        {
            Console.Write("What do you want to change the selected tile to\n\n>>> ");
            char value = Console.ReadLine().Single();
            return value;
        }

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

            var validValues = new char[] { 'x', 'o', 'e'};
            if (!validValues.Contains(Char.ToLower(value)))
            {
                Console.WriteLine("Invalid Character");
                //result = false;
            }
            else
            {
                board[i, j] = Char.ToUpper(value);
                result = true;
            }
            return result;
        }

        public void PrintBoard()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.Write("[");

                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 'E')
                    {
                        Console.Write(" ,");
                    }
                    else
                    {
                        Console.Write($"{board[i, j]},");
                    }
                }
                Console.WriteLine("]");
            }
        }

        public char Winner = 'E';

        public int RowValue;

        //public char GetWinner()
        //{
        //    int winner;
        //    if (RowValue == 360)
        //    {
                
        //    }            
        //}

        public bool ValidateGame()
        {            
            bool result = false;

            for (int i = 0; i < 3; i++)
            {
                
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != 'E')
                {
                    result = true;
                    RowValue = board[i, 0] += board[i, 1] += board[i, 2];
                }
                else
                {
                    if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != 'E')
                    {
                        result = true;
                        RowValue = board[0, i] += board[1, i] += board[2, i];
                    }
                }
            }
            if (result != true)
            {
                if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[2, 2] != 'E')
                {
                    result = true;
                    RowValue = board[0, 0] += board[1, 1] += board[2, 2];
                }
                else
                {
                    result = false;
                }
            }
            
            return result;
        }        

        [Obsolete("Please use the new method instead")]
        public char[,] GetBoard()
        {
            return board;
        }
    }

}

