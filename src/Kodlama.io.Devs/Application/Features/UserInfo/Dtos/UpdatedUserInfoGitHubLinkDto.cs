namespace Application.Features.UserInfo.Dtos;

public class UpdatedUserInfoGitHubLinkDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string GitHubLink { get; set; }
}