using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFolio.Data.Repositories
{
    public class RepositoryFactory
    {
        string _connectionString;
        public RepositoryFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public T CreateRepository<T>() where T : class
        {
            return (T)Activator.CreateInstance(typeof(T), _connectionString);
        }
    }
}
