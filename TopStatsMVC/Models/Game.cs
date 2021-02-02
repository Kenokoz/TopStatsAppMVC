using System;
using System.Collections.Generic;
using System.Text;

namespace TopStatsMVC.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string MapName { get; set; }
        public string Date { get; set; }
        public int WonRounds { get; set; }
        public int LostRounds { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
    }
}
