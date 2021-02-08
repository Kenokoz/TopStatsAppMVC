using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TopStatsMVC.Models;

namespace TopStatsMVC.Controllers
{
    public class GetStatsController : Controller
    {
        private readonly PlayersContext db;

        public GetStatsController(PlayersContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Player Player { get; set; }

        [HttpGet]
        public IActionResult Index()
        {
            LoadData();
            return View();
        }

        [HttpPost]
        public IActionResult Index(string nick)
        {
            Player = db.Players.Include(g => g.Games).FirstOrDefault(p => p.Nickname.ToLower() == nick.ToLower());
            if (Player != null)
            {
                return RedirectToAction("Stats", "Information", new { nick });
            }
            else
            {
                Player = new Player { Id = -1 };
                return View(Player);
            }
        }

        private void LoadData()
        {
            if (db.Players.Count() == 0)
            {
                string file = System.IO.File.ReadAllText("playersData.json");
                var players = JsonSerializer.Deserialize<List<Player>>(file);
                db.AddRange(players);
                db.SaveChanges();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
