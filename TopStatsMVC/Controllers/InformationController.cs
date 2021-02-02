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
        public Player Player { get; set; } = new Player();


        [HttpGet]
        public IActionResult Index()
        {
            Player = db.Players.Include(g => g.Games).FirstOrDefault();
            return View(Player);
        }

        [HttpPost]
        public IActionResult Index(string nick)
        {
            Player = db.Players.Include(g => g.Games).FirstOrDefault(p => p.Nickname == nick);
            if (Player == null)
            {
                return NotFound();
            }
            return View(Player);
        }
    }
}
