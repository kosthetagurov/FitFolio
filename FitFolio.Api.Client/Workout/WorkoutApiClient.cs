using FitFolio.Api.Client.Models.Workout;
using Microsoft.Extensions.Logging;

namespace FitFolio.Api.Client.Workout
{
    /// <summary>
    /// API client for workout-related operations.
    /// </summary>
    public class WorkoutApiClient : ApiClientBase, IWorkoutApiClient
    {
        private readonly ILogger<WorkoutApiClient> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkoutApiClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client instance (configured via IHttpClientFactory).</param>
        /// <param name="logger">The logger instance.</param>
        public WorkoutApiClient(
            HttpClient httpClient,
            ILogger<WorkoutApiClient> logger) 
            : base(httpClient, logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc />
        public async Task<Data.Models.Workout> StartAsync(
            WorkoutStartRequestBody request, 
            CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.UserId == Guid.Empty)
            {
                throw new ArgumentException("UserId cannot be empty.", nameof(request));
            }

            _logger.LogInformation(
                "Starting workout for user {UserId} with name '{WorkoutName}'",
                request.UserId,
                request.WorkoutName ?? "Unnamed");

            try
            {
                var workout = await PostAsync<Data.Models.Workout>(
                    "api/workout/start",
                    request,
                    cancellationToken);

                _logger.LogInformation("Workout started successfully with ID {WorkoutId}", workout.Id);
                return workout;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to start workout for user {UserId}", request.UserId);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task StopAsync(
            Guid workoutId, 
            CancellationToken cancellationToken = default)
        {
            if (workoutId == Guid.Empty)
            {
                throw new ArgumentException("WorkoutId cannot be empty.", nameof(workoutId));
            }

            _logger.LogInformation("Stopping workout {WorkoutId}", workoutId);

            try
            {
                await PostAsync(
                    $"api/workout/stop?id={workoutId}",
                    content: null,
                    cancellationToken);

                _logger.LogInformation("Workout {WorkoutId} stopped successfully", workoutId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to stop workout {WorkoutId}", workoutId);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task AddDetailAsync(
            AddWorkoutDetailRequestBody request, 
            CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.WorkoutId == Guid.Empty)
            {
                throw new ArgumentException("WorkoutId cannot be empty.", nameof(request));
            }

            if (request.ExerciseId == Guid.Empty)
            {
                throw new ArgumentException("ExerciseId cannot be empty.", nameof(request));
            }

            _logger.LogInformation(
                "Adding detail to workout {WorkoutId}: Exercise {ExerciseId}",
                request.WorkoutId,
                request.ExerciseId);

            try
            {
                await PostAsync(
                    "api/workout/add-detail",
                    request,
                    cancellationToken);

                _logger.LogInformation(
                    "Detail added successfully to workout {WorkoutId}",
                    request.WorkoutId);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Failed to add detail to workout {WorkoutId}",
                    request.WorkoutId);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<Data.Models.Workout> UpdateCommentAsync(
            UpdateCommentRequestBody request, 
            CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.WorkoutId == Guid.Empty)
            {
                throw new ArgumentException("WorkoutId cannot be empty.", nameof(request));
            }

            _logger.LogInformation(
                "Updating comment for workout {WorkoutId}",
                request.WorkoutId);

            try
            {
                var workout = await PutAsync<Data.Models.Workout>(
                    "api/workout/comment",
                    request,
                    cancellationToken);

                _logger.LogInformation(
                    "Comment updated successfully for workout {WorkoutId}",
                    request.WorkoutId);

                return workout;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Failed to update comment for workout {WorkoutId}",
                    request.WorkoutId);
                throw;
            }
        }
    }
}
