using _531WorkoutApi.DataContext;
using _531WorkoutApi.Domains;
using Microsoft.EntityFrameworkCore;

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

    public async Task<bool> UserExistsAsync(Guid userId)
    {
        return await _context.Users.AnyAsync(u => u.UserId == userId);
    }

    public async Task<User> SearchUserAsync(string username)
    {
        User user = _context.Users
            .Single(user => user.Username == username);

        if (user != null || user.UserId != Guid.Empty) return user;
        return new User();
    }
}