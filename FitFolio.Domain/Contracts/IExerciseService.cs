using FitFolio.Data.Models;

namespace FitFolio.Domain.Contracts
{
    public interface IExerciseService : IDomainService
    {
        Task CreateAsync(Exercise exercise);
        Task GetAsync(int skip, int take = 20);
        Task UpdateAsync(Exercise exercise);
        Task DeleteAsync(Exercise exercise);
    }
}
