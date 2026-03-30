using GameFactory.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameFactory.Api.Data;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(GameFactoryContext context)
    {
        await context.Database.MigrateAsync();

        if (!await context.Genres.AnyAsync())
        {
            var genres = new List<Genre>
            {
                new() { Name = "Action" },
                new() { Name = "RPG" },
                new() { Name = "Sports" }
            };

            await context.Genres.AddRangeAsync(genres);
            await context.SaveChangesAsync();
        }

        if (!await context.Games.AnyAsync())
        {
            var actionGenreId = await context.Genres
                .Where(g => g.Name == "Action")
                .Select(g => g.Id)
                .FirstAsync();

            var rpgGenreId = await context.Genres
                .Where(g => g.Name == "RPG")
                .Select(g => g.Id)
                .FirstAsync();

            var sportsGenreId = await context.Genres
                .Where(g => g.Name == "Sports")
                .Select(g => g.Id)
                .FirstAsync();

            var games = new List<Game>
            {
                new()
                {
                    Title = "Doom Eternal",
                    GenreId = actionGenreId,
                    Price = 39.99m,
                    ReleaseDate = new DateOnly(2020, 3, 20)
                },
                new()
                {
                    Title = "Elden Ring",
                    GenreId = rpgGenreId,
                    Price = 59.99m,
                    ReleaseDate = new DateOnly(2022, 2, 25)
                },
                new()
                {
                    Title = "FIFA 24",
                    GenreId = sportsGenreId,
                    Price = 49.99m,
                    ReleaseDate = new DateOnly(2023, 9, 29)
                }
            };

            await context.Games.AddRangeAsync(games);
            await context.SaveChangesAsync();
        }
    }
}
