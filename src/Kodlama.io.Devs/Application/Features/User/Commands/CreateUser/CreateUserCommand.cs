using Application.Features.User.Dtos;
using Application.Features.User.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Enums;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.User.Commands.CreateUser;

public class CreateUserCommand : IRequest<CreatedUserDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<CreatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.HasAlreadyRegisteredUserWithThisEmail(request.Email);

            var userEntity = _mapper.Map<Core.Security.Entities.User>(request);

            HashingHelper.CreatePasswordHash(request.Password,  out var passwordHash,out var passwordSalt);
            userEntity.PasswordHash = passwordHash;
            userEntity.PasswordSalt = passwordSalt;
            userEntity.Status = true;
            userEntity.AuthenticatorType = AuthenticatorType.Email;
            
            var createdUser = await _userRepository.AddAsync(userEntity);
            var createdUserDto = _mapper.Map<CreatedUserDto>(createdUser);

            return createdUserDto;
        }
    }
}