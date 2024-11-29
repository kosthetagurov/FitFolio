namespace FitFolio.Data.Repositories
{
    public interface IRepository<T> : IRepository where T : class
    {
        IEnumerable<T> GetAll();
        T Get<TId>(TId id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        T Create(T item);
        void Update(T item);
        void Delete(T item);
    }

    public interface IRepository { }
}
