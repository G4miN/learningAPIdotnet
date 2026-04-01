using GameFactory.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameFactory.Api.Data
{
    public class GameFactoryContext : DbContext
    {
        public GameFactoryContext(DbContextOptions<GameFactoryContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
               .Property(g => g.Price)
               .HasColumnType("decimal(18,2)");
        }

        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
    }
}