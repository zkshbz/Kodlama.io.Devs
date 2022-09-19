using Core.Security.JWT;

namespace Application.Features.User.Dtos;

public class LoginUserDto
{
    public int UserId { get; set; }
    public AccessToken AccessToken { get; set; }
}