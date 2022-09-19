using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.UserInfo.Rules;

public class UserInfoBusinessRules
{
    private readonly IUserInfoRepository _userInfoRepository;
    private readonly IUserRepository _userRepository;

    public UserInfoBusinessRules(IUserInfoRepository userInfoRepository, IUserRepository userRepository)
    {
        _userInfoRepository = userInfoRepository;
        _userRepository = userRepository;
    }

    public async Task HasUserById(int userId)
    {
        var user = await _userRepository.GetAsync(w => w.Id == userId);

        if (user == null)
            throw new BusinessException($"User cannot by found by id {userId}");
    }

    public async Task HasUserGithubInfoByUserId(int userId)
    {
        var userWithGitHubLink = await _userInfoRepository.GetAsync(w => w.UserId == userId);

        if (userWithGitHubLink != null)
            throw new BusinessException("User has already GitHubLink please use update api");
    }

    public async Task HasNotUserGitHubInfoByUserId(int userId)
    {
        var userWithGitHubLink = await _userInfoRepository.GetAsync(w => w.UserId == userId);

        if (userWithGitHubLink == null)
            throw new BusinessException("User has not GitHubLink please use create api");
    }
}