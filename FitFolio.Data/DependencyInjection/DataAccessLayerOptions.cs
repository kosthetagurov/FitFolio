using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFolio.Data.DependencyInjection
{
    public class DataAccessLayerOptions
    {
        public string ConnectionString { get; private set; }

        public DataAccessLayerOptions(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
