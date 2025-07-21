namespace FitFolio.Data.Repositories
{
    public interface IRepository<T> : IRepository where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync<TId>(TId id);
        Task<IEnumerable<T>> FindAsync(Func<T, Boolean> predicate);
        Task<T> CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
    }

    public interface IRepository { }
}
