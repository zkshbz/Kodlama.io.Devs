using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class UserInfo : Entity
{
    public int UserId { get; set; }
    public string GitHubLink { get; set; }
    
    public virtual User User { get; set; }

    public UserInfo()
    {
    }

    public UserInfo(string _gitHubLink) : this()
    {
        GitHubLink = _gitHubLink;
    }
}