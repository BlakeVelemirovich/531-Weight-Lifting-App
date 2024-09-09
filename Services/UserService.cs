using System.Text.RegularExpressions;
using _531WorkoutApi.Domains;
using _531WorkoutApi.DTO;
using _531WorkoutApi.Exceptions;
using _531WorkoutApi.Repositories;
using AutoMapper;

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
        await IsUserValid(request.Username, request.PasswordHash);
        
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

    private async Task IsUserValid(string username, string password)
    {
        var isDuplicateUser = await _userRepository.CheckUsernameDuplicateAsync(username);
        
        if (isDuplicateUser)
        {
            throw new DuplicateUsername();
        }

        // At least 8 characters, one uppercase letter, one number
        var passwordPattern = new Regex(@"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$");
        if (!passwordPattern.IsMatch(password))
        {
            throw new PasswordMinimumReq();
        }
    }
}