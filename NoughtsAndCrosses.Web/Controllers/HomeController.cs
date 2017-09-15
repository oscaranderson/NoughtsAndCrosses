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
                gameViewModel.GameBoard = new UpgradedGameBoard();
                gameViewModel.GameBoard.CreateBoard();
                gameViewModel.IsStarting = true;
                gameViewModel.CurrentPlayer = 'X';
                SetBoardFromSession(gameViewModel);
            }
            gameViewModel.IsStarting = false;
            return gameViewModel;
        }

        private void SetBoardFromSession(GameTestViewModel gameTestViewModel)
        {
                Session[GameSessionKey] = gameTestViewModel;
        }        

        [HttpPost]
        public ActionResult GameTest(SubmitTileViewModel submitTileViewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("GameTest");

            var gameViewModel = GetBoardFromSession();
            if (!gameViewModel.IsFinished)
            {
                if (!gameViewModel.GameBoard.SetTileValue(submitTileViewModel.X, submitTileViewModel.Y, gameViewModel.CurrentPlayer))
                {
                    gameViewModel.Info = "Invalid Move! Please Try again";
                }
                else
                {
                    if (gameViewModel.CurrentPlayer == 'O')
                    {
                        gameViewModel.CurrentPlayer = 'X';
                    }
                    else
                    {
                        gameViewModel.CurrentPlayer = 'O';
                    }
                }
            }            

            if (gameViewModel.GameBoard.IsDraw())
            {
                gameViewModel.IsFinished = true;
                gameViewModel.Winner = "Its A Draw!";
            }

            if (gameViewModel.GameBoard.ValidateGame())
            {
                gameViewModel.IsFinished = true;
                var winner = gameViewModel.GameBoard.GetWinner();
                switch (winner)
                {
                    case 'X':
                        gameViewModel.Winner = "Crosses Wins!";
                        break;
                    case 'O':
                        gameViewModel.Winner = "Noughts Wins!";
                        break;                    
                }                
            }

            if (submitTileViewModel.NewGame == true)
            {
                gameViewModel = null;
                SetBoardFromSession(gameViewModel);
            }

            return RedirectToAction("GameTest");
        }

    }
}