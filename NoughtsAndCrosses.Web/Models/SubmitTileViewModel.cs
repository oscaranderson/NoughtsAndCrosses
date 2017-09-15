using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoughtsAndCrosses.Web.Models
{
    public class SubmitTileViewModel
    {
        [Required]
        [Range(0,2, ErrorMessage ="Invalid cell number")]
        public int X { get; set; }

        [Required]
        [Range(0, 2, ErrorMessage = "Invalid cell number")]
        public int Y { get; set; }

        public string Symbol{ get; set; }

        public bool NewGame { get; set; }
    }

}