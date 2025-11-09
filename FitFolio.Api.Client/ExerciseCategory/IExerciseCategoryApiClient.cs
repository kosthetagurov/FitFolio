using FitFolio.Api.Client.Models.ExerciseCategory;

namespace FitFolio.Api.Client.ExerciseCategory
{
    /// <summary>
    /// Interface for Exercise Category API client operations.
    /// </summary>
    public interface IExerciseCategoryApiClient
    {
        /// <summary>
        /// Gets an exercise category by ID.
        /// </summary>
        /// <param name="id">The exercise category identifier.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The exercise category.</returns>
        /// <exception cref="ArgumentException">Thrown when id is empty.</exception>
        /// <exception cref="ApiException">Thrown when API request fails.</exception>
        Task<Data.Models.ExerciseCategory> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a list of exercise categories with pagination.
        /// </summary>
        /// <param name="skip">Number of items to skip.</param>
        /// <param name="take">Number of items to take.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>List of exercise categories.</returns>
        /// <exception cref="ApiException">Thrown when API request fails.</exception>
        Task<List<Data.Models.ExerciseCategory>> GetListAsync(
            int skip = 0,
            int take = 20,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new exercise category.
        /// </summary>
        /// <param name="request">The exercise category creation parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The created exercise category.</returns>
        /// <exception cref="ArgumentNullException">Thrown when request is null.</exception>
        /// <exception cref="ApiException">Thrown when API request fails.</exception>
        Task<Data.Models.ExerciseCategory> CreateAsync(
            CreateExerciseCategoryRequestBody request,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing exercise category.
        /// </summary>
        /// <param name="request">The exercise category update parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when request is null.</exception>
        /// <exception cref="ApiException">Thrown when API request fails.</exception>
        Task UpdateAsync(
            UpdateExerciseCategoryRequestBody request,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an exercise category.
        /// </summary>
        /// <param name="id">The exercise category identifier.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="ArgumentException">Thrown when id is empty.</exception>
        /// <exception cref="ApiException">Thrown when API request fails.</exception>
        Task DeleteAsync(
            Guid id,
            CancellationToken cancellationToken = default);
    }
}

