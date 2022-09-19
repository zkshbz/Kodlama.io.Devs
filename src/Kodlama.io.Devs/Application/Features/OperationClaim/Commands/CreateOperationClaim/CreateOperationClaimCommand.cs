using Application.Features.OperationClaim.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.OperationClaim.Commands.CreateOperationClaim;

public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>
{
    public string Name { get; set; }

    public class
        CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
    {

        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }
        
        
        public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request,
            CancellationToken cancellationToken)
        {
            var operationClaimEntity = _mapper.Map<Core.Security.Entities.OperationClaim>(request);

            var createdOperationClaimEntity = await _operationClaimRepository.AddAsync(operationClaimEntity);
            var createdOperationClaimDto = _mapper.Map<CreatedOperationClaimDto>(createdOperationClaimEntity);

            return createdOperationClaimDto;
        }
    }
}