using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoughtsAndCrosses.Web.Models;

namespace NoughtsAndCrosses.Web.Models
{
    public class GameTestViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public IGameBoard GameBoard { get; set; }
    }
}