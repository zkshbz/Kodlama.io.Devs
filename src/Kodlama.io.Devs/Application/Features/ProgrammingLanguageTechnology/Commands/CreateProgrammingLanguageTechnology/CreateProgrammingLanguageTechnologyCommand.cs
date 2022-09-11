using Application.Features.ProgrammingLanguageTechnology.Dtos;
using Application.Features.ProgrammingLanguageTechnology.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProgrammingLanguageTechnology.Commands.CreateProgrammingLanguageTechnology;

public class CreateProgrammingLanguageTechnologyCommand : IRequest<CreatedProgrammingLanguageTechnologyCommandDto>
{
    public string Name { get; set; }
    public int ProgrammingLanguageId { get; set; }

    public class
        CreateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<CreateProgrammingLanguageTechnologyCommand,
            CreatedProgrammingLanguageTechnologyCommandDto>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

        public CreateProgrammingLanguageTechnologyCommandHandler(
            IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, 
            IMapper mapper,
            ProgrammingLanguageTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _mapper = mapper;
            _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
        }

        public async Task<CreatedProgrammingLanguageTechnologyCommandDto> Handle(
            CreateProgrammingLanguageTechnologyCommand request,
            CancellationToken cancellationToken)
        {
            await _programmingLanguageTechnologyBusinessRules.NameAlreadyExistBySpecificProgrammingLanguageId(
                request.ProgrammingLanguageId, request.Name);
            await _programmingLanguageTechnologyBusinessRules.HasProgrammingLanguageWithThisIs(
                request.ProgrammingLanguageId);

            var createdProgrammingLanguageTechnology =
                _mapper.Map<Domain.Entities.ProgrammingLanguageTechnology>(request);
            var result = await _programmingLanguageTechnologyRepository.AddAsync(createdProgrammingLanguageTechnology);
            var createdProgrammingLanguageTechnologyDto =
                _mapper.Map<CreatedProgrammingLanguageTechnologyCommandDto>(createdProgrammingLanguageTechnology);

            return createdProgrammingLanguageTechnologyDto;
        }
    }
}