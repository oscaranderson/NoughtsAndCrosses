using Autofac;
using System;

namespace NoughtsAndCrosses
{
    class Program
    {
        private static IContainer _container;

        static void Main(string[] args)
        {
            StartIoC();            

            IGameBoard gameBoard = _container.Resolve<IGameBoard>();
            IInputOutput printer = _container.Resolve<IInputOutput>();

            gameBoard = GameManager.StartGame(gameBoard);
            while (true)
            {
                if (GameManager.ChooseStartingPlayer(gameBoard, printer))
                {
                    break;
                }
            }

            bool IsFinished = false;
            while (IsFinished == false)
            {
                GameManager.UserMove(gameBoard, printer);
                IsFinished = gameBoard.ValidateGame();
                if (((IGameBoardWinning)gameBoard).IsDraw())
                {
                    break;
                }
            }

            if (((IGameBoardWinning)gameBoard).GetWinner() == 'x')
                printer.Print("\nCrosses Wins!", true);
            else if (((IGameBoardWinning)gameBoard).GetWinner() == 'o')
                printer.Print("\nNoughts Wins!", true);
            else
                printer.Print("\nDraw!", true);

            Console.ReadKey();

            //4. print board
            //4.1 if winner print message

            //end
        }

        private static void StartIoC()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ConsolePrinter>().As<IInputOutput>();

            builder.RegisterType<GameBoard>().Named<IGameBoard>(typeof(GameBoard).Name);
            builder.RegisterDecorator<IGameBoard>((c, inner) => new UpgradedGameBoard(inner, c.Resolve<IInputOutput>()), typeof(GameBoard).Name);
            _container = builder.Build();
        }
    }
}
