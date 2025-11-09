using FitFolio.Data.Access;
using FitFolio.Data.Models;
using FitFolio.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FitFolio.Data.Repositories
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<Exercise> CreateAsync(Exercise item)
        {
            _context.Exercises.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task DeleteAsync(Exercise item)
        {
            _context.Exercises.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Exercise>> FindAsync(Expression<Func<Exercise, bool>> predicate)
        {
            return await _context.Exercises.Where(predicate).ToListAsync();
        }

        public async Task<Exercise> GetByIdAsync<TId>(TId id)
        {
            var _id = (Guid)Convert.ChangeType(id, typeof(Guid));
            return await _context.Exercises.FirstOrDefaultAsync(x => x.Id == _id);
        }

        public async Task UpdateAsync(Exercise item)
        {
            _context.Exercises.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Exercise>> GetAsync(int skip, int take = 20)
        {
            return await _context.Exercises.Skip(skip).Take(take).ToListAsync();
        }
    }
}
