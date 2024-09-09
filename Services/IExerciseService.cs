using _531WorkoutApi.Domains;
using _531WorkoutApi.DTO;

namespace _531WorkoutApi.Services;

public interface IExerciseService
{
    public Task<SetDto> AddNewMaxWeightAsync(UserExerciseRequest request);
}