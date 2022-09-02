using Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Dtos;
using Application.Features.ProgrammingLanguage.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;


namespace Application.Features.ProgrammingLanguage.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
        CreateMap<Domain.Entities.ProgrammingLanguage, CreateProgrammingLanguageDto>().ReverseMap();
        CreateMap<IPaginate<Domain.Entities.ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
        CreateMap<Domain.Entities.ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();

    }
}