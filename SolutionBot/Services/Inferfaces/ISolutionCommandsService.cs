using SolutionBot.Models.TelegramApi;

namespace SolutionBot.Services.Inferfaces;

public interface ISolutionCommandsService
{
    int CountText(Message jsonObject);

    int SolveMath(Message jsonObject);

    string DefaultText();

    string DefaultNoMatchText();
}