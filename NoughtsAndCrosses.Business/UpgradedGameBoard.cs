using System;
using System.Linq;

namespace NoughtsAndCrosses.Business
{
    public class UpgradedGameBoard : IGameBoardWinner
    {
        public char[] ValidInputs = {'O','X'};

        private char[,] _gameBoard { get; set; }

        public UpgradedGameBoard()
        {
            _gameBoard = new char[3, 3];
        }

        public char[,] GetBoard()
        {
            return _gameBoard;
        }

        public void CreateBoard()
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    _gameBoard[i, j] = 'E';
                }
            }
        }

        public bool SetTileValue(int i, int j, char value)
        {
            bool result = false;
            if (_gameBoard[i,j] == 'E' && i < Math.Sqrt(_gameBoard.Length) && j < Math.Sqrt(_gameBoard.Length) && ValidInputs.Contains(char.ToUpper(value)))
            {
                _gameBoard[i, j] = char.ToUpper(value);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        private int RowValue;

        public char GetWinner()
        {
            char winner;
            if (RowValue == 264)
                winner = 'X';
            else if (RowValue == 237)
                winner = 'O';
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
                    if (_gameBoard[i, j] == 'E')
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
                if (_gameBoard[i, 0] == _gameBoard[i, 1] && _gameBoard[i, 1] == _gameBoard[i, 2] && _gameBoard[i, 0] != 'E')
                {
                    result = true;
                    RowValue = _gameBoard[i, 0] += _gameBoard[i, 1] += _gameBoard[i, 2];
                }
                else
                {
                    if (_gameBoard[0, i] == _gameBoard[1, i] && _gameBoard[1, i] == _gameBoard[2, i] && _gameBoard[0, i] != 'E')
                    {
                        result = true;
                        RowValue = _gameBoard[0, i] += _gameBoard[1, i] += _gameBoard[2, i];
                    }
                }
            }
            if (result != true)
            {
                if (_gameBoard[0, 0] == _gameBoard[1, 1] && _gameBoard[1, 1] == _gameBoard[2, 2] && _gameBoard[1, 1] != 'E')
                {
                    result = true;
                    RowValue = _gameBoard[0, 0] += _gameBoard[1, 1] += _gameBoard[2, 2];
                }
                else
                {
                    if (_gameBoard[0, 2] == _gameBoard[1, 1] && _gameBoard[1, 1] == _gameBoard[2, 0] && _gameBoard[2, 0] != 'E')
                    {
                        result = true;
                        RowValue = _gameBoard[0, 2] += _gameBoard[1, 1] += _gameBoard[2, 0];
                    }                    
                }
            }            
            return result;
        }
    }    
}