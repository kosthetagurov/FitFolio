using FitFolio.Data.Access;
using FitFolio.Data.Models;

namespace FitFolio.Data.Repositories
{
    public class WorkoutDetailRepository : RepositoryBase<WorkoutDetail>
    {       
        public WorkoutDetailRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {            
        }

        public override WorkoutDetail Create(WorkoutDetail item)
        {
            _context.WorkoutDetails.Add(item);
            _context.SaveChanges();

            return item;
        }

        public override void Delete(WorkoutDetail item)
        {
            _context.WorkoutDetails.Remove(item);
            _context.SaveChanges();
        }

        public override IEnumerable<WorkoutDetail> Find(Func<WorkoutDetail, bool> predicate)
        {
            return _context.WorkoutDetails.Where(predicate);
        }

        public override WorkoutDetail Get<TId>(TId id)
        {
            var _id = (Guid)Convert.ChangeType(id, typeof(Guid));
            return _context.WorkoutDetails.FirstOrDefault(x => x.Id == _id);
        }

        public override IEnumerable<WorkoutDetail> GetAll()
        {
            return _context.WorkoutDetails.ToList();
        }

        public override void Update(WorkoutDetail item)
        {
            _context.WorkoutDetails.Update(item);
            _context.SaveChanges();
        }
    }
}
