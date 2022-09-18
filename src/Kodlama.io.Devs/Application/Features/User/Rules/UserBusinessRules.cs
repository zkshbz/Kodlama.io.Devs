using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.User.Rules;

public class UserBusinessRules
{
    private readonly IUserRepository _userRepository;

    public UserBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task HasAlreadyRegisteredUserWithThisEmail(string email)
    {
        var userEntity = await _userRepository.GetAsync(w => w.Email.Equals(email));

        if (userEntity != null)
        {
            throw new BusinessException($"There is a user with this e-mail: {email}");
        }
    }
}