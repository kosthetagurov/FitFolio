using FitFolio.Data.Access;
using FitFolio.Data.Models;

namespace FitFolio.Data.Repositories
{
    public class ExerciseRepository : RepositoryBase<Exercise>
    {
        public ExerciseRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public override Exercise Create(Exercise item)
        {
            _context.Exercises.Add(item);
            _context.SaveChanges();

            return item;
        }

        public override void Delete(Exercise item)
        {
            _context.Exercises.Remove(item);
            _context.SaveChanges();
        }

        public override IEnumerable<Exercise> Find(Func<Exercise, bool> predicate)
        {
            return _context.Exercises.Where(predicate);
        }

        public override Exercise Get<TId>(TId id)
        {
            var _id = (Guid)Convert.ChangeType(id, typeof(Guid));
            return _context.Exercises.FirstOrDefault(x => x.Id == _id);
        }

        public override IEnumerable<Exercise> GetAll()
        {
            return _context.Exercises.ToList();
        }

        public override void Update(Exercise item)
        {
            _context.Exercises.Update(item);
            _context.SaveChanges();
        }
    }
}
