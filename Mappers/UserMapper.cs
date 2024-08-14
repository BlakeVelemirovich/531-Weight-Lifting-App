using _531WorkoutApi.Domains;
using _531WorkoutApi.DTO;
using AutoMapper;

namespace _531WorkoutApi.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserRequestDto, User>()
            .ForMember(dest => dest.UserId, opt => opt.Ignore());
    }
}