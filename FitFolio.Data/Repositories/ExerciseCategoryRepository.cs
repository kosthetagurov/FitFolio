using FitFolio.Data.Access;
using FitFolio.Data.Models;
using FitFolio.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FitFolio.Data.Repositories
{
    public class ExerciseCategoryRepository : RepositoryBase<ExerciseCategory>, IExerciseCategoryRepository
    {
        public ExerciseCategoryRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<ExerciseCategory> CreateAsync(ExerciseCategory item)
        {
            _context.ExerciseCategories.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task DeleteAsync(ExerciseCategory item)
        {
            _context.ExerciseCategories.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExerciseCategory>> FindAsync(Expression<Func<ExerciseCategory, bool>> predicate)
        {
            return await _context.ExerciseCategories.Where(predicate).ToListAsync();
        }

        public async Task<ExerciseCategory> GetByIdAsync<TId>(TId id)
        {            
            var _id = (Guid)Convert.ChangeType(id, typeof(Guid));
            return await _context.ExerciseCategories.FirstOrDefaultAsync(x => x.Id == _id);
        }

        public async Task UpdateAsync(ExerciseCategory item)
        {
            _context.ExerciseCategories.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExerciseCategory>> GetAsync(int skip, int take = 20)
        {
            return await _context.ExerciseCategories.Skip(skip).Take(take).ToListAsync(); 
        }
    }
}
