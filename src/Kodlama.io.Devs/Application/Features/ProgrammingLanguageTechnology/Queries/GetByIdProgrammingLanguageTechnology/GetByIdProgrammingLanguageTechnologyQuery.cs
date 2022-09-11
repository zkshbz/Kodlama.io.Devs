using Application.Features.ProgrammingLanguageTechnology.Dtos;
using Application.Features.ProgrammingLanguageTechnology.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.ProgrammingLanguageTechnology.Queries.GetByIdProgrammingLanguageTechnology;

public class GetByIdProgrammingLanguageTechnologyQuery : IRequest<ProgrammingLanguageTechnologyGetByIdDto>
{
    public int Id { get; set; }

    public class GetByIdProgrammingLanguageTechnologyQueryHandler : IRequestHandler<
        GetByIdProgrammingLanguageTechnologyQuery, ProgrammingLanguageTechnologyGetByIdDto>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

        public GetByIdProgrammingLanguageTechnologyQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper, ProgrammingLanguageTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _mapper = mapper;
            _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
        }
        
        public async Task<ProgrammingLanguageTechnologyGetByIdDto> Handle(GetByIdProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
        {
            await _programmingLanguageTechnologyBusinessRules.HasProgrammingLanguageTechnologyWithThisId(request.Id);

            var programmingLanguageTechnologyEntity = await _programmingLanguageTechnologyRepository
                .GetAsync(w => w.Id == request.Id);

            var programmingLanguageTechnologyDto = _mapper.Map<ProgrammingLanguageTechnologyGetByIdDto>(programmingLanguageTechnologyEntity);

            return programmingLanguageTechnologyDto;
        }
    }
}
