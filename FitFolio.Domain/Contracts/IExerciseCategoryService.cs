using FitFolio.Data.Models;

namespace FitFolio.Domain.Contracts
{
    public interface IExerciseCategoryService : IDomainService
    {
        Task<ExerciseCategory> GetExerciseAsync(Guid id);
        Task CreateAsync(ExerciseCategory exercise);
        Task<IEnumerable<ExerciseCategory>> GetAsync(int skip, int take = 20);
        Task UpdateAsync(ExerciseCategory exercise);
        Task DeleteAsync(ExerciseCategory exercise);
    }
}
