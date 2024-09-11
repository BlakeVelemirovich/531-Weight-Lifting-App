namespace _531WorkoutApi.Repositories;

public interface IExerciseRepository
{
    Task<int> AddNewWeightMaxAsync(UserExercise userExercise);

    Task<bool> ExerciseExistsAsync(Guid exerciseId);

    Task<UserExercise> GetUserExercise(Guid userId, Guid exerciseId);

    Task<UserExercise> UpdateCurrentWeek(Guid userId, Guid exerciseId, int week);
}