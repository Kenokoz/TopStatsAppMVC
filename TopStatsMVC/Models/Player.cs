using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TopStatsMVC.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public string Nickname { get; set; }
        public string Team { get; set; }
        public List<Game> Games { get; set; } = new List<Game>();
    }
}
