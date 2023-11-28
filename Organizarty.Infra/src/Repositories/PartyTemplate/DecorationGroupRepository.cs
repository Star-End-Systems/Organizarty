using Microsoft.EntityFrameworkCore;

using Organizarty.Application.App.Party.Data;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.PartyTemplate;


public class DecorationGroupRepository : IDecorationGroupRepository
{
    private readonly ApplicationDbContext _context;

    public DecorationGroupRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DecorationGroup> Add(DecorationGroup decoration)
    {
        await _context.DecorationGroups.AddAsync(decoration);
        await _context.SaveChangesAsync();
        return decoration;
    }

    public async Task<List<DecorationGroup>> ListFromParty(Guid partyId)
      => await _context.DecorationGroups.Where(x => x.PartyTemplateId == partyId).Include(x => x.DecorationInfo).Include(x => x.DecorationInfo!.DecorationType).ToListAsync();
}
