using GameFactory.Api.Models;

namespace GameFactory.Api.Services
{
    public interface IGameService
    {
        Task<ICollection<Game>> GetGames();
    }
}
