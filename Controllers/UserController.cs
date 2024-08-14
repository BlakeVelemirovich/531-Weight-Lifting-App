using _531WorkoutApi.DTO;
using _531WorkoutApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace _531WorkoutApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // POST: api/user
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserRequestDto request)
    {
        try
        {
            await _userService.AddAsync(request);
            return Ok("User Successfully Registered.");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}