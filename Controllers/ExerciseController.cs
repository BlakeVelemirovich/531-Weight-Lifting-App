using _531WorkoutApi.Domains;
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
    public async Task<IActionResult> MaxWeightGet([FromQuery] UserExerciseRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        try
        {
            var workoutSet = await _exerciseService.AddNewMaxWeightAsync(request);
            return Ok(workoutSet);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occured while generating a new workout set.");
            return BadRequest("There was an error when generating a workout set");
        }
    }
}