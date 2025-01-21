using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SolutionBot.Models;
using SolutionBot.Services;
using SolutionBot.Services.Inferfaces;

namespace SolutionBot.Controllers;

public class ApiController : Controller
{
    private readonly ILogger<ApiController> _logger;
    
    private readonly IHookHandlerService _hookHandlerService;

    public ApiController(ILogger<ApiController> logger, IHookHandlerService hookHandlerService)
    {
        _logger = logger;
        
        _hookHandlerService = hookHandlerService;
    }

    [Route("api/v2/hook")]
    [HttpPost]
    public IActionResult Hook(string? json)
    {
        if (json == null)
            throw new ArgumentNullException(nameof(json));

        _hookHandlerService.HandleRequest(json);
        
        return Ok();
    }
}