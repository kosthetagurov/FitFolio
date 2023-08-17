using FitFolio.Data.Access;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFolio.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : class
    {
        protected ApplicationDbContext _context;

        public RepositoryBase(string connectionString)
        {
            _context = new ApplicationDbContext(connectionString);
        }

        public abstract void Create(T item);

        public abstract void Delete(T item);

        public abstract IEnumerable<T> Find(Func<T, bool> predicate);

        public abstract T Get<TId>(TId id);

        public abstract IEnumerable<T> GetAll();

        public abstract void Update(T item);
    }
}
