using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace _531WorkoutApi.Domains;

public class UserExerciseRequest
{
    [Required]
    [FromQuery(Name = "userId")]
    public Guid UserId { get; set; }
    
    [Required]
    [FromQuery(Name = "exerciseId")]
    public Guid ExerciseId { get; set; }
    
    [Required, Range(1, double.MaxValue, ErrorMessage = "Max weight must be greater than 0.")]
    [FromQuery(Name = "oneRepMax")]
    public double OneRepMax { get; set; }
}