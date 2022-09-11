using Application.Features.ProgrammingLanguage.Rules;
using Application.Features.ProgrammingLanguageTechnology.Dtos;
using Application.Features.ProgrammingLanguageTechnology.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProgrammingLanguageTechnology.Commands.DeleteProgrammingLanguageTechnology;

public class DeleteProgrammingLanguageTechnologyCommand : IRequest<DeletedProgrammingLanguageTechnologyDto>
{
    public int Id { get; set; }

    public class DeleteProgrammingLanguageTechnologyCommandHandler : IRequestHandler<
        DeleteProgrammingLanguageTechnologyCommand, DeletedProgrammingLanguageTechnologyDto>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

        public DeleteProgrammingLanguageTechnologyCommandHandler(
            IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper,
            ProgrammingLanguageTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _mapper = mapper;
            _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
        }

        public async Task<DeletedProgrammingLanguageTechnologyDto> Handle(
            DeleteProgrammingLanguageTechnologyCommand request,
            CancellationToken cancellationToken)
        {
            await _programmingLanguageTechnologyBusinessRules.HasProgrammingLanguageTechnologyWithThisId(request.Id);

            var programmingLanguageTechnologyEntity = await _programmingLanguageTechnologyRepository.GetAsync(w =>
                w.Id == request.Id);
            var deletedProgrammingLanguageTechnology = await _programmingLanguageTechnologyRepository.DeleteAsync(programmingLanguageTechnologyEntity);
            var deletedProgrammingLanguageTechnologyDto =
                _mapper.Map<DeletedProgrammingLanguageTechnologyDto>(deletedProgrammingLanguageTechnology);

            return deletedProgrammingLanguageTechnologyDto;
        }
    }
}