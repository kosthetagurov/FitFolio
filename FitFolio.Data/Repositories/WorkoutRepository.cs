using FitFolio.Data.Access;
using FitFolio.Data.Models;

namespace FitFolio.Data.Repositories
{
    public class WorkoutRepository : RepositoryBase<Workout>
    {       
        public WorkoutRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {            
        }

        public override Workout Create(Workout item)
        {
            _context.Workouts.Add(item);
            _context.SaveChanges();

            return item;
        }

        public override void Delete(Workout item)
        {
            _context.Workouts.Remove(item);
            _context.SaveChanges();
        }

        public override IEnumerable<Workout> Find(Func<Workout, bool> predicate)
        {
            return _context.Workouts.Where(predicate);
        }

        public override Workout Get<TId>(TId id)
        {
            var _id = (Guid)Convert.ChangeType(id, typeof(Guid));
            return _context.Workouts.FirstOrDefault(x => x.Id == _id);
        }

        public override IEnumerable<Workout> GetAll()
        {
            return _context.Workouts.ToList();
        }

        public override void Update(Workout item)
        {
            _context.Workouts.Update(item);
            _context.SaveChanges();
        }
    }
}
