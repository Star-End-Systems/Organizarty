using Microsoft.EntityFrameworkCore;
using Organizarty.Application.App.Users.Data;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.Users;

public class UserConfirmationRepository : IUserConfirmationRepository
{
    private readonly ApplicationDbContext _context;

    public UserConfirmationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserConfirmation> Create(UserConfirmation user)
    {
        await _context.UserConfirmations.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<UserConfirmation?> FindById(Guid code)
    => await _context.UserConfirmations.FindAsync(code);

    public async Task<List<UserConfirmation>> FindByUserId(Guid userId)
      => await _context.UserConfirmations.Where(emails => emails.User.Id == userId).ToListAsync();

    public async Task RemoveAllFromUser(Guid userId)
    {
        var emailCodes = await FindByUserId(userId);
        _context.UserConfirmations.RemoveRange(emailCodes);
        await _context.SaveChangesAsync();
    }
}
