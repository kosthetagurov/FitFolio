using FitFolio.Data.Models;
using FitFolio.Data.Repositories.Contracts;
using FitFolio.Domain.Contracts;

namespace FitFolio.Domain.Exercises
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task CreateAsync(Exercise exercise)
        {
            await _exerciseRepository.CreateAsync(exercise);            
        }

        public async Task DeleteAsync(Exercise exercise)
        {
            await _exerciseRepository.DeleteAsync(exercise);
        }

        public async Task<IEnumerable<Exercise>> GetAsync(int skip, int take = 20)
        {
            return await _exerciseRepository.GetAsync(skip, take);
        }

        public async Task<Exercise> GetExerciseAsync(Guid id)
        {
            return await _exerciseRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Exercise exercise)
        {
            await _exerciseRepository.UpdateAsync(exercise);
        }
    }
}
