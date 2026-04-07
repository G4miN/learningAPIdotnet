using GameFactory.Api.Data;
using GameFactory.Api.Models;

namespace GameFactory.Api.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly GameFactoryContext _DbContext;

        public GenreRepository(GameFactoryContext context) : base(context)
        {
            _DbContext = context;
        }
    }
}
