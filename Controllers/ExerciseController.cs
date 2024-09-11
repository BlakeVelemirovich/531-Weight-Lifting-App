using _531WorkoutApi.Domains;
using _531WorkoutApi.DTO;
using _531WorkoutApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;
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

    [HttpGet("maxWeight")]
    public async Task<IActionResult> MaxWeightGet([FromQuery] UserExerciseRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        try
        {
            SetDto workoutSet = await _exerciseService.AddNewMaxWeightAsync(request);
            return Ok(workoutSet);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occured while generating a new workout set.");
            return BadRequest("There was an error when generating a workout set");
        }
    }

    [HttpGet("userExercise")]
    public async Task<IActionResult> UserExerciseGet(
        [FromQuery] Guid userId,
        [FromQuery] Guid exerciseId
        )
    {
        try
        {
            var workoutSet = await _exerciseService.GetUserExercise(userId, exerciseId);
            return Ok(workoutSet);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "There was an error retrieving the workout set.");

            return BadRequest("There was an error retrieving the workout set.");
        }
    }

    [HttpGet("updateWeek")]
    public async Task<IActionResult> UpdateWeekGet(
        [FromQuery] Guid userId,
        [FromQuery] Guid exerciseId,
        [FromQuery] int week
    )
    {
        try
        {
            var workoutSet = await _exerciseService.UpdateCurrentWeek(userId, exerciseId, week);
            return Ok(workoutSet);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "There was an error updating the current week.");

            return BadRequest("There was an error updating the current week.");
        }
    }
}