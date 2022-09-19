using Application.Features.UserOperationClaim.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaim.Dtos;
using AutoMapper;

namespace Application.Features.UserOperationClaim.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Core.Security.Entities.UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
        CreateMap<Core.Security.Entities.UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();
    }
}