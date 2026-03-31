using GameFactory.Api.Dto;
using GameFactory.Api.Models;
using GameFactory.Api.Repository;

namespace GameFactory.Api.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task CreateGame(CreateGameDto request)
        {
            var game = new Game
            {
                Title = request.Title,
                GenreId = request.GenreId,
                Price = request.Price,
                ReleaseDate = request.ReleaseDate
            };
            await _gameRepository.CreateAsync(game).ConfigureAwait(false);
        }

        public async Task DeleteGame(int id)
        {
            var game = _gameRepository.GetAsync(x => x.Id == id).Result;
            if (game != null)
            {
               await _gameRepository.RemoveAsync(game);
            }
        }

        public async Task<ICollection<GameDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<GameDto>> GetAllGames()
        {
            var games = await _gameRepository.GetAllAsync().ConfigureAwait(false);

            return games.Select(g => new GameDto
            {
                Id = g.Id,
                Title = g.Title,
                Genre = g.Genre?.Name ?? "Unknown",
                Price = g.Price,
                ReleaseDate = g.ReleaseDate
            }).ToList();
        }

        public async Task UpdateGame(UpdateGameDto request)
        {
            var game = await _gameRepository.GetAsync(x => x.Id == request.IdGame)
                  .ConfigureAwait(false);

            if (game is null) return;

            game.Title = request.Title;
            game.GenreId = request.GenreId;
            game.Price = request.Price;
            game.ReleaseDate = request.ReleaseDate;

            await _gameRepository.Update(game).ConfigureAwait(false);
        }
    }
}
