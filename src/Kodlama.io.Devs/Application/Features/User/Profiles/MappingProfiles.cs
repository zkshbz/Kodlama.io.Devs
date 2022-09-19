using Application.Features.User.Commands.CreateUser;
using Application.Features.User.Dtos;
using Application.Features.User.Queries.UserLoginByJWT;
using AutoMapper;

namespace Application.Features.User.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Core.Security.Entities.User, CreateUserCommand>().ReverseMap();
        CreateMap<Core.Security.Entities.User, CreatedUserDto>().ReverseMap();
        CreateMap<Core.Security.Entities.User, UserLoginByJWTQuery>().ReverseMap();
        CreateMap<Core.Security.Entities.User, LoginUserDto>()
            .ForMember(c => c.UserId, opts => opts.MapFrom(m => m.Id))
            .ReverseMap();
    }
}