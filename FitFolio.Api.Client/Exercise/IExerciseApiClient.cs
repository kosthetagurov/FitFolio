using FitFolio.Api.Client.Models.Exercise;

namespace FitFolio.Api.Client.Exercise
{
    /// <summary>
    /// Interface for Exercise API client operations.
    /// </summary>
    public interface IExerciseApiClient
    {
        /// <summary>
        /// Gets an exercise by ID.
        /// </summary>
        /// <param name="id">The exercise identifier.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The exercise.</returns>
        /// <exception cref="ArgumentException">Thrown when id is empty.</exception>
        /// <exception cref="ApiException">Thrown when API request fails.</exception>
        Task<Data.Models.Exercise> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a list of exercises with pagination.
        /// </summary>
        /// <param name="skip">Number of items to skip.</param>
        /// <param name="take">Number of items to take.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>List of exercises.</returns>
        /// <exception cref="ApiException">Thrown when API request fails.</exception>
        Task<List<Data.Models.Exercise>> GetListAsync(
            int skip = 0,
            int take = 20,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new exercise.
        /// </summary>
        /// <param name="request">The exercise creation parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The created exercise.</returns>
        /// <exception cref="ArgumentNullException">Thrown when request is null.</exception>
        /// <exception cref="ApiException">Thrown when API request fails.</exception>
        Task<Data.Models.Exercise> CreateAsync(
            CreateExerciseRequestBody request,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing exercise.
        /// </summary>
        /// <param name="request">The exercise update parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when request is null.</exception>
        /// <exception cref="ApiException">Thrown when API request fails.</exception>
        Task UpdateAsync(
            UpdateExerciseRequestBody request,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an exercise.
        /// </summary>
        /// <param name="id">The exercise identifier.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="ArgumentException">Thrown when id is empty.</exception>
        /// <exception cref="ApiException">Thrown when API request fails.</exception>
        Task DeleteAsync(
            Guid id,
            CancellationToken cancellationToken = default);
    }
}

