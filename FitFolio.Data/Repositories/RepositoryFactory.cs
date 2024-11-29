using FitFolio.Data.Access;

namespace FitFolio.Data.Repositories
{
    public class RepositoryFactory
    {
        ApplicationDbContext _dbContext;

        public RepositoryFactory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T CreateRepository<T>() where T : class
        {
            return (T)Activator.CreateInstance(typeof(T), _dbContext);
        }
    }
}
