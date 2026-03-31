using GameFactory.Api.Dto;
using GameFactory.Api.Models;

namespace GameFactory.Api.Services
{
    public interface IGameService
    {
        Task<ICollection<GameDto>> GetAllGames();
        Task CreateGame(CreateGameDto request);
        Task DeleteGame(int id);
        Task UpdateGame(UpdateGameDto request);
    }
}
