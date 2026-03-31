using GameFactory.Api.Data;
using GameFactory.Api.Dto;
using GameFactory.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameFactory.Api.Repository
{
    public class GameRespository : GenericRepository<Game>, IGameRepository
    {
        private readonly GameFactoryContext _DbContext;

        public GameRespository(GameFactoryContext context) : base(context)
        {
            _DbContext = context;
        }

        public async Task<ICollection<Game>> GetAllAsync()
        {
            return await _DbContext.Games.Include(g => g.Genre).ToListAsync();
        }
    }
}
