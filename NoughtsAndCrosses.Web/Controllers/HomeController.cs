using NoughtsAndCrosses.Business;
using NoughtsAndCrosses.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoughtsAndCrosses.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string GameSessionKey = "user-board";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult GameTest()
        {
            var gameViewModel = GetBoardFromSession();

            return View(gameViewModel);
        }

        private GameTestViewModel GetBoardFromSession()
        {
            var gameViewModel = Session[GameSessionKey] as GameTestViewModel;
            if (gameViewModel == null)
            {
                gameViewModel = new GameTestViewModel();
                gameViewModel.Name = "Oscar";
                gameViewModel.Age = 15;
                gameViewModel.GameBoard = new UpgradedGameBoard();
                gameViewModel.GameBoard.CreateBoard();
                SetBoardFromSession(gameViewModel);
            }

            return gameViewModel;
        }

        private void SetBoardFromSession(GameTestViewModel gameTestViewModel)
        {
                Session[GameSessionKey] = gameTestViewModel;
        }

        [HttpPost]
        public ActionResult GameTest(int x, int y, char c)
        {
            var gameViewModel = GetBoardFromSession();
            gameViewModel.GameBoard.SetValue(x,y,c);

            if (gameViewModel.GameBoard.ValidateGame())
            {
                gameViewModel.IsFinished = true;
                //if (gameViewModel.GameBoard.GetWinner() == 'x')
                //{
                //    gameViewModel.Winner = "Crosses Wins!";
                //}
                //else if (gameViewModel.GameBoard.GetWinner() == 'o')
                //{
                //    gameViewModel.Winner = "Noughts Wins!";
                //}
                //else
                //{
                //    gameViewModel.Winner = "Draw!";
                //}

                var winner = gameViewModel.GameBoard.GetWinner();
                switch (winner)
                {
                    case 'x':
                        gameViewModel.Winner = "Crosses Wins!";
                        break;
                    case 'o':
                        gameViewModel.Winner = "Noughts Wins!";
                        break;

                    default:
                    gameViewModel.Winner = "Draw!";
                        break;
                }
            }

            return RedirectToAction("GameTest");
        }

        public string PrintText;

    }
}