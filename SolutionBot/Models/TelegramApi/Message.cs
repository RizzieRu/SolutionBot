using System.Text.Json.Serialization;

namespace SolutionBot.Models.TelegramApi;

public class Message
{
    [JsonPropertyName("message_id")]
    public string MessageId { get; set; }
    
    [JsonPropertyName("from")]
    public User From { get; set; }
    
    [JsonPropertyName("text")]
    public string Text { get; set; }
}