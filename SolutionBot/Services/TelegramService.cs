using System.Text;
using System.Text.Json;
using SolutionBot.Models.TelegramApi;
using SolutionBot.Services.Inferfaces;

namespace SolutionBot.Services;

public class TelegramService : ITelegramService
{
    private readonly string _token;
    
    private readonly HttpClient _httpClient;
    
    private readonly ILogger<TelegramService> _logger;
    
    public TelegramService(IConfiguration configuration, ILogger<TelegramService> logger, IHttpClientFactory httpClientFactory)
    {
        _token = configuration["Telegram:Token"] ?? throw new NullReferenceException("Token is not set");
        
        _httpClient = httpClientFactory.CreateClient();

        _logger = logger;
    }
    
    public async Task SendTextMessageAsync(string chatId, string message)
    {
        try
        {
            var request = new SendMessageDto(chatId, message);

            var uri = new Uri($"https://api.telegram.org/bot{_token}/sendMessage");

            string json = JsonSerializer.Serialize(request);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var postResult = await _httpClient.PostAsync(uri, content);

            postResult.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }
}