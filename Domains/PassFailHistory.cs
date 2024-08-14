using System.ComponentModel.DataAnnotations;

public class PassFailHistory
{
    [Key]
    public Guid HistoryId { get; set; }
    
    public Guid UserExerciseId { get; set; }
    
    public int Week { get; set; }
    
    public bool Passed { get; set; }
    
    public DateTime Date { get; set; }
}