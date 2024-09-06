using _531WorkoutApi.DTO;
using _531WorkoutApi.Helpers;
using _531WorkoutApi.Repositories;

namespace _531WorkoutApi.Services;

public class ExerciseService
{
    private readonly ExerciseCalculator _exerciseCalculator;
    private readonly ExerciseRepository _exerciseRepository;
    
    public ExerciseService(
        ExerciseCalculator exerciseCalculator,
        ExerciseRepository exerciseRepository
        )
    {
        _exerciseCalculator = exerciseCalculator;
        _exerciseRepository = exerciseRepository;
    }
    
    public async Task<SetDto> AddNewMaxWeight(Guid userId, Guid exerciseId, float maxWeight)
    {
        UserExercise userExercise = new UserExercise()
        {
            UserExerciseId = Guid.NewGuid(),
            UserId = userId,
            ExerciseId = exerciseId,
            OneRepMax = maxWeight,
            CurrentWeek = 1
        };

        SetDto workoutSet;

        try
        {
            workoutSet = _exerciseCalculator.CalculateByCurrentWeek(1, maxWeight);
            await _exerciseRepository.AddNewWeightMax(userExercise);

            return workoutSet ?? new SetDto();
        }
        catch (Exception e)
        {
            throw new Exception("Something went wrong when saving the exercise.", e);
        }
    }
}