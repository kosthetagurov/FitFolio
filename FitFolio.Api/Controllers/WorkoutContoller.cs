using FitFolio.Api.Client.Models.Workout;
using FitFolio.Data.Models;
using FitFolio.Domain.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitFolio.Api.Controllers
{
    [ApiController]
    [Route("api/workout")]
    public class WorkoutContoller : ControllerBase
    {
        private readonly IWorkoutService _workoutService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IExerciseService _exerciseService;

        public WorkoutContoller(IWorkoutService workoutService, UserManager<ApplicationUser> userManager, IExerciseService exerciseService)
        {
            _workoutService = workoutService;
            _userManager = userManager;
            _exerciseService = exerciseService;
        }

        /// <summary>
        /// Starts a new workout session.
        /// </summary>
        /// <param name="requestBody">The workout start parameters.</param>
        /// <returns>The created workout with 201 Created status.</returns>
        [HttpPost("start")]
        [ProducesResponseType(typeof(Workout), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Start([FromBody] WorkoutStartRequestBody requestBody)
        {
            if (requestBody == null)
            {
                return BadRequest("Request body is required");
            }

            if (requestBody.UserId == Guid.Empty)
            {
                return BadRequest("User ID is required");
            }

            var user = await _userManager.FindByIdAsync(requestBody.UserId.ToString());
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var workout = await _workoutService.StartAsync(user, requestBody.WorkoutName);

            return CreatedAtAction(nameof(Stop), new { id = workout.Id }, workout);
        }

        /// <summary>
        /// Stops an active workout session.
        /// </summary>
        /// <param name="id">The workout ID.</param>
        /// <returns>200 OK if successful.</returns>
        [HttpPost("stop")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Stop(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid workout ID");
            }

            var workout = await _workoutService.GetWorkoutAsync(id);
            if (workout == null)
            {
                return NotFound("Workout not found");
            }

            await _workoutService.StopAsync(workout);

            return Ok();
        }

        /// <summary>
        /// Adds a detail (exercise) to a workout.
        /// </summary>
        /// <param name="requestBody">The workout detail parameters.</param>
        /// <returns>201 Created if successful.</returns>
        [HttpPost("add-detail")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddDetail([FromBody] AddWorkoutDetailRequestBody requestBody)
        {
            if (requestBody == null)
            {
                return BadRequest("Request body is required");
            }

            if (requestBody.WorkoutId == Guid.Empty)
            {
                return BadRequest("Workout ID is required");
            }

            if (requestBody.ExerciseId == Guid.Empty)
            {
                return BadRequest("Exercise ID is required");
            }

            if (requestBody.Sets.HasValue && requestBody.Sets.Value <= 0)
            {
                return BadRequest("Sets must be greater than 0");
            }

            if (requestBody.Repetitions.HasValue && requestBody.Repetitions.Value <= 0)
            {
                return BadRequest("Repetitions must be greater than 0");
            }

            if (requestBody.Weight.HasValue && requestBody.Weight.Value < 0)
            {
                return BadRequest("Weight cannot be negative");
            }

            if (requestBody.Duration.HasValue && requestBody.Duration.Value <= 0)
            {
                return BadRequest("Duration must be greater than 0");
            }

            var workout = await _workoutService.GetWorkoutAsync(requestBody.WorkoutId);
            if (workout == null)
            {
                return NotFound("Workout not found");
            }

            var exercise = await _exerciseService.GetExerciseAsync(requestBody.ExerciseId);
            if (exercise == null)
            {
                return NotFound("Exercise not found");
            }

            var workoutDetail = new WorkoutDetail
            {
                Duration = requestBody.Duration,
                ExerciseId = requestBody.ExerciseId,
                Repetitions = requestBody.Repetitions,
                Sets = requestBody.Sets,
                Weight = requestBody.Weight,
                WorkoutId = requestBody.WorkoutId,
            };

            await _workoutService.AddDetail(workoutDetail);

            return CreatedAtAction(nameof(AddDetail), new { id = workoutDetail.Id }, workoutDetail);
        }

        /// <summary>
        /// Updates the comment for a workout.
        /// </summary>
        /// <param name="requestBody">The comment update parameters.</param>
        /// <returns>The updated workout with 200 OK status.</returns>
        [HttpPut("comment")]
        [ProducesResponseType(typeof(Workout), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentRequestBody requestBody)
        {
            if (requestBody == null)
            {
                return BadRequest("Request body is required");
            }

            if (requestBody.WorkoutId == Guid.Empty)
            {
                return BadRequest("Workout ID is required");
            }

            var workout = await _workoutService.GetWorkoutAsync(requestBody.WorkoutId);
            if (workout == null)
            {
                return NotFound("Workout not found");
            }

            await _workoutService.UpdateComment(workout, requestBody.Comment);

            return Ok(workout);
        }
    }
}
