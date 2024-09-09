namespace _531WorkoutApi.Repositories;

public interface IExerciseRepository
{
    Task<int> AddNewWeightMaxAsync(UserExercise userExercise);

    Task<bool> ExerciseExistsAsync(Guid exerciseId);
}