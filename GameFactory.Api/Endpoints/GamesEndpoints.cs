using GameFactory.Api.Dto;

namespace GameFactory.Api.Endpoints;

public static class GamesEndpoints
{
    const string GameByIdEndpoint = "GetGameById";

    private static readonly List<GameDto> games =
    [
        new() { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Genre = "Action-adventure", Price = 59.99M, ReleaseDate = new DateOnly(2017, 3, 3) },
        new() { Id = 2, Title = "Super Mario Odyssey", Genre = "Platform", Price = 49.99M, ReleaseDate = new DateOnly(2017, 10, 27) },
        new() { Id = 3, Title = "Minecraft", Genre = "Sandbox", Price = 26.95M, ReleaseDate = new DateOnly(2011, 11, 18) }
    ];

    public static void MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games");

        // /games
        app.MapGet("/", () => games);

        // /games/1
        app.MapGet("/{id}", (int id) =>
        {
            var game = games.Find(g => g.Id == id);
            return game is not null ? Results.Ok(game) : Results.NotFound();
        }).WithName(GameByIdEndpoint);

        //games
        app.MapPost("/", (CreateGameDto create) =>
        {
            var game = new GameDto
            {
                Id = games.Count + 1,
                Title = create.Title,
                Genre = create.Genre,
                Price = create.Price,
                ReleaseDate = create.ReleaseDate
            };

            games.Add(game);

            return Results.CreatedAtRoute(GameByIdEndpoint, new { id = game.Id }, game);
        });

        // /games/1
        app.MapPut("/{id}", (int id, UpdateGameDto update) =>
        {
            var index = games.FindIndex(g => g.Id == id);

            if (index == -1) return Results.NotFound();

            var game = games[index] with
            {
                Title = update.Title,
                Genre = update.Genre,
                Price = update.Price,
                ReleaseDate = update.ReleaseDate
            };

            games[index] = game;

            return Results.NoContent();
        });

        // /games/1
        app.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(g => g.Id == id);

            return Results.NoContent();
        });
    }
}
