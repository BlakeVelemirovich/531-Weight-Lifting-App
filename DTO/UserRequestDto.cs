using System.Text.Json.Serialization;

namespace _531WorkoutApi.DTO;

public class UserRequestDto
{
    [JsonPropertyName("username")]
    public string Username { get; set; }
    
    [JsonPropertyName("passwordHash")]
    public string PasswordHash { get; set; }
}