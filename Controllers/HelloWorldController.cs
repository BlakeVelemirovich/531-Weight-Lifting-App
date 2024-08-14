using _531WorkoutApi.DTO;
using _531WorkoutApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace _531WorkoutApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController: ControllerBase
{
    private readonly IHelloWorldService _helloWorldService;

    public HelloWorldController(
        IHelloWorldService helloWorldService
    )
    {
        _helloWorldService = helloWorldService;
    }
    
    // GET: api/helloworld
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var myString = _helloWorldService.GetHelloWorld();
            return Ok(new HelloWorldDto
            {
                HelloWorld = myString
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
        
    }
}