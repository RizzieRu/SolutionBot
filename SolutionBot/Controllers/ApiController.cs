using Microsoft.AspNetCore.Mvc;
using SolutionBot.Models.TelegramApi;
using SolutionBot.Services.Inferfaces;

namespace SolutionBot.Controllers;

[Route("api/v2/[action]")]
public class ApiController : Controller
{
    private readonly ILogger<ApiController> _logger;
    
    private readonly IHookHandlerService _hookHandlerService;

    public ApiController(ILogger<ApiController> logger, IHookHandlerService hookHandlerService)
    {
        _logger = logger;
        
        _hookHandlerService = hookHandlerService;
    }

    [HttpPost]
    public async Task<IActionResult> Hook([FromBody] RequestDto? request)
    {
        using (StreamReader reader = new StreamReader(HttpContext.Request.Body))
        {
            string body = await reader.ReadToEndAsync();
            Console.WriteLine($"Request Body: {body}");
        }
        
        if (request == null)
        {
            Console.WriteLine("Request is null");
            return BadRequest("Invalid request");
        }

        await _hookHandlerService.HandleRequestAsync(request.Message);
        return Ok();
    }
}