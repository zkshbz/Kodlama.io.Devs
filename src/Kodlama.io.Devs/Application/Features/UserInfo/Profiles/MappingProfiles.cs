using Application.Features.UserInfo.Commands.CreateUserInfoGitHubLink;
using Application.Features.UserInfo.Commands.UpdateUserInfoGitHubLink;
using Application.Features.UserInfo.Dtos;
using AutoMapper;

namespace Application.Features.UserInfo.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.UserInfo, CreateUserInfoGitHubLinkCommand>().ReverseMap();
        CreateMap<Domain.Entities.UserInfo, CreatedUserInfoGitHubLinkDto>().ReverseMap();
        CreateMap<Domain.Entities.UserInfo, UpdateUserInfoGitHubLinkCommand>().ReverseMap();
        CreateMap<Domain.Entities.UserInfo, UpdatedUserInfoGitHubLinkDto>().ReverseMap();
        CreateMap<Domain.Entities.UserInfo, DeletedUserInfoGitHubLinkDto>().ReverseMap();
    }
}