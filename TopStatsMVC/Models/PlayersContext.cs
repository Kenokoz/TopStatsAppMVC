using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TopStatsMVC.Models
{
    public class PlayersContext : DbContext
    {
        public PlayersContext(DbContextOptions options) :  base(options) {}
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
