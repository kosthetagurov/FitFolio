using FitFolio.Api.Client.Models.Exercise;
using Microsoft.Extensions.Logging;

namespace FitFolio.Api.Client.Exercise
{
    /// <summary>
    /// API client for exercise-related operations.
    /// </summary>
    public class ExerciseApiClient : ApiClientBase, IExerciseApiClient
    {
        private readonly ILogger<ExerciseApiClient> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseApiClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client instance (configured via IHttpClientFactory).</param>
        /// <param name="logger">The logger instance.</param>
        public ExerciseApiClient(
            HttpClient httpClient,
            ILogger<ExerciseApiClient> logger)
            : base(httpClient, logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc />
        public async Task<Data.Models.Exercise> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Exercise ID cannot be empty.", nameof(id));
            }

            _logger.LogInformation("Getting exercise {ExerciseId}", id);

            try
            {
                var exercise = await GetAsync<Data.Models.Exercise>(
                    $"api/exercise/{id}",
                    cancellationToken);

                _logger.LogInformation("Exercise {ExerciseId} retrieved successfully", id);
                return exercise;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get exercise {ExerciseId}", id);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<List<Data.Models.Exercise>> GetListAsync(
            int skip = 0,
            int take = 20,
            CancellationToken cancellationToken = default)
        {
            if (skip < 0)
            {
                throw new ArgumentException("Skip parameter must be non-negative.", nameof(skip));
            }

            if (take <= 0 || take > 100)
            {
                throw new ArgumentException("Take parameter must be between 1 and 100.", nameof(take));
            }

            _logger.LogInformation("Getting exercise list with skip={Skip}, take={Take}", skip, take);

            try
            {
                var exercises = await GetAsync<List<Data.Models.Exercise>>(
                    $"api/exercise?skip={skip}&take={take}",
                    cancellationToken);

                _logger.LogInformation("Retrieved {Count} exercises", exercises.Count);
                return exercises;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get exercise list");
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<Data.Models.Exercise> CreateAsync(
            CreateExerciseRequestBody request,
            CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentException("Exercise name is required.", nameof(request));
            }

            if (request.CategoryId == Guid.Empty)
            {
                throw new ArgumentException("Category ID is required.", nameof(request));
            }

            _logger.LogInformation("Creating exercise '{ExerciseName}'", request.Name);

            try
            {
                var exercise = await PostAsync<Data.Models.Exercise>(
                    "api/exercise",
                    request,
                    cancellationToken);

                _logger.LogInformation("Exercise created successfully with ID {ExerciseId}", exercise.Id);
                return exercise;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create exercise '{ExerciseName}'", request.Name);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task UpdateAsync(
            UpdateExerciseRequestBody request,
            CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Id == Guid.Empty)
            {
                throw new ArgumentException("Exercise ID is required.", nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentException("Exercise name is required.", nameof(request));
            }

            if (request.CategoryId == Guid.Empty)
            {
                throw new ArgumentException("Category ID is required.", nameof(request));
            }

            _logger.LogInformation("Updating exercise {ExerciseId}", request.Id);

            try
            {
                await PutAsync(
                    "api/exercise",
                    request,
                    cancellationToken);

                _logger.LogInformation("Exercise {ExerciseId} updated successfully", request.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update exercise {ExerciseId}", request.Id);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task DeleteAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Exercise ID cannot be empty.", nameof(id));
            }

            _logger.LogInformation("Deleting exercise {ExerciseId}", id);

            try
            {
                await DeleteAsync(
                    $"api/exercise/{id}",
                    cancellationToken);

                _logger.LogInformation("Exercise {ExerciseId} deleted successfully", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete exercise {ExerciseId}", id);
                throw;
            }
        }
    }
}

