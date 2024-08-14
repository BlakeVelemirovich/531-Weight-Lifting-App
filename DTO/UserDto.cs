namespace _531WorkoutApi.DTO;

public class UserDto
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
}