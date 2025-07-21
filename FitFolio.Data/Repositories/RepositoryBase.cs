using FitFolio.Data.Access;

namespace FitFolio.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : class
    {
        protected ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public abstract Task<T> CreateAsync(T item);

        public abstract Task DeleteAsync(T item);

        public abstract Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate);

        public abstract Task<T> GetByIdAsync<TId>(TId id);

        public abstract Task<IEnumerable<T>> GetAllAsync();

        public abstract Task UpdateAsync(T item);
    }
}
