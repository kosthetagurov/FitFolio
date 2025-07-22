using FitFolio.Data.Models;

namespace FitFolio.Domain.Contracts
{
    public interface IWorkoutService : IDomainService
    {
        Task StartAsync(ApplicationUser user, string name = null);
        Task StopAsync(Workout workout);
        Task AddDetail(WorkoutDetail workoutDetail);
        Task UpdateComment(Workout workout, string comment); 
    }
}
