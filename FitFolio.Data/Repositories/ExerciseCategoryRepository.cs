using FitFolio.Data.Access;
using FitFolio.Data.Models;

namespace FitFolio.Data.Repositories
{
    public class ExerciseCategoryRepository : RepositoryBase<ExerciseCategory>
    {
        public ExerciseCategoryRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public override ExerciseCategory Create(ExerciseCategory item)
        {
            _context.ExerciseCategories.Add(item);
            _context.SaveChanges();

            return item;
        }

        public override void Delete(ExerciseCategory item)
        {
            _context.ExerciseCategories.Remove(item);
            _context.SaveChanges();
        }

        public override IEnumerable<ExerciseCategory> Find(Func<ExerciseCategory, bool> predicate)
        {
            return _context.ExerciseCategories.Where(predicate);
        }

        public override ExerciseCategory Get<TId>(TId id)
        {            
            var _id = (Guid)Convert.ChangeType(id, typeof(Guid));
            return _context.ExerciseCategories.FirstOrDefault(x => x.Id == _id);
        }

        public override IEnumerable<ExerciseCategory> GetAll()
        {
            return _context.ExerciseCategories.ToList();
        }

        public override void Update(ExerciseCategory item)
        {
            _context.ExerciseCategories.Update(item);
            _context.SaveChanges();
        }
    }
}
