using FitFolio.Data.Access;
using FitFolio.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FitFolio.Data.Repositories
{
    public class ExerciseCategoryRepository : RepositoryBase<ExerciseCategory>
    {
        public ExerciseCategoryRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public override async Task<ExerciseCategory> CreateAsync(ExerciseCategory item)
        {
            _context.ExerciseCategories.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public override async Task DeleteAsync(ExerciseCategory item)
        {
            _context.ExerciseCategories.Remove(item);
            _context.SaveChanges();
        }

        public override async Task<IEnumerable<ExerciseCategory>> FindAsync(Func<ExerciseCategory, bool> predicate)
        {
            return await Task.FromResult(_context.ExerciseCategories.Where(predicate));
        }

        public override async Task<ExerciseCategory> GetByIdAsync<TId>(TId id)
        {            
            var _id = (Guid)Convert.ChangeType(id, typeof(Guid));
            return await _context.ExerciseCategories.FirstOrDefaultAsync(x => x.Id == _id);
        }

        public override async Task<IEnumerable<ExerciseCategory>> GetAllAsync()
        {
            return await _context.ExerciseCategories.ToListAsync();
        }

        public override async Task UpdateAsync(ExerciseCategory item)
        {
            _context.ExerciseCategories.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
