namespace _531WorkoutApi.DTO;

public class SetDto
{
    public SetDto()
    {
        NumOfReps = new List<int>();
        Weight = new List<double>();
    }
    
    public List<int> NumOfReps { get; set; }
    
    public List<double> Weight { get; set; }
}