namespace _531WorkoutApi.Domains;

public class User
{
    public Guid userId { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
}