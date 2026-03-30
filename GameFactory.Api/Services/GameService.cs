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

        public async Task<ICollection<Game>> GetGames()
        {
            var games = await _gameRepository.GetAllAsync().ConfigureAwait(false);
            return games;
        }
    }
}
