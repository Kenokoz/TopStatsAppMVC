using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TopStatsMVC.Models;

namespace TopStatsMVC.Controllers
{
    public class PlayersController : Controller
    {
        private readonly PlayersContext db;

        public PlayersController(PlayersContext db)
        {
            this.db = db;
        }

        public IEnumerable<Player> Players { get; set; }

        public IActionResult Index(string nick)
        {
            if (nick == null)
            {
                Players = new List<Player>();
                Players = db.Players.ToList();
                return View(Players);
            }
            else
            {
                var player = db.Players.Include(g => g.Games).Where(p => p.Nickname == nick).Single();
                return View("../Information/Index", player);
            }
            
        }
    }
}
