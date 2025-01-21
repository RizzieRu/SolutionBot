using SolutionBot.Models.TelegramApi;

namespace SolutionBot.Services.Inferfaces;

public interface IHookHandlerService
{
    Task HandleRequestAsync(Message message);
}