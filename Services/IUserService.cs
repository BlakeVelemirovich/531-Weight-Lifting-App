using _531WorkoutApi.DTO;

namespace _531WorkoutApi.Services;

public interface IUserService
{
    Task AddAsync(UserRequestDto request);
}