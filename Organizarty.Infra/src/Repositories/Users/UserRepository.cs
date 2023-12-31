using Microsoft.EntityFrameworkCore;
using Organizarty.Application.App.Users.Data;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Infra.Data.Contexts;
using Organizarty.Infra.Utils;

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
        user.Id = IdGenerator.DefaultId();

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> FindByEmail(string email)
    => await _context.Users.Where(x => x.Email == email).OrderBy(x => x.UpdatedAt).FirstOrDefaultAsync();

    public async Task<User?> FindByEmailOrUsername(string emailorUsername)
    => await _context.Users.Where(u => u.Email == emailorUsername || u.UserName == emailorUsername).OrderBy(x => x.UpdatedAt).FirstOrDefaultAsync();

    public async Task<User?> FindById(string id)
        => await _context.Users.FindAsync(id);

    public async Task<User> Update(User user)
    {
        var u = _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return u.Entity;
    }
}
