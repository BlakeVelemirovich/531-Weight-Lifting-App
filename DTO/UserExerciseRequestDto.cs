using System.ComponentModel.DataAnnotations;

namespace _531WorkoutApi.DTO;

public class UserExerciseRequestDto
{
    [Required]
    public Guid userId; 
    
    [Required]
    public Guid exerciseId;
    
    [Required, Range(1, double.MaxValue, ErrorMessage = "Max Weight must be greater than 0.")]
    public double maxWeight;
}