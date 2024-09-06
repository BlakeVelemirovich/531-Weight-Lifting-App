using _531WorkoutApi.DTO;
using _531WorkoutApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace _531WorkoutApi.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(
        IUserService userService,
        ILogger<UserController> logger
    )
    {
        _userService = userService;
        _logger = logger;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterPost([FromBody] UserRequestDto request)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            await _userService.AddAsync(request);
            return Ok("User Successfully Registered."); 
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred when registering a user. UserRequest: {@UserRequest}", request);
            
            return BadRequest("There was an error when registering the user.");
        }
    }
    
    [HttpPost("authenticate")]
    public async Task<IActionResult> LoginPost([FromBody] UserRequestDto request)
    {
        try
        {
            AuthenticationResult result = await _userService.AuthenticateAsync(request);

            switch (result)
            {
                case AuthenticationResult.Authenticated:
                    return Ok("User authenticated.");
                case AuthenticationResult.UserNotFound:
                    return Ok("User not found");
                case AuthenticationResult.InvalidPassword:
                    return Ok("Invalid password");
            }

            return BadRequest("Internal Server Error: 500");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}