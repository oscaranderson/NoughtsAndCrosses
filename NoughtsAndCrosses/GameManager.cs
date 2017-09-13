using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses
{
    public static class GameManager
    {

        public static IGameBoard StartGame(IGameBoard gameBoard)
        {
            gameBoard.PrintBoard();

            //UserMove(board, gameBoard);
            return gameBoard;
        }


        public static void UserMove(IGameBoard thisboard)
        {            
            int[] tileCoords = thisboard.UserInputTile();
            if (tileCoords != null)
            {
                char value = thisboard.UserInputValue();
                thisboard.SetValue(tileCoords[0], tileCoords[1], value);
                thisboard.PrintBoard();
            }
            else
            {
                Console.WriteLine("You cant play there!");
            }

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