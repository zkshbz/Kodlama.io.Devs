using Application.Features.UserInfo.Dtos;
using Application.Features.UserInfo.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.UserInfo.Commands.DeleteUserInfoGitHubLink;

public class DeleteUserInfoGitHubLinkCommand : IRequest<DeletedUserInfoGitHubLinkDto>
{
    public int UserId { get; set; }

    public class
        DeleteUserInfoGitHubLinkCommandHandler : IRequestHandler<DeleteUserInfoGitHubLinkCommand,
            DeletedUserInfoGitHubLinkDto>
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;
        private readonly UserInfoBusinessRules _userInfoBusinessRules;

        public DeleteUserInfoGitHubLinkCommandHandler(IUserInfoRepository userInfoRepository, IMapper mapper, UserInfoBusinessRules userInfoBusinessRules)
        {
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
            _userInfoBusinessRules = userInfoBusinessRules;
        }
        
        public async Task<DeletedUserInfoGitHubLinkDto> Handle(DeleteUserInfoGitHubLinkCommand request, CancellationToken cancellationToken)
        {
            await _userInfoBusinessRules.HasUserById(request.UserId);
            await _userInfoBusinessRules.HasNotUserGitHubInfoByUserId(request.UserId);

            var userInfoEntity = await _userInfoRepository.GetAsync(w => w.UserId == request.UserId);
            var deletedUserEntity = await _userInfoRepository.DeleteAsync(userInfoEntity);
            var deletedUserEntityDto = _mapper.Map<DeletedUserInfoGitHubLinkDto>(deletedUserEntity);

            return deletedUserEntityDto;
        }
    }
}