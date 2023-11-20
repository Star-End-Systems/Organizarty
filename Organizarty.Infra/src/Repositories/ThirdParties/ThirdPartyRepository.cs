using Microsoft.EntityFrameworkCore;
using Organizarty.Application.App.ThirdParties.Data;
using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Application.App.Utils.Enums;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.ThirdParties;

public class ThirdPartyRepository : IThirdPartyRepository
{
    private readonly ApplicationDbContext _context;

    public ThirdPartyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ThirdParty>> AllWithAuthorization(AuthorizationStatus status)
      => await _context.ThirdParties.Where(x => x.AuthorizationStatus == status).ToListAsync();

    public async Task<ThirdParty> Create(ThirdParty thirdParty)
    {
        await _context.ThirdParties.AddAsync(thirdParty);
        await _context.SaveChangesAsync();
        return thirdParty;
    }

    public async Task<ThirdParty?> FindByEmail(string email)
      => await _context.ThirdParties.OrderBy(x => x.UpdatedAt).FirstOrDefaultAsync(user => user.LoginEmail == email);

    public async Task<ThirdParty?> FindById(Guid id)
     => await _context.ThirdParties.OrderBy(x => x.UpdatedAt).FirstOrDefaultAsync(x => x.Id == id);

    public async Task<ThirdParty> Update(ThirdParty thirdParty)
    {
        thirdParty.UpdatedAt = DateTime.Now;
        var u = _context.ThirdParties.Update(thirdParty);
        await _context.SaveChangesAsync();
        return u.Entity;
    }
}
