using _531WorkoutApi.DataContext;

namespace _531WorkoutApi.Repositories;

public class ExerciseRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ExerciseRepository(
        ApplicationDbContext dbContext
    )
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddNewWeightMax(UserExercise userExercise)
    {
        _dbContext.UserExercises.Add(userExercise);
        await _dbContext.SaveChangesAsync();
    
        return 0;
    }
}