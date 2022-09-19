using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IUserInfoRepository : IAsyncRepository<UserInfo>, IRepository<UserInfo>
{
    
}