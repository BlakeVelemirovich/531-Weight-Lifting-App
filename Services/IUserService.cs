using _531WorkoutApi.DTO;
using Microsoft.Identity.Client;

namespace _531WorkoutApi.Services;

public interface IUserService
{
    Task AddAsync(UserRequestDto request);

    Task<AuthenticationResult> AuthenticateAsync(UserRequestDto request);

    Task<UserDto> SearchUserAsync(string username);
}