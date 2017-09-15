﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoughtsAndCrosses.Web.Models;

namespace NoughtsAndCrosses.Web.Models
{
    public class GameTestViewModel : SubmitTileViewModel
    {
        public IGameBoardWinner GameBoard { get; set; }
        public char CurrentPlayer { get; set; }
        public bool IsFinished { get; set; }
        public string Winner { get; set; }
        public string Info { get; set; }
        public bool IsStarting { get; set; }
    }
}