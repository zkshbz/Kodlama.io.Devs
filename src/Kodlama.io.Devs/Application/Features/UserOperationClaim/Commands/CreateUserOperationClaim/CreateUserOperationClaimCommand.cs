using Application.Features.OperationClaim.Dtos;
using Application.Features.UserOperationClaim.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.UserOperationClaim.Commands.CreateUserOperationClaim;

public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public class
        CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand,
            CreatedUserOperationClaimDto>
    {

        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request,
            CancellationToken cancellationToken)
        {
            var userOperationClaimEntity = _mapper.Map<Core.Security.Entities.UserOperationClaim>(request);

            var createdUserOperationClaimEntity =
                await _userOperationClaimRepository.AddAsync(userOperationClaimEntity);
            var createdUserOperationClaimDto =
                _mapper.Map<CreatedUserOperationClaimDto>(createdUserOperationClaimEntity);

            return createdUserOperationClaimDto;

        }
    }
}