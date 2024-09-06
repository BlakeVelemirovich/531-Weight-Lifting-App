using _531WorkoutApi.DTO;

namespace _531WorkoutApi.Services;

public interface IExerciseService
{
    public Task<SetDto> AddNewMaxWeightAsync(Guid userId, Guid exerciseId, float maxWeight);
}