using _531WorkoutApi.DTO;
using AutoMapper;

namespace _531WorkoutApi.Mappers;

public class UserExerciseMapper : Profile
{
    public UserExerciseMapper()
    {
        CreateMap<UserExercise, UserExerciseDto>();
    }
}