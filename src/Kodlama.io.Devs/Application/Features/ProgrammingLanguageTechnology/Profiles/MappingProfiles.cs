using Application.Features.ProgrammingLanguage.Models;
using Application.Features.ProgrammingLanguageTechnology.Commands.CreateProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnology.Dtos;
using Application.Features.ProgrammingLanguageTechnology.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.ProgrammingLanguageTechnology.Profiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Domain.Entities.ProgrammingLanguageTechnology, CreatedProgrammingLanguageTechnologyCommandDto>()
            .ReverseMap();
        CreateMap<Domain.Entities.ProgrammingLanguageTechnology, CreateProgrammingLanguageTechnologyCommand>()
            .ReverseMap();
        CreateMap<Domain.Entities.ProgrammingLanguageTechnology, DeletedProgrammingLanguageTechnologyDto>()
            .ReverseMap();
        CreateMap<Domain.Entities.ProgrammingLanguageTechnology, UpdatedProgrammingLanguageTechnologyDto>()
            .ReverseMap();
        CreateMap<Domain.Entities.ProgrammingLanguageTechnology, ProgrammingLanguageTechnologyGetByIdDto>()
            .ForMember(c => c.ProgrammingLanguageName,
                opts => opts.MapFrom(o => o.ProgrammingLanguage.Name))
            .ReverseMap();
        CreateMap<Domain.Entities.ProgrammingLanguageTechnology, ProgrammmingLanguageTechnologyListDto>()
            .ForMember(c => c.ProgrammingLanguageName,
                opts => opts.MapFrom(o => o.ProgrammingLanguage.Name))
            .ReverseMap();
        CreateMap<IPaginate<Domain.Entities.ProgrammingLanguageTechnology>, ProgrammingLanguageTechnologyListModel>()
            .ReverseMap();
    }
}