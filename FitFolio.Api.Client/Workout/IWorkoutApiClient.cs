using FitFolio.Api.Client.Models.Workout;

namespace FitFolio.Api.Client.Workout
{
    /// <summary>
    /// Interface for Workout API client operations.
    /// </summary>
    public interface IWorkoutApiClient
    {
        /// <summary>
        /// Starts a new workout session.
        /// </summary>
        /// <param name="request">The workout start request parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The created workout.</returns>
        /// <exception cref="ArgumentNullException">Thrown when request is null.</exception>
        /// <exception cref="ApiException">Thrown when API request fails.</exception>
        Task<Data.Models.Workout> StartAsync(
            WorkoutStartRequestBody request, 
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Stops an active workout session.
        /// </summary>
        /// <param name="workoutId">The workout identifier.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="ArgumentException">Thrown when workoutId is empty.</exception>
        /// <exception cref="ApiException">Thrown when API request fails.</exception>
        Task StopAsync(
            Guid workoutId, 
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a detail (exercise) to a workout.
        /// </summary>
        /// <param name="request">The workout detail parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when request is null.</exception>
        /// <exception cref="ApiException">Thrown when API request fails.</exception>
        Task AddDetailAsync(
            AddWorkoutDetailRequestBody request, 
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the comment for a workout.
        /// </summary>
        /// <param name="request">The comment update parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when request is null.</exception>
        /// <exception cref="ApiException">Thrown when API request fails.</exception>
        Task UpdateCommentAsync(
            UpdateCommentRequestBody request, 
            CancellationToken cancellationToken = default);
    }
}

