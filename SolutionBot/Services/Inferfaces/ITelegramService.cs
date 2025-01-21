namespace SolutionBot.Services.Inferfaces;

public interface ITelegramService
{
    Task SendTextMessageAsync(string chatId, string message);
}