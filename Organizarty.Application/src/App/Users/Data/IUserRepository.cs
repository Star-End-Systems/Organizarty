using Organizarty.Application.App.Users.Entities;

namespace Organizarty.Application.App.Users.Data;

public interface IUserRepository
{
    Task<User> Create(User user);
    Task<User> Update(User user);

    Task<User?> FindByEmail(string email);
    Task<User?> FindByEmailOrUsername(string emailorUsername);
    Task<User?> FindById(string id);
}
