using Application.Features.UserInfo.Dtos;
using Application.Features.UserInfo.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.UserInfo.Commands.CreateUserInfoGitHubLink;

public class CreateUserInfoGitHubLinkCommand : IRequest<CreatedUserInfoGitHubLinkDto>
{
    public int UserId { get; set; }
    public string GitHubLink { get; set; }

    public class
        CreateUserInfoGitHubLinkCommandHandler : IRequestHandler<CreateUserInfoGitHubLinkCommand,
            CreatedUserInfoGitHubLinkDto>
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;
        private readonly UserInfoBusinessRules _userInfoBusinessRules;

        public CreateUserInfoGitHubLinkCommandHandler(IUserInfoRepository userInfoRepository, IMapper mapper,
            UserInfoBusinessRules userInfoBusinessRules)
        {
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
            _userInfoBusinessRules = userInfoBusinessRules;
        }

        public async Task<CreatedUserInfoGitHubLinkDto> Handle(CreateUserInfoGitHubLinkCommand request,
            CancellationToken cancellationToken)
        {
            await _userInfoBusinessRules.HasUserById(request.UserId);
            await _userInfoBusinessRules.HasUserGithubInfoByUserId(request.UserId);

            var userInfoEntity = _mapper.Map<Domain.Entities.UserInfo>(request);
            var createdUserInfoEntity = await _userInfoRepository.AddAsync(userInfoEntity);
            var createdUserInfoDto = _mapper.Map<CreatedUserInfoGitHubLinkDto>(createdUserInfoEntity);

            return createdUserInfoDto;
        }
    }
}