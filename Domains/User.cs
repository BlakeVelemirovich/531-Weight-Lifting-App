using System.ComponentModel.DataAnnotations;

namespace _531WorkoutApi.Domains;

public class User
{
    [Required]
    public Guid UserId { get; set; }
    
    [MaxLength(50)]
    public string Username { get; set; }
    
    [MaxLength(128)]
    public string PasswordHash { get; set; }
}