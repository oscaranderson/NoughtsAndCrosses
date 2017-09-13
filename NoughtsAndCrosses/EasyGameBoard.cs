using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses
{
    public class LoggingGameBoard : IGameBoard
    {
        private IGameBoard _gameBoard;

        public LoggingGameBoard(IGameBoard gameBoard)
        {
            Console.WriteLine("Entry");
            _gameBoard = gameBoard;
            Console.WriteLine("Exit LogginGameBoard");
        }

        public char[,] GetBoard()
        {
            Console.WriteLine("Entry GetBoard");
            return _gameBoard.GetBoard();
            Console.WriteLine("Exit GetBoard");
        }

        public void PrintBoard()
        {
            Console.WriteLine("Entry PrintBoard");
            _gameBoard.PrintBoard();
            Console.WriteLine("Exit PrintBoard");
        }

        public bool SetValue(int i, int j, char value)
        {
            Console.WriteLine("Entry SetValue");
            return _gameBoard.SetValue(i, j, value);
            Console.WriteLine("Exit SetValue");
        }

        public int[] UserInputTile()
        {
            Console.WriteLine("Entry UserInputTile");
            return _gameBoard.UserInputTile();
            Console.WriteLine("Exit UserInputTile");
        }

        public char UserInputValue()
        {
            Console.WriteLine("Entry UserInputValue");
            return _gameBoard.UserInputValue();
            Console.WriteLine("Exit UserInputValue");
        }

        public bool ValidateGame()
        {
            Console.WriteLine("Entry ValidateGame");
            var result = _gameBoard.ValidateGame();
            Console.WriteLine("Exit ValidateGame");

            return result;
        }
    }
}
