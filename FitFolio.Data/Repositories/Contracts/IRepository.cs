using System.Linq.Expressions;

namespace FitFolio.Data.Repositories.Contracts
{
    public interface IRepository<T> : IRepository where T : class
    {
        Task<IEnumerable<T>> GetAsync(int skip, int take = 20);
        Task<T> GetByIdAsync<TId>(TId id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
    }

    public interface IRepository { }
}
