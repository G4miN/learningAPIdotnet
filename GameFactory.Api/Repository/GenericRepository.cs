using GameFactory.Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GameFactory.Api.Repository
{
    public class GenericRepository<T> where T : class
    {
        private readonly GameFactoryContext _DbContext;
        internal DbSet<T> _dbSet;

        public GenericRepository(GameFactoryContext context)
        {
            _DbContext = context;
            _dbSet = _DbContext.Set<T>();
        }


        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = _dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = _dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();

        }

        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _DbContext.SaveChangesAsync();
        }

        public async Task<T> Update(T obj)
        {
            _dbSet.Attach(obj);
            _dbSet.Entry(obj).State = EntityState.Modified;

            await SaveAsync().ConfigureAwait(false);
            return obj;
        }
    }
}
