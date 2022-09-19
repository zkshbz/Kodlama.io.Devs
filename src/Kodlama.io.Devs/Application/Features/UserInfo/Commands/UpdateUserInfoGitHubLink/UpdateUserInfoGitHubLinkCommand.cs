using Application.Features.UserInfo.Dtos;
using Application.Features.UserInfo.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.UserInfo.Commands.UpdateUserInfoGitHubLink;

public class UpdateUserInfoGitHubLinkCommand : IRequest<UpdatedUserInfoGitHubLinkDto>
{
    public int UserId { get; set; }
    public string GitHubLink { get; set; }

    public class
        UpdateUserInfoGitHubLinkCommandHandler : IRequestHandler<UpdateUserInfoGitHubLinkCommand,
            UpdatedUserInfoGitHubLinkDto>
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;
        private readonly UserInfoBusinessRules _userInfoBusinessRules;

        public UpdateUserInfoGitHubLinkCommandHandler(IUserInfoRepository userInfoRepository, IMapper mapper, UserInfoBusinessRules userInfoBusinessRules)
        {
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
            _userInfoBusinessRules = userInfoBusinessRules;
        }
        
        public async Task<UpdatedUserInfoGitHubLinkDto> Handle(UpdateUserInfoGitHubLinkCommand request, CancellationToken cancellationToken)
        {
            await _userInfoBusinessRules.HasUserById(request.UserId);
            await _userInfoBusinessRules.HasNotUserGitHubInfoByUserId(request.UserId);

            var userInfoEntity = await _userInfoRepository.GetAsync(w => w.UserId == request.UserId);
            userInfoEntity.GitHubLink = request.GitHubLink;

            var updatedUserInfoEntity = await _userInfoRepository.UpdateAsync(userInfoEntity);
            var updatedUserInfoDto = _mapper.Map<UpdatedUserInfoGitHubLinkDto>(updatedUserInfoEntity);

            return updatedUserInfoDto;
        }
    }
}