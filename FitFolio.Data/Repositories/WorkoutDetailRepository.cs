using FitFolio.Data.Access;
using FitFolio.Data.Models;
using FitFolio.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FitFolio.Data.Repositories
{
    public class WorkoutDetailRepository : RepositoryBase<WorkoutDetail>, IWorkoutDetailRepository
    {       
        public WorkoutDetailRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {            
        }

        public async Task<WorkoutDetail> CreateAsync(WorkoutDetail item)
        {
            _context.WorkoutDetails.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task DeleteAsync(WorkoutDetail item)
        {
            _context.WorkoutDetails.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WorkoutDetail>> FindAsync(Expression<Func<WorkoutDetail, bool>> predicate)
        {
            return await _context.WorkoutDetails.Where(predicate).ToListAsync();
        }

        public async Task<WorkoutDetail> GetByIdAsync<TId>(TId id)
        {
            var _id = (Guid)Convert.ChangeType(id, typeof(Guid));
            return await _context.WorkoutDetails.FirstOrDefaultAsync(x => x.Id == _id);
        }

        public async Task UpdateAsync(WorkoutDetail item)
        {
            _context.WorkoutDetails.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WorkoutDetail>> GetAsync(int skip, int take = 20)
        {
            return await _context.WorkoutDetails.Skip(skip).Take(take).ToListAsync();
        }
    }
}
