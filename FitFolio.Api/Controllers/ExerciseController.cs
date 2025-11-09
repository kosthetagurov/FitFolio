using FitFolio.Api.Client.Models.Exercise;
using FitFolio.Data.Models;
using FitFolio.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FitFolio.Api.Controllers
{
    [ApiController]
    [Route("api/exercise")]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        /// <summary>
        /// Gets an exercise by ID.
        /// </summary>
        /// <param name="id">The exercise ID.</param>
        /// <returns>The exercise if found.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Exercise), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid exercise ID");
            }

            var exercise = await _exerciseService.GetExerciseAsync(id);
            if (exercise == null)
            {
                return NotFound("Exercise not found");
            }

            return Ok(exercise);
        }

        /// <summary>
        /// Gets a list of exercises with pagination.
        /// </summary>
        /// <param name="skip">Number of items to skip.</param>
        /// <param name="take">Number of items to take (default: 20).</param>
        /// <returns>List of exercises.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Exercise>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetList([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            if (skip < 0)
            {
                return BadRequest("Skip parameter must be non-negative");
            }

            if (take <= 0 || take > 100)
            {
                return BadRequest("Take parameter must be between 1 and 100");
            }

            var exercises = await _exerciseService.GetAsync(skip, take);
            return Ok(exercises);
        }

        /// <summary>
        /// Creates a new exercise.
        /// </summary>
        /// <param name="requestBody">The exercise data.</param>
        /// <returns>The created exercise with 201 Created status.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Exercise), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateExerciseRequestBody requestBody)
        {
            if (requestBody == null)
            {
                return BadRequest("Request body is required");
            }

            if (string.IsNullOrWhiteSpace(requestBody.Name))
            {
                return BadRequest("Exercise name is required");
            }

            if (requestBody.CategoryId == Guid.Empty)
            {
                return BadRequest("Category ID is required");
            }

            var exercise = new Exercise
            {
                Name = requestBody.Name,
                Description = requestBody.Description,
                CategoryId = requestBody.CategoryId
            };

            await _exerciseService.CreateAsync(exercise);

            return CreatedAtAction(nameof(GetById), new { id = exercise.Id }, exercise);
        }

        /// <summary>
        /// Updates an existing exercise.
        /// </summary>
        /// <param name="requestBody">The updated exercise data.</param>
        /// <returns>The updated exercise with 200 OK status.</returns>
        [HttpPut]
        [ProducesResponseType(typeof(Exercise), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateExerciseRequestBody requestBody)
        {
            if (requestBody == null)
            {
                return BadRequest("Request body is required");
            }

            if (requestBody.Id == Guid.Empty)
            {
                return BadRequest("Exercise ID is required");
            }

            if (string.IsNullOrWhiteSpace(requestBody.Name))
            {
                return BadRequest("Exercise name is required");
            }

            if (requestBody.CategoryId == Guid.Empty)
            {
                return BadRequest("Category ID is required");
            }

            var exercise = await _exerciseService.GetExerciseAsync(requestBody.Id);
            if (exercise == null)
            {
                return NotFound("Exercise not found");
            }

            exercise.Name = requestBody.Name;
            exercise.Description = requestBody.Description;
            exercise.CategoryId = requestBody.CategoryId;

            await _exerciseService.UpdateAsync(exercise);

            return Ok(exercise);
        }

        /// <summary>
        /// Deletes an exercise.
        /// </summary>
        /// <param name="id">The exercise ID.</param>
        /// <returns>204 No Content if successful.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid exercise ID");
            }

            var exercise = await _exerciseService.GetExerciseAsync(id);
            if (exercise == null)
            {
                return NotFound("Exercise not found");
            }

            await _exerciseService.DeleteAsync(exercise);

            return NoContent();
        }
    }
}

