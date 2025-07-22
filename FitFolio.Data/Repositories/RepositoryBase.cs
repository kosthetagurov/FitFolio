using FitFolio.Data.Access;

namespace FitFolio.Data.Repositories
{
    public abstract class RepositoryBase<T>
        where T : class
    {
        protected ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }        
    }
}
