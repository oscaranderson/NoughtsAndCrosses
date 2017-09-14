using System;

namespace NoughtsAndCrosses
{
    public static class GameManager
    {
        public static IGameBoard StartGame(IGameBoard gameBoard)
        {
            gameBoard.CreateBoard();
            gameBoard.PrintBoard();

            return gameBoard;
        }

        public static bool ChooseStartingPlayer(IGameBoard gameBoard, IInputOutput printer)
        {
            printer.Print("\nWhich player starts first O or X\n\n>>> ");
            var choice = 'E';
            bool completed;
            try
            {
                choice = (char)Convert.ChangeType(printer.Read(), typeof(char));
                if (char.ToUpper(choice) == 'O' || char.ToUpper(choice) == 'X')
                {
                    completed = true;
                    ((IGameBoardWinning)gameBoard).PlayerStarts(char.ToUpper(choice));
                }
                else
                {
                    gameBoard.PrintBoard();
                    printer.Print("\nPlease choose either O or X", true);
                    completed = false;
                }
            }
            catch
            {
                gameBoard.PrintBoard();
                printer.Print("\nPlease choose either O or X", true);
                completed = false;
            }
            return completed;
        }

        public static void UserMove(IGameBoard thisboard, IInputOutput printer)
        {   
            int[] tileCoords = thisboard.UserInputTile();
            if(tileCoords == null)
                printer.Print("\nInvalid input!", true);

            if (tileCoords[0] == 10)
            {
                thisboard.PrintBoard();
                printer.Print("\nYou must enter 2 numbers!", true);
            }
            else if (tileCoords[0] == 20)
            {
                thisboard.PrintBoard();
                printer.Print("\nYou can't play there!", true);
            }
            else if (tileCoords[0] == 30)
            {
                thisboard.PrintBoard();
                printer.Print("\nYou can't play there!", true);
            }
            else
            {
                char value = thisboard.UserInputValue();
                thisboard.SetValue(tileCoords[0], tileCoords[1], value);
                thisboard.PrintBoard();
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