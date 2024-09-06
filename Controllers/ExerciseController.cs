using _531WorkoutApi.DTO;
using _531WorkoutApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace _531WorkoutApi.Controllers;

[ApiController]
[Route("api/exercise")]
public class ExerciseController: ControllerBase
{
    private readonly ILogger<ExerciseController> _logger;
    private readonly IExerciseService _exerciseService;

    public ExerciseController(
      ILogger<ExerciseController> logger,
      IExerciseService exerciseService
    )
    {
      _logger = logger;
      _exerciseService = exerciseService;
    }

    [HttpGet("max_weight")]
    public async Task<IActionResult> MaxWeightGet(
        [FromQuery] Guid userId, 
        [FromQuery] Guid exerciseId,
        [FromQuery] float maxWeight
        )
    {
        try
        {
            var workoutSet = _exerciseService.AddNewMaxWeightAsync(userId, exerciseId, maxWeight);
            return Ok(workoutSet);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occured while generating a new workout set.");
            return BadRequest("There was an error when generating a workout set");
        }
    }
}