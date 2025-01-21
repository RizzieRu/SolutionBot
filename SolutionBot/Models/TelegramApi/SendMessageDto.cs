using System.Text.Json.Serialization;

namespace SolutionBot.Models.TelegramApi;

public class SendMessageDto
{
    [JsonPropertyName("chat_id")]
    public int ChatId { get; set; }
    
    [JsonPropertyName("text")]
    public string Text { get; set; }

    public SendMessageDto(int chatId, string text)
    {
        ChatId = chatId;
        
        Text = text;
    }
}