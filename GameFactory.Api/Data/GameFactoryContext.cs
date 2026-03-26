using GameFactory.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameFactory.Api.Data;

public class GameFactoryContext(DbContextOptions<GameFactoryContext> options)
    : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();
}
