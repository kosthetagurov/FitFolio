using FitFolio.Api.Client.Models.ExerciseCategory;
using Microsoft.Extensions.Logging;

namespace FitFolio.Api.Client.ExerciseCategory
{
    /// <summary>
    /// API client for exercise category-related operations.
    /// </summary>
    public class ExerciseCategoryApiClient : ApiClientBase, IExerciseCategoryApiClient
    {
        private readonly ILogger<ExerciseCategoryApiClient> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseCategoryApiClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client instance (configured via IHttpClientFactory).</param>
        /// <param name="logger">The logger instance.</param>
        public ExerciseCategoryApiClient(
            HttpClient httpClient,
            ILogger<ExerciseCategoryApiClient> logger)
            : base(httpClient, logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc />
        public async Task<Data.Models.ExerciseCategory> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Exercise category ID cannot be empty.", nameof(id));
            }

            _logger.LogInformation("Getting exercise category {CategoryId}", id);

            try
            {
                var category = await GetAsync<Data.Models.ExerciseCategory>(
                    $"api/exercise-category/{id}",
                    cancellationToken);

                _logger.LogInformation("Exercise category {CategoryId} retrieved successfully", id);
                return category;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get exercise category {CategoryId}", id);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<List<Data.Models.ExerciseCategory>> GetListAsync(
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

            _logger.LogInformation("Getting exercise category list with skip={Skip}, take={Take}", skip, take);

            try
            {
                var categories = await GetAsync<List<Data.Models.ExerciseCategory>>(
                    $"api/exercise-category?skip={skip}&take={take}",
                    cancellationToken);

                _logger.LogInformation("Retrieved {Count} exercise categories", categories.Count);
                return categories;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get exercise category list");
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<Data.Models.ExerciseCategory> CreateAsync(
            CreateExerciseCategoryRequestBody request,
            CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentException("Exercise category name is required.", nameof(request));
            }

            _logger.LogInformation("Creating exercise category '{CategoryName}'", request.Name);

            try
            {
                var category = await PostAsync<Data.Models.ExerciseCategory>(
                    "api/exercise-category",
                    request,
                    cancellationToken);

                _logger.LogInformation("Exercise category created successfully with ID {CategoryId}", category.Id);
                return category;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create exercise category '{CategoryName}'", request.Name);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task UpdateAsync(
            UpdateExerciseCategoryRequestBody request,
            CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Id == Guid.Empty)
            {
                throw new ArgumentException("Exercise category ID is required.", nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentException("Exercise category name is required.", nameof(request));
            }

            _logger.LogInformation("Updating exercise category {CategoryId}", request.Id);

            try
            {
                await PutAsync(
                    "api/exercise-category",
                    request,
                    cancellationToken);

                _logger.LogInformation("Exercise category {CategoryId} updated successfully", request.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update exercise category {CategoryId}", request.Id);
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
                throw new ArgumentException("Exercise category ID cannot be empty.", nameof(id));
            }

            _logger.LogInformation("Deleting exercise category {CategoryId}", id);

            try
            {
                await DeleteAsync(
                    $"api/exercise-category/{id}",
                    cancellationToken);

                _logger.LogInformation("Exercise category {CategoryId} deleted successfully", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete exercise category {CategoryId}", id);
                throw;
            }
        }
    }
}

