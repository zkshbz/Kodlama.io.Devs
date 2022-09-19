using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Hashing;

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

    public async Task ValidationLoginWithEmailAndPassword(string email, string password)
    {
        var user = await _userRepository.GetAsync(w => w.Email.Equals(email));
        if (user == null || !HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException("Check your email or password");
    }
}