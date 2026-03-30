using GameFactory.Api.Data;
using GameFactory.Api.Models;

namespace GameFactory.Api.Repository
{
    public class GameRespository : GenericRepository<Game>, IGameRepository
    {
        public GameRespository(GameFactoryContext context) : base(context)
        {
        }
    }
}
