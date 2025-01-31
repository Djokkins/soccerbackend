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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team1)
                .WithMany()
                .HasForeignKey(m => m.Team1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team2)
                .WithMany()
                .HasForeignKey(m => m.Team2Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.WinnerTeam)
                .WithMany()
                .HasForeignKey(m => m.WinnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.LoserTeam)
                .WithMany()
                .HasForeignKey(m => m.LoserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
