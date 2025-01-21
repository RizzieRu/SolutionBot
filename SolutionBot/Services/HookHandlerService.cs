using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using SolutionBot.Models.TelegramApi;
using SolutionBot.Services.Inferfaces;

namespace SolutionBot.Services;

public class HookHandlerService : IHookHandlerService
{
    private readonly ITelegramService _telegramService;
    
    private readonly ISolutionCommandsService _solutionCommandsService;
    
    private readonly ILogger<HookHandlerService> _logger;
    
    public HookHandlerService(ITelegramService telegramService, ILogger<HookHandlerService> logger, ISolutionCommandsService solutionCommandsService)
    {
        _telegramService = telegramService;
        
        _logger = logger;
        
        _solutionCommandsService = solutionCommandsService;
    }
    
    public async Task HandleRequestAsync(Message message)
    {
        _logger.LogInformation("Handling hook request");
        _logger.LogInformation(JsonSerializer.Serialize(message));

        try
        {
            string[] words = message.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string result;

            switch (words[0])
            {
                case "/start":
                    _logger.LogInformation("Case: /start");
                    result = _solutionCommandsService.DefaultText();
                    break;
                case "посчитай":
                    _logger.LogInformation("Case: count");
                    result = $"Число символов: {_solutionCommandsService.CountText(message).ToString()}";
                    break;
                case "сумма":
                    _logger.LogInformation("Case: summ");
                    result = $"Сумма: {_solutionCommandsService.SolveMath(message).ToString()}";
                    break;
                default:
                    _logger.LogInformation("Case: default");
                    result = _solutionCommandsService.DefaultNoMatchText();
                    break;
            }
            
            await _telegramService.SendTextMessageAsync(message.From.Id, result);
        }
        catch (Exception ex)
        {
            _logger.LogError("Handler error");
            _logger.LogError(ex.Message);
            await _telegramService.SendTextMessageAsync(message.From.Id, "Возникла ошибка. Извините");
        }
    }
}