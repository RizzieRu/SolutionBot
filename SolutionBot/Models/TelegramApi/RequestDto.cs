using System.Text.Json.Serialization;

namespace SolutionBot.Models.TelegramApi;

public class RequestDto
{
    [JsonPropertyName("update_id")]
    public int UpdateId { get; set; }
    
    [JsonPropertyName("message")]
    public Message Message { get; set; }
}