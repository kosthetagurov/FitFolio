using FitFolio.Data.Access;
using FitFolio.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FitFolio.Data.Repositories
{
    public class ExerciseRepository : RepositoryBase<Exercise>
    {
        public ExerciseRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public override async Task<Exercise> CreateAsync(Exercise item)
        {
            _context.Exercises.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public override async Task DeleteAsync(Exercise item)
        {
            _context.Exercises.Remove(item);
            await _context.SaveChangesAsync();
        }

        public override async Task<IEnumerable<Exercise>> FindAsync(Func<Exercise, bool> predicate)
        {
            return await Task.FromResult(_context.Exercises.Where(predicate));
        }

        public override async Task<Exercise> GetByIdAsync<TId>(TId id)
        {
            var _id = (Guid)Convert.ChangeType(id, typeof(Guid));
            return await _context.Exercises.FirstOrDefaultAsync(x => x.Id == _id);
        }

        public override async Task<IEnumerable<Exercise>> GetAllAsync()
        {
            return await _context.Exercises.ToListAsync();
        }

        public override async Task UpdateAsync(Exercise item)
        {
            _context.Exercises.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
