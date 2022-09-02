using Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Dtos;
using AutoMapper;
using Domain.Entities;


namespace Application.Features.ProgrammingLanguage.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
        CreateMap<Domain.Entities.ProgrammingLanguage, CreateProgrammingLanguageDto>().ReverseMap();
    }
}