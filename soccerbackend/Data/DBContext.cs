namespace soccerbackend.Data
{
    using Microsoft.EntityFrameworkCore;
    using soccerbackend.Models;

    public class SoccerDbContext : DbContext
    {
        
        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }

        public SoccerDbContext(DbContextOptions<SoccerDbContext> options) : base(options) { }
    }
}
