using _531WorkoutApi.DataContext;
using _531WorkoutApi.Domains;

namespace _531WorkoutApi.Repositories;

public class UserRepository: IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(User request)
    {
        _context.Users.Add(request);
        await _context.SaveChangesAsync();
    }
}