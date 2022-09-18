using Application.Features.User.Commands.CreateUser;
using Application.Features.User.Dtos;
using AutoMapper;

namespace Application.Features.User.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Core.Security.Entities.User, CreateUserCommand>().ReverseMap();
        CreateMap<Core.Security.Entities.User, CreatedUserDto>().ReverseMap();
    }
}