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

        public abstract T Create(T item);

        public abstract void Delete(T item);

        public abstract IEnumerable<T> Find(Func<T, bool> predicate);

        public abstract T Get<TId>(TId id);

        public abstract IEnumerable<T> GetAll();

        public abstract void Update(T item);
    }
}
