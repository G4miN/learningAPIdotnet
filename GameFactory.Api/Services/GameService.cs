using GameFactory.Api.Dto;
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

        public Task CreateGame(CreateGameDto request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGame()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<GameDto>> GetAllGames()
        {
            var games = await _gameRepository.GetAllAsync().ConfigureAwait(false);
            return (ICollection<GameDto>)games;
        }

        public Task UpdateGame(UpdateGameDto request)
        {
            throw new NotImplementedException();
        }
    }
}
