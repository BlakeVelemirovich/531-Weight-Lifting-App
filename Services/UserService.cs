using _531WorkoutApi.Domains;
using _531WorkoutApi.DTO;
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
        User user = _mapper.Map<User>(request);
        
        Guid newUserGuid = Guid.NewGuid();
        user.UserId = newUserGuid;
        
        _userRepository.AddAsync(user);
    }
}