using Microsoft.AspNetCore.Mvc;
using SolutionBot.Models.TelegramApi;
using SolutionBot.Services.Inferfaces;

namespace SolutionBot.Controllers;

[ApiController]
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
        if (request == null)
        {
            Console.WriteLine("Request is null");
            return Ok();
        }

        await _hookHandlerService.HandleRequestAsync(request.Message);
        return Ok();
    }
}