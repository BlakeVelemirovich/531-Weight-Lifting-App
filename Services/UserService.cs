using _531WorkoutApi.Domains;
using _531WorkoutApi.DTO;
using _531WorkoutApi.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace _531WorkoutApi.Services;

public class UserService: IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    
    public UserService(
        IMapper mapper,
        IUserRepository userRepository
    )
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    
    public async Task AddAsync(UserRequestDto request)
    {
        request.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);
        User user = _mapper.Map<User>(request);
        Guid newUserGuid = Guid.NewGuid();
        user.UserId = newUserGuid;
        
        await _userRepository.AddAsync(user);
    }

    public async Task<AuthenticationResult> AuthenticateAsync(UserRequestDto request)
    {
        UserDto user = await SearchUserAsync(request.Username);

        if (string.IsNullOrEmpty(user.Username)) return AuthenticationResult.UserNotFound;
        if (BCrypt.Net.BCrypt.Verify(request.PasswordHash, user.PasswordHash)) return AuthenticationResult.Authenticated;
        
        return AuthenticationResult.InvalidPassword;
    }

    public async Task<UserDto> SearchUserAsync(string username)
    {
        User user = await _userRepository.SearchUserAsync(username);
        UserDto userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }
}