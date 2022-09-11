using Application.Features.ProgrammingLanguage.Rules;
using Application.Features.ProgrammingLanguageTechnology.Dtos;
using Application.Features.ProgrammingLanguageTechnology.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProgrammingLanguageTechnology.Commands.UpdateProgrammingLanguguageTechnology;

public class UpdateProgrammingLanguageTechnologyCommand : IRequest<UpdatedProgrammingLanguageTechnologyDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProgrammingLanguageId { get; set; }

    public class UpdateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<
        UpdateProgrammingLanguageTechnologyCommand, UpdatedProgrammingLanguageTechnologyDto>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

        public UpdateProgrammingLanguageTechnologyCommandHandler(
            IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper,
            ProgrammingLanguageTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _mapper = mapper;
            _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
        }

        public async Task<UpdatedProgrammingLanguageTechnologyDto> Handle(
            UpdateProgrammingLanguageTechnologyCommand request,
            CancellationToken cancellationToken)
        {
            await _programmingLanguageTechnologyBusinessRules.HasProgrammingLanguageTechnologyWithThisId(request.Id);
            await _programmingLanguageTechnologyBusinessRules.HasProgrammingLanguageWithThisIs(
                request.ProgrammingLanguageId);
            await _programmingLanguageTechnologyBusinessRules.NameAlreadyExistBySpecificProgrammingLanguageId(
                request.ProgrammingLanguageId, request.Name);

            var programmingLanguageTechnologyEntity =
                await _programmingLanguageTechnologyRepository.GetAsync(w => w.Id == request.Id);

            programmingLanguageTechnologyEntity.Name = request.Name;
            programmingLanguageTechnologyEntity.ProgrammingLanguageId = request.ProgrammingLanguageId;

            var updatedProgrammingLanguageTechnologyEntity =
                await _programmingLanguageTechnologyRepository.UpdateAsync(programmingLanguageTechnologyEntity);

            var updatedProgrammingLanguageTechnologyDto =
                _mapper.Map<UpdatedProgrammingLanguageTechnologyDto>(updatedProgrammingLanguageTechnologyEntity);

            return updatedProgrammingLanguageTechnologyDto;
        }
    }
}