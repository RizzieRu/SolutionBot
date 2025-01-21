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
    public async Task<IActionResult> Hook([FromBody] Message? message)
    {
        if (message == null)
            throw new ArgumentNullException(nameof(message));
        
        await _hookHandlerService.HandleRequestAsync(message);
        
        return Ok();
    }
}