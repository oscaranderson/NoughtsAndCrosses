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

        public ActionResult GameTest()
        {
            var gameViewModel = new GameTestViewModel();
            gameViewModel.Name = "Oscar";
            gameViewModel.Age = 15;

            gameViewModel.GameBoard = new GameBoard();

            return View(gameViewModel);
        }
    }
}