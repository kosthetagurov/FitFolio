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

        [HttpPost("start")]
        public async Task<IActionResult> Start([FromBody] WorkoutStartRequestBody requestBody)
        {
            if (requestBody == null)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByIdAsync(requestBody.UserId.ToString());

            var workout = await _workoutService.StartAsync(user, requestBody.WorkoutName);

            return new JsonResult(workout);
        }

        [HttpPost("stop")]
        public async Task<IActionResult> Stop(Guid id)
        {
            var workout = await _workoutService.GetWorkoutAsync(id);
            if (workout == null)
            {
                return BadRequest("Workout not found");
            }

            await _workoutService.StopAsync(workout);

            return Ok();
        }

        [HttpPost("add-detail")]
        public async Task<IActionResult> AddDetail([FromBody] AddWorkoutDetailRequestBody requestBody)
        {
            if (requestBody == null)
            {
                return BadRequest();
            }

            var workout = await _workoutService.GetWorkoutAsync(requestBody.WorkoutId);
            if (workout == null)
            {
                return BadRequest("Workout not found");
            }

            var exercise = _exerciseService.GetExerciseAsync(requestBody.ExerciseId);
            if (exercise == null)
            {
                return BadRequest("Exercise not found");
            }

            await _workoutService.AddDetail(new WorkoutDetail
            {
                Duration = requestBody.Duration,
                ExerciseId = requestBody.ExerciseId,
                Repetitions = requestBody.Repetitions,
                Sets = requestBody.Sets,
                Weight = requestBody.Weight,
                WorkoutId = requestBody.WorkoutId,
            });

            return Ok();
        }

        [HttpPost("update-comment")]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentRequestBody requestBody)
        {
            if (requestBody == null)
            {
                return BadRequest();
            }

            var workout = await _workoutService.GetWorkoutAsync(requestBody.WorkoutId);
            if (workout == null)
            {
                return BadRequest("Workout not found");
            }

            await _workoutService.UpdateComment(workout, requestBody.Comment);

            return Ok();
        }
    }
}
