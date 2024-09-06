namespace _531WorkoutApi.Repositories;

public interface IExerciseRepository
{
    Task<int> AddNewWeightMax(Guid userId, double weightMax);
}