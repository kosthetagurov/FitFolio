using FitFolio.Api.Client.Models.ExerciseCategory;
using FitFolio.Data.Models;
using FitFolio.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FitFolio.Api.Controllers
{
    [ApiController]
    [Route("api/exercise-category")]
    public class ExerciseCategoryController : ControllerBase
    {
        private readonly IExerciseCategoryService _exerciseCategoryService;

        public ExerciseCategoryController(IExerciseCategoryService exerciseCategoryService)
        {
            _exerciseCategoryService = exerciseCategoryService;
        }

        /// <summary>
        /// Gets an exercise category by ID.
        /// </summary>
        /// <param name="id">The exercise category ID.</param>
        /// <returns>The exercise category if found.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid exercise category ID");
            }

            var category = await _exerciseCategoryService.GetExerciseAsync(id);
            if (category == null)
            {
                return NotFound("Exercise category not found");
            }

            return Ok(category);
        }

        /// <summary>
        /// Gets a list of exercise categories with pagination.
        /// </summary>
        /// <param name="skip">Number of items to skip.</param>
        /// <param name="take">Number of items to take (default: 20).</param>
        /// <returns>List of exercise categories.</returns>
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            if (skip < 0)
            {
                return BadRequest("Skip parameter must be non-negative");
            }

            await _exerciseCategoryService.GetAsync(skip, take);
            return Ok();
        }

        /// <summary>
        /// Creates a new exercise category.
        /// </summary>
        /// <param name="requestBody">The exercise category data.</param>
        /// <returns>The created exercise category.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExerciseCategoryRequestBody requestBody)
        {
            if (requestBody == null)
            {
                return BadRequest("Request body is required");
            }

            if (string.IsNullOrWhiteSpace(requestBody.Name))
            {
                return BadRequest("Exercise category name is required");
            }

            var category = new ExerciseCategory
            {
                Name = requestBody.Name
            };

            await _exerciseCategoryService.CreateAsync(category);

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        /// <summary>
        /// Updates an existing exercise category.
        /// </summary>
        /// <param name="requestBody">The updated exercise category data.</param>
        /// <returns>No content if successful.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateExerciseCategoryRequestBody requestBody)
        {
            if (requestBody == null)
            {
                return BadRequest("Request body is required");
            }

            if (requestBody.Id == Guid.Empty)
            {
                return BadRequest("Exercise category ID is required");
            }

            if (string.IsNullOrWhiteSpace(requestBody.Name))
            {
                return BadRequest("Exercise category name is required");
            }

            var category = await _exerciseCategoryService.GetExerciseAsync(requestBody.Id);
            if (category == null)
            {
                return NotFound("Exercise category not found");
            }

            category.Name = requestBody.Name;

            await _exerciseCategoryService.UpdateAsync(category);

            return NoContent();
        }

        /// <summary>
        /// Deletes an exercise category.
        /// </summary>
        /// <param name="id">The exercise category ID.</param>
        /// <returns>No content if successful.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid exercise category ID");
            }

            var category = await _exerciseCategoryService.GetExerciseAsync(id);
            if (category == null)
            {
                return NotFound("Exercise category not found");
            }

            await _exerciseCategoryService.DeleteAsync(category);

            return NoContent();
        }
    }
}

