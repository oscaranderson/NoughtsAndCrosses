using System;
using System.Linq;

namespace NoughtsAndCrosses
{
    class UpgradedGameBoard : IGameBoardWinning
    {
        private IGameBoard _gameBoard;

        User userx = new User('X', false);
        User usero = new User('O', true);

        private IInputOutput _printer;

        public UpgradedGameBoard(IGameBoard gameBoard, IInputOutput printer)
        {            
            _gameBoard = gameBoard;
            _printer = printer;
        }
        
        public void PlayerStarts(char player)
        {
            if (player == 'X')
            {
                userx.IsMyGo = true;
                usero.IsMyGo = false;
                
            }
            else if (player == '0')
            {
                userx.IsMyGo = false;
                usero.IsMyGo = true;
            }
        }

        public char[,] GetBoard()
        {
            return _gameBoard.GetBoard();
        }

        public void PrintBoard()
        {
            _gameBoard.PrintBoard();
        }

        public bool SetValue(int i, int j, char value)
        {
            return _gameBoard.SetValue(i, j, value);
        }

        public int[] UserInputTile()
        {
            string TestCoordsString;
            char TestCoordX;
            char TestCoordY;
            char WhichGo;
            try
            {                
                if (!userx.IsMyGo == true)
                {
                    WhichGo = 'O';
                }
                else
                {
                    WhichGo = 'X';
                }
                _printer.Print($"\n{WhichGo}'s turn, Enter coordinates of tile\n\n>>> ");
                TestCoordsString = _printer.Read();
                TestCoordX = TestCoordsString.First();
                TestCoordY = TestCoordsString.Last();
                
                Convert.ChangeType(Convert.ChangeType(TestCoordX, typeof(string)), typeof(int));
                Convert.ChangeType(Convert.ChangeType(TestCoordY, typeof(string)), typeof(int));

                int[] TestCoords = { (int)Convert.ChangeType(Convert.ChangeType(TestCoordX, typeof(string)), typeof(int)), (int)Convert.ChangeType(Convert.ChangeType(TestCoordY, typeof(string)), typeof(int)) };
            }

            catch
            {
                return null;
            }
            int[] TileCoords = { (int)Convert.ChangeType(Convert.ChangeType(TestCoordX, typeof(string)), typeof(int)), (int)Convert.ChangeType(Convert.ChangeType(TestCoordY, typeof(string)), typeof(int)) };

            if (TileCoords[0] < Math.Sqrt(GetBoard().Length) && TileCoords[1] < Math.Sqrt(GetBoard().Length))
            {
                if (GetBoard()[TileCoords[0], TileCoords[1]] == 'E')
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
            char value;
            if (userx.IsMyGo == true)
            {
                value = 'X';
            }
            else
            {
                value = 'O';
            }
            usero.NextGo();
            userx.NextGo();
            return value;
        }

        private int RowValue;

        public char GetWinner()
        {
            char winner;
            if (RowValue == 264)
                winner = 'x';
            else if (RowValue == 237)
                winner = 'o';
            else
                winner = 'E';
            return winner;
            
        }
        
        public bool IsDraw()
        {
            int EmptyCount = 0;
            bool draw = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (GetBoard()[i, j] == 'E')
                    {
                        EmptyCount += 1;
                    }
                }

            }
            if (EmptyCount == 0)
            {
                draw = true;
            }
            return draw;
        }

        public bool ValidateGame()
        {
            bool result = false;

            for (int i = 0; i < 3; i++)
            {
                if (GetBoard()[i, 0] == GetBoard()[i, 1] && GetBoard()[i, 1] == GetBoard()[i, 2] && GetBoard()[i, 0] != 'E')
                {
                    result = true;
                    RowValue = GetBoard()[i, 0] += GetBoard()[i, 1] += GetBoard()[i, 2];
                }
                else
                {
                    if (GetBoard()[0, i] == GetBoard()[1, i] && GetBoard()[1, i] == GetBoard()[2, i] && GetBoard()[0, i] != 'E')
                    {
                        result = true;
                        RowValue = GetBoard()[0, i] += GetBoard()[1, i] += GetBoard()[2, i];
                    }
                }
            }
            if (result != true)
            {
                if (GetBoard()[0, 0] == GetBoard()[1, 1] && GetBoard()[1, 1] == GetBoard()[2, 2] && GetBoard()[1, 1] != 'E')
                {
                    result = true;
                    RowValue = GetBoard()[0, 0] += GetBoard()[1, 1] += GetBoard()[2, 2];
                }
                else
                {
                    if (GetBoard()[0, 2] == GetBoard()[1, 1] && GetBoard()[1, 1] == GetBoard()[2, 0] && GetBoard()[2, 0] != 'E')
                    {
                        result = true;
                        RowValue = GetBoard()[0, 2] += GetBoard()[1, 1] += GetBoard()[2, 0];
                    }                    
                }
            }            
            return result;
        }

        public void CreateBoard()
        {
            _gameBoard.CreateBoard();
        }
    }    
}