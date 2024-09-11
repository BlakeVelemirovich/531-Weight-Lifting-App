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

    public async Task<UserExercise> GetUserExercise(Guid userId, Guid exerciseId)
    {
        return await _dbContext.UserExercises.SingleOrDefaultAsync(ue =>
            ue.UserId == userId && ue.ExerciseId == exerciseId);
    }

    public async Task<UserExercise> UpdateCurrentWeek(Guid userId, Guid exerciseId, int week)
    {
        var userExercise = await _dbContext.UserExercises
            .FirstOrDefaultAsync(ue => ue.UserId == userId && ue.ExerciseId == exerciseId);

        if (userExercise == null)
        {
            throw new Exception("UserExercise not found.");
        }

        userExercise.CurrentWeek = week;
        _dbContext.UserExercises.Update(userExercise);
        await _dbContext.SaveChangesAsync();

        return userExercise;
    }
 }