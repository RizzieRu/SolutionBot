using System.Text.Json.Serialization;

namespace SolutionBot.Models.TelegramApi;

public class RequestDto
{
    [JsonPropertyName("message")]
    public Message Message { get; set; }
}