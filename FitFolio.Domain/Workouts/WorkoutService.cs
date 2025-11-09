using FitFolio.Data.Models;
using FitFolio.Data.Repositories.Contracts;
using FitFolio.Domain.Contracts;

namespace FitFolio.Domain.Workouts
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutDetailRepository _workoutDetailRepository;
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IExerciseRepository _exerciseRepository;

        public WorkoutService(IWorkoutRepository workoutRepository,
            IWorkoutDetailRepository workoutDetailRepository,
            IExerciseRepository exerciseRepository)
        {
            _workoutDetailRepository = workoutDetailRepository;
            _workoutRepository = workoutRepository;
            _exerciseRepository = exerciseRepository;
        }

        public async Task AddDetail(WorkoutDetail workoutDetail)
        {
            var workout = await _workoutRepository.GetByIdAsync(workoutDetail.WorkoutId);
            if (workout == null)
            {
                throw new Exception($"Workout with id = {workoutDetail.WorkoutId} not found");
            }

            var exercise = await _exerciseRepository.GetByIdAsync(workoutDetail.ExerciseId);
            if (exercise == null)
            {
                throw new Exception($"Exercise with id = {workoutDetail.ExerciseId} not found");
            }

            await _workoutDetailRepository.CreateAsync(workoutDetail);
        }

        public async Task<Workout> GetWorkoutAsync(Guid id)
        {
            return await _workoutRepository.GetByIdAsync(id);
        }

        public async Task<Workout> StartAsync(ApplicationUser user, string name = null)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var now = DateTime.UtcNow;

            return await _workoutRepository.CreateAsync(new Workout
            {
                Name = name ?? $"Тренировка {now}",
                StartDate = now,
                UserId = user.Id,
            });
        }

        public async Task StopAsync(Workout workout)
        {
            if (workout == null)
            {
                throw new ArgumentNullException(nameof(workout));
            }

            workout.EndDate = DateTime.UtcNow;

            await _workoutRepository.UpdateAsync(workout);
        }

        public async Task UpdateComment(Workout workout, string comment)
        {
            if (workout == null)
            {
                throw new ArgumentNullException(nameof(workout));
            }

            workout.Notes = comment;

            await _workoutRepository.UpdateAsync(workout);
        }
    }
}
