using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserInfoRepository : EfRepositoryBase<UserInfo, BaseDbContext>, IUserInfoRepository
{
    public UserInfoRepository(BaseDbContext context) : base(context)
    {
    }
}