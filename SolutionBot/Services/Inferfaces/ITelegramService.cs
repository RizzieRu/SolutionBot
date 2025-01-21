namespace SolutionBot.Services.Inferfaces;

public interface ITelegramService
{
    Task SendTextMessageAsync(int chatId, string message);
}