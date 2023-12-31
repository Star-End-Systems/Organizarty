using Microsoft.EntityFrameworkCore;
using Organizarty.Application.App.Users.Data;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Infra.Data.Contexts;
using Organizarty.Infra.Utils;

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
        user.Id = IdGenerator.DefaultId();

        _context.UserConfirmations.Add(user);

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<UserConfirmation?> FindByCode(string code, string email)
    => await _context.UserConfirmations
                     .AsNoTrackingWithIdentityResolution()
                     .Where(x => x.Code == code)
                     .Where(x => x.UserEmail == email)
                     .FirstOrDefaultAsync();

    public async Task<UserConfirmation?> FindById(string code)
    => await _context.UserConfirmations
                     .AsNoTrackingWithIdentityResolution()
                     .Where(x => x.Id == code)
                     .Select(x => new UserConfirmation
                     {
                         Id = x.Id,
                         ValidFor = x.ValidFor,
                         UserEmail = x.UserEmail,
                         Code = x.Code
                     })
                     .FirstOrDefaultAsync();

    public async Task<List<UserConfirmation>> FindByUserEmail(string userEmail)
      => await _context.UserConfirmations
                       .AsNoTrackingWithIdentityResolution()
                       .Where(confirm => confirm.UserEmail == userEmail)
                       .ToListAsync();

    public async Task RemoveAllFromUser(string userEmail)
    {
        var emailCodes = await FindByUserEmail(userEmail);
        _context.UserConfirmations.RemoveRange(emailCodes);
        await _context.SaveChangesAsync();
    }
}
