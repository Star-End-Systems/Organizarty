using Organizarty.Application.App.Users.Data;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> Create(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public Task<User?> FindByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<User> Update(User user)
    {
        var u = _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return u.Entity;
    }
}
