using System.Linq.Expressions;

namespace GameFactory.Api.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task CreateAsync(T entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();
        Task<T> Update(T obj);
    }
}
