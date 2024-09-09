using _531WorkoutApi.DataContext;
using Microsoft.EntityFrameworkCore;

namespace _531WorkoutApi.Repositories;

public class ExerciseRepository: IExerciseRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ExerciseRepository(
        ApplicationDbContext dbContext
    )
    {
        _dbContext = dbContext;
    }
    
    public async Task<int> AddNewWeightMaxAsync(UserExercise userExercise)
    {
        _dbContext.UserExercises.Add(userExercise);
        await _dbContext.SaveChangesAsync();
    
        return 0;
    }

    public async Task<bool> ExerciseExistsAsync(Guid exerciseId)
    {
        return await _dbContext.Exercises.AnyAsync(e => e.ExerciseId == exerciseId);
    }
}