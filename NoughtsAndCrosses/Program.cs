using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameBoard = GameManager.StartGame(new GameBoard());

            bool IsFinished = false;
            while (!IsFinished)
            {
                GameManager.UserMove(gameBoard);
                IsFinished = gameBoard.ValidateGame();
            }
            //if (gameBoard.)
            Console.WriteLine("\nYou Won!");

            Console.ReadKey();

            //4. print board
            //4.1 if winner print message

            //end
        }
    }
}
