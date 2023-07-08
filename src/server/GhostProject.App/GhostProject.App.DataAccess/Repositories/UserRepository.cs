using GhostProject.App.Core.Business.Users.Entities;
using GhostProject.App.Core.Business.Users.Interfaces;
using GhostProject.App.DataAccess.Common;
namespace GhostProject.App.DataAccess.Repositories;

public class UserRepository : BaseRepository<User, int>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
