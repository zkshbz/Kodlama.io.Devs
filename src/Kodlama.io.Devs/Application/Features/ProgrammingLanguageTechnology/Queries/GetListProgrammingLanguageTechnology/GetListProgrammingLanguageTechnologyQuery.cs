using Application.Features.ProgrammingLanguageTechnology.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProgrammingLanguageTechnology.Queries.GetListProgrammingLanguageTechnology;

public class GetListProgrammingLanguageTechnologyQuery : IRequest<ProgrammingLanguageTechnologyListModel>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetListProgrammingLanguageTechnologyQueryHandler : IRequestHandler<
        GetListProgrammingLanguageTechnologyQuery, ProgrammingLanguageTechnologyListModel>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingLanguageTechnologyQueryHandler(
            IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageTechnologyListModel> Handle(
            GetListProgrammingLanguageTechnologyQuery request,
            CancellationToken cancellationToken)
        {
            var programmingLanguageTechnologies = await _programmingLanguageTechnologyRepository
                .GetListByDynamicAsync(
                    dynamic: request.Dynamic,
                    include: m => m.Include(c => c.ProgrammingLanguage),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

            var mappedProgrammingLanguageTechnologies =
                _mapper.Map<ProgrammingLanguageTechnologyListModel>(programmingLanguageTechnologies);

            return mappedProgrammingLanguageTechnologies;
        }
    }
}