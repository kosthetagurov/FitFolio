using FitFolio.Data.Models;
using FitFolio.Data.Repositories.Contracts;
using FitFolio.Domain.Contracts;

namespace FitFolio.Domain.ExerciseCategories
{
    internal class ExerciseCategoryService : IExerciseCategoryService
    {
        private readonly IExerciseCategoryRepository _exerciseRepository;

        public ExerciseCategoryService(IExerciseCategoryRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task CreateAsync(ExerciseCategory exerciseCategory)
        {
            await _exerciseRepository.CreateAsync(exerciseCategory);
        }

        public async Task DeleteAsync(ExerciseCategory exerciseCategory)
        {
            await _exerciseRepository.DeleteAsync(exerciseCategory);
        }

        public async Task<IEnumerable<ExerciseCategory>> GetAsync(int skip, int take = 20)
        {
            return await _exerciseRepository.GetAsync(skip, take);
        }

        public async Task<ExerciseCategory> GetExerciseAsync(Guid id)
        {
            return await _exerciseRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(ExerciseCategory exerciseCategory)
        {
            await _exerciseRepository.UpdateAsync(exerciseCategory);
        }
    }
}
