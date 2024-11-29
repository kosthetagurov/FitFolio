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
