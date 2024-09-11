using _531WorkoutApi.Domains;
using _531WorkoutApi.DTO;
using _531WorkoutApi.Helpers;
using _531WorkoutApi.Repositories;
using AutoMapper;

namespace _531WorkoutApi.Services;

public class ExerciseService: IExerciseService
{
    private readonly ExerciseCalculator _exerciseCalculator;
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public ExerciseService(
        ExerciseCalculator exerciseCalculator,
        IExerciseRepository exerciseRepository,
        IUserRepository userRepository,
        IMapper mapper
        )
    {
        _exerciseCalculator = exerciseCalculator;
        _exerciseRepository = exerciseRepository;
        _userRepository = userRepository;
        _mapper = mapper;
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

       
        SetDto workoutSet = _exerciseCalculator.CalculateByCurrentWeek(1, request.OneRepMax);
        if (workoutSet == null)
        {
            throw new Exception("Workout Calculation failed");
        }
        
        await _exerciseRepository.AddNewWeightMaxAsync(userExercise);

        return workoutSet;
    }

    public async Task<SetDto> GetUserExercise(Guid userId, Guid exerciseId)
    {
        UserExercise userExercise = await _exerciseRepository.GetUserExercise(userId, exerciseId);
        if (userExercise == null)
        {
            throw new Exception("User's exercise was not found.");
        }

        UserExerciseDto userExerciseDto = _mapper.Map<UserExerciseDto>(userExercise);
        SetDto workoutSet = _exerciseCalculator.CalculateByCurrentWeek(userExerciseDto.CurrentWeek, userExerciseDto.OneRepMax);

        return workoutSet;
    }

    public async Task<SetDto> UpdateCurrentWeek(Guid userId, Guid exerciseId, int week)
    {
        UserExercise userExercise = await _exerciseRepository.UpdateCurrentWeek(userId, exerciseId, week);

        UserExerciseDto userExerciseDto = _mapper.Map<UserExerciseDto>(userExercise);
        SetDto workoutSet =
            _exerciseCalculator.CalculateByCurrentWeek(userExerciseDto.CurrentWeek, userExerciseDto.OneRepMax);

        return workoutSet;
    }
}