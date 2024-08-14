using _531WorkoutApi.Domains;
using Microsoft.EntityFrameworkCore;

namespace _531WorkoutApi.DataContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<UserExercise> UserExercises { get; set; }
    public DbSet<PassFailHistory> PassFailHistories { get; set; }
}