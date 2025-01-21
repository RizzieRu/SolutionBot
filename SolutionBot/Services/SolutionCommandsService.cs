using SolutionBot.Models.TelegramApi;
using SolutionBot.Services.Inferfaces;

namespace SolutionBot.Services;

public class SolutionCommandsService : ISolutionCommandsService
{
    private readonly string _defaultWelcomeText;

    private readonly string _defaultNoMatchText;
    
    public SolutionCommandsService(IConfiguration configuration)
    {
        _defaultWelcomeText = configuration["Telegram:WelcomeText"] ?? "Welcome";
        
        _defaultNoMatchText = configuration["Telegram:NoMatchText"] ?? "NoMatch";
    }
    
    public int CountText(Message jsonObject)
    {
        return jsonObject.Text.Length;
    }

    public int SolveMath(Message jsonObject)
    {
        int total = 0;
        
        foreach (string word in jsonObject.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries))
        {
            if (word.ToLower() != "сумма")
            { 
                total += Convert.ToInt32(word);
            }
        }

        return total;
    }

    public string DefaultText()
    {
        return _defaultWelcomeText;
    }

    public string DefaultNoMatchText()
    {
        return _defaultNoMatchText;
    }
}