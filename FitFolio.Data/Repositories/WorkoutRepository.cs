using FitFolio.Data.Access;
using FitFolio.Data.Models;
using FitFolio.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FitFolio.Data.Repositories
{
    public class WorkoutRepository : RepositoryBase<Workout>, IWorkoutRepository
    {       
        public WorkoutRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {            
        }

        public async Task<Workout> CreateAsync(Workout item)
        {
            _context.Workouts.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task DeleteAsync(Workout item)
        {
            _context.Workouts.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Workout>> FindAsync(Expression<Func<Workout, bool>> predicate)
        {
            return await _context.Workouts.Where(predicate).ToListAsync();
        }

        public async Task<Workout> GetByIdAsync<TId>(TId id)
        {
            var _id = (Guid)Convert.ChangeType(id, typeof(Guid));
            return await _context.Workouts.FirstOrDefaultAsync(x => x.Id == _id);
        }

        public async Task UpdateAsync(Workout item)
        {
            _context.Workouts.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Workout>> GetAsync(int skip, int take = 20)
        {
            return await _context.Workouts.Skip(skip).Take(take).ToListAsync();
        }
    }
}
