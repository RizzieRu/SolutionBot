using System.Text.Json.Serialization;

namespace SolutionBot.Models.TelegramApi;

public class User
{
    // Not int cause user ID may have more then 10 symbols
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }
    
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }
    
    [JsonPropertyName("username")]
    public string UserName { get; set; }
}