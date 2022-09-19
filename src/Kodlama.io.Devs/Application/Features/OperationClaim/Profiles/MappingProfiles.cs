using Application.Features.OperationClaim.Commands.CreateOperationClaim;
using Application.Features.OperationClaim.Dtos;
using AutoMapper;

namespace Application.Features.OperationClaim.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Core.Security.Entities.OperationClaim, CreateOperationClaimCommand>().ReverseMap();
        CreateMap<Core.Security.Entities.OperationClaim, CreatedOperationClaimDto>().ReverseMap();
    }
}