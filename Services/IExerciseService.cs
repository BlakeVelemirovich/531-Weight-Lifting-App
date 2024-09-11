using _531WorkoutApi.Domains;
using _531WorkoutApi.DTO;

namespace _531WorkoutApi.Services;

public interface IExerciseService
{
    public Task<SetDto> AddNewMaxWeightAsync(UserExerciseRequest request);

    public Task<SetDto> GetUserExercise(Guid userId, Guid exerciseId);

    public Task<SetDto> UpdateCurrentWeek(Guid userId, Guid exercise, int week);
}