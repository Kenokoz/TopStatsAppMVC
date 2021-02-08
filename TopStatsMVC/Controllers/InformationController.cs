using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopStatsMVC.Models;

namespace TopStatsMVC.Controllers
{
    public class InformationController : Controller
    {
        private readonly PlayersContext db;

        public InformationController(PlayersContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Player Player { get; set; }

        public IActionResult Stats(string nick)
        {
            Player = db.Players.Include(g => g.Games).FirstOrDefault(p => p.Nickname.ToLower() == nick.ToLower());
            return View("Index", Player);
        }

        [HttpGet]
        public IActionResult Index()
        {
            Player = db.Players.Include(g => g.Games).FirstOrDefault();
            return View(Player);
        }

        [HttpPost]
        public IActionResult Index(string nick)
        {   
            Player = db.Players.Include(g => g.Games).FirstOrDefault(p => p.Nickname.ToLower() == nick.ToLower());
            if (Player == null)
            {
                Player = new Player { Id = -1 };
                return PartialView("_ErrorFind");
            }
            return PartialView("_StatsItems", Player);
        }

        [HttpPost]
        public IActionResult OnSelectItem(string nick, string map, string result, string kda)
        {
            List<Game> games = db.Players.Include(g => g.Games).FirstOrDefault(p => p.Nickname == nick).Games;
            List<Game> rows = new List<Game>();

            if (map != null)
            {
                rows.AddRange(games.Where(g => g.MapName == map).ToList());
            }
            else if (result != null)
            {
                if (result == "Won")
                {
                    rows.AddRange(games.Where(g => g.WonRounds > g.LostRounds).ToList());
                }
                else
                {
                    rows.AddRange(games.Where(g => g.WonRounds < g.LostRounds).ToList());
                }
                
            }
            else if (kda != null)
            {
                if (kda == "Positive")
                {
                    rows.AddRange(games.Where(g => g.Kills > g.Deaths).ToList());
                }
                else
                {
                    rows.AddRange(games.Where(g => g.Kills < g.Deaths).ToList());
                }
            }
            else
            {
                return PartialView("_Table", games);
            }

            return PartialView("_Table", rows);
        }
    }
}
