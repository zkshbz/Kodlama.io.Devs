using Application.Features.User.Dtos;
using Application.Features.User.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Queries.UserLoginByJWT;

public class UserLoginByJWTQuery : IRequest<LoginUserDto>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public class UserLoginByJWTQueryHandler : IRequestHandler<UserLoginByJWTQuery, LoginUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;

        public UserLoginByJWTQueryHandler(IUserRepository userRepository, IMapper mapper,
            UserBusinessRules userBusinessRules, ITokenHelper tokenHelper,
            IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
            _tokenHelper = tokenHelper;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<LoginUserDto> Handle(UserLoginByJWTQuery request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.ValidationLoginWithEmailAndPassword(request.Email, request.Password);

            var userEntity = await _userRepository.GetAsync(w => w.Email.Equals(request.Email));
            var userOperationClaimList =
                await _userOperationClaimRepository.GetListAsync(w =>
                        w.UserId == userEntity.Id,
                    include: w => w
                        .Include(i => i.User)
                        .Include(i => i.OperationClaim));

            var operationClaimList = userOperationClaimList.Items.Select(s => s.OperationClaim).ToList();

            var jwtToken = _tokenHelper.CreateToken(userEntity, operationClaimList);

            var userLoginDto = _mapper.Map<LoginUserDto>(userEntity);
            userLoginDto.AccessToken = jwtToken;

            return userLoginDto;
        }
    }
}