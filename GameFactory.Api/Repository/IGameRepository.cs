using GameFactory.Api.Dto;
using GameFactory.Api.Models;
using System.Linq.Expressions;

namespace GameFactory.Api.Repository
{
    public interface IGameRepository : IGenericRepository<Game>
    {
        Task<ICollection<Game>> GetAllAsync();
    }
}
