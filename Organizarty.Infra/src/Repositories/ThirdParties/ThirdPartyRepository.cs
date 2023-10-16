using Microsoft.EntityFrameworkCore;
using Organizarty.Application.App.ThirdParties.Data;
using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.ThirdParties;

public class ThirdPartyRepository : IThirdPartyRepository
{
    private readonly ApplicationDbContext _context;

    public ThirdPartyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ThirdParty> Create(ThirdParty thirdParty)
    {
        await _context.ThirdParties.AddAsync(thirdParty);
        await _context.SaveChangesAsync();
        return thirdParty;
    }

    public async Task<ThirdParty?> FindByEmail(string email)
      => await _context.ThirdParties.FirstOrDefaultAsync(user => user.LoginEmail == email);

    public async Task<ThirdParty?> FindById(Guid id)
     => await _context.ThirdParties.FindAsync(id);

    public async Task<ThirdParty> Update(ThirdParty thirdParty)
    {
        _context.ThirdParties.Update(thirdParty);
        await _context.SaveChangesAsync();
        return thirdParty;
    }
}
