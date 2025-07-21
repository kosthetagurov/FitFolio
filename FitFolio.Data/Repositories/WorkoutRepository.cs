using FitFolio.Data.Access;
using FitFolio.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FitFolio.Data.Repositories
{
    public class WorkoutRepository : RepositoryBase<Workout>
    {       
        public WorkoutRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {            
        }

        public override async Task<Workout> CreateAsync(Workout item)
        {
            _context.Workouts.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public override async Task DeleteAsync(Workout item)
        {
            _context.Workouts.Remove(item);
            await _context.SaveChangesAsync();
        }

        public override async Task<IEnumerable<Workout>> FindAsync(Func<Workout, bool> predicate)
        {
            return await Task.FromResult(_context.Workouts.Where(predicate));
        }

        public override async Task<Workout> GetByIdAsync<TId>(TId id)
        {
            var _id = (Guid)Convert.ChangeType(id, typeof(Guid));
            return await _context.Workouts.FirstOrDefaultAsync(x => x.Id == _id);
        }

        public override async Task<IEnumerable<Workout>> GetAllAsync()
        {
            return await _context.Workouts.ToListAsync();
        }

        public override async Task UpdateAsync(Workout item)
        {
            _context.Workouts.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
