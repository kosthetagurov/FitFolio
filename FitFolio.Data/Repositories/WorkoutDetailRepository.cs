using FitFolio.Data.Access;
using FitFolio.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FitFolio.Data.Repositories
{
    public class WorkoutDetailRepository : RepositoryBase<WorkoutDetail>
    {       
        public WorkoutDetailRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {            
        }

        public override async Task<WorkoutDetail> CreateAsync(WorkoutDetail item)
        {
            _context.WorkoutDetails.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public override async Task DeleteAsync(WorkoutDetail item)
        {
            _context.WorkoutDetails.Remove(item);
            await _context.SaveChangesAsync();
        }

        public override async Task<IEnumerable<WorkoutDetail>> FindAsync(Func<WorkoutDetail, bool> predicate)
        {
            return await Task.FromResult(_context.WorkoutDetails.Where(predicate));
        }

        public override async Task<WorkoutDetail> GetByIdAsync<TId>(TId id)
        {
            var _id = (Guid)Convert.ChangeType(id, typeof(Guid));
            return await _context.WorkoutDetails.FirstOrDefaultAsync(x => x.Id == _id);
        }

        public override async Task<IEnumerable<WorkoutDetail>> GetAllAsync()
        {
            return await _context.WorkoutDetails.ToListAsync();
        }

        public override async Task UpdateAsync(WorkoutDetail item)
        {
            _context.WorkoutDetails.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
