using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses
{
    public static class GameManager
    {

        public static GameBoard StartGame()
        {
            var gameBoard = new GameBoard();
            gameBoard.PrintBoard();

            //UserMove(board, gameBoard);
            return gameBoard;
        }


        public static void UserMove(GameBoard thisboard)
        {
            User user = new User();
            int tile = Int32.Parse(user.UserInputTile());
            char value = user.UserInputValue();

            
            /// Implement in version 2.0
            //for (int i = 0; i < Math.Sqrt(board.Length); i++)
            //{
            //    for (int j = 0; j < Math.Sqrt(board.Length); j++)
            //    {
            //        if (j == 0)
            //        {
            //            thisboard.SetValue(board, tile, j, value);
            //        }
            //        else if (j == 1)
            //        {
            //            thisboard.SetValue(board, tile - j * int(Math.Sqrt(board.Length)), j, value);
            //        }
            //        else
            //        {
            //            thisboard.SetValue(board, tile)   
            //        }
            //    }
            //}
            
            
        }
    }
}