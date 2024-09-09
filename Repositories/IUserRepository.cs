using _531WorkoutApi.Domains;

namespace _531WorkoutApi.Repositories;

public interface IUserRepository
{
    Task AddAsync(User request);

    Task<User> SearchUserAsync(string username);

    Task<bool> UserExistsAsync(Guid userId);
}