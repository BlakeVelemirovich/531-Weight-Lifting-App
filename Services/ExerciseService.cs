using _531WorkoutApi.Domains;
using _531WorkoutApi.DTO;
using _531WorkoutApi.Helpers;
using _531WorkoutApi.Repositories;

namespace _531WorkoutApi.Services;

public class ExerciseService: IExerciseService
{
    private readonly ExerciseCalculator _exerciseCalculator;
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IUserRepository _userRepository;
    
    public ExerciseService(
        ExerciseCalculator exerciseCalculator,
        IExerciseRepository exerciseRepository,
        IUserRepository userRepository
        )
    {
        _exerciseCalculator = exerciseCalculator;
        _exerciseRepository = exerciseRepository;
        _userRepository = userRepository;
    }
    
    public async Task<SetDto> AddNewMaxWeightAsync(UserExerciseRequest request)
    {
        if (!await _exerciseRepository.ExerciseExistsAsync(request.ExerciseId))
        {
            throw new Exception("Exercise does not exist");
        }

        if (!await _userRepository.UserExistsAsync(request.UserId))
        {
            throw new Exception("User does not exist");
        }
        
        UserExercise userExercise = new UserExercise()
        {
            UserExerciseId = Guid.NewGuid(),
            UserId = request.UserId,
            ExerciseId = request.ExerciseId,
            OneRepMax = request.OneRepMax,
            CurrentWeek = 1
        };

        try
        {
            SetDto workoutSet = _exerciseCalculator.CalculateByCurrentWeek(1, request.OneRepMax);
            if (workoutSet == null)
            {
                throw new Exception("Workout Calculation failed");
            }
            
            await _exerciseRepository.AddNewWeightMaxAsync(userExercise);

            return workoutSet;
        }
        catch (Exception e)
        {   
            throw new Exception("Something went wrong when saving the exercise.", e);
        }
    }
}