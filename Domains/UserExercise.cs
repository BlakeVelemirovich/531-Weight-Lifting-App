public class UserExercise {
    public Guid UserExerciseId { get; set;}
    
    public Guid UserId { get; set; }
    
    public Guid ExerciseId { get; set; }
    
    public int CurrentWeek { get; set; }
    
    public float OneRepMax { get; set; }

    public float CurrentWeight { get; set; }
}