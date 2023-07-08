using GhostProject.App.Core.Business.Users.Entities;
using GhostProject.App.Core.Common.Abstractions.DataAccess;

namespace GhostProject.App.Core.Business.Users.Interfaces;

public interface IUserRepository : IRepository<User, int>
{
}
