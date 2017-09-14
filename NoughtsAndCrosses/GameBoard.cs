using System;
using System.Linq;

namespace NoughtsAndCrosses
{
    public class GameBoard : IGameBoard
    {
        private IInputOutput _printer;

        public GameBoard(IInputOutput printer)
        {
            _printer = printer;
        }

        public int[] UserInputTile()
        {
            _printer.Print("\nInput X coordinate of tile\n\n>>> ");
            int tileX = Int32.Parse(_printer.Read());

            _printer.Print("Input Y coordinate of tile\n\n>>> ");
            int tileY = Int32.Parse(_printer.Read());
            
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
            _printer.Print("What do you want to change the selected tile to\n\n>>> ");
            char value = _printer.Read().Single();
            return value;
        }

        private char[,] board = new char[3,3];

        public GameBoard()
        {
            CreateBoard();
        }

        public void CreateBoard()
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    SetValue(i, j, 'E');
                }
            }       
        }

        public bool SetValue(int i, int j, char value)
        {
            bool result = false;

            var validValues = new char[] { 'x', 'o', 'e'};
            if (!validValues.Contains(Char.ToLower(value)))
            {
                _printer.Print("Invalid Character", true);
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
                _printer.Print("[");

                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 'E')
                    {
                        _printer.Print(" ,");
                    }
                    else
                    {
                        _printer.Print($"{board[i, j]},");
                    }
                }
                _printer.Print("]", true);
            }
        }

        public bool ValidateGame()
        {            
            bool result = false;

            for (int i = 0; i < 3; i++)
            {
                
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != 'E')
                {
                    result = true;
                }
                else
                {
                    if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != 'E')
                    {
                        result = true;
                    }
                }
            }
            if (result != true)
            {
                if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[2, 2] != 'E')
                {
                    result = true;
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

