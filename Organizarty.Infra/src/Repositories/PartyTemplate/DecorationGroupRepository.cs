using Microsoft.EntityFrameworkCore;

using Organizarty.Application.App.Party.Data;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Infra.Data.Contexts;
using Organizarty.Infra.Utils;

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
        decoration.Id = IdGenerator.DefaultId();
        await _context.DecorationGroups.AddAsync(decoration);
        await _context.SaveChangesAsync();
        return decoration;
    }

    public async Task Delete(string id)
    {
        var item = await FindById(id);

        if (item is null)
        {
            return;
        }

        _context.DecorationGroups.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task<DecorationGroup?> FindById(string id)
      => await _context.DecorationGroups.FindAsync(id);

    public async Task<List<DecorationGroup>> ListFromParty(string partyId)
      => await _context.DecorationGroups.Where(x => x.PartyTemplateId == partyId).Include(x => x.DecorationInfo).Include(x => x.DecorationInfo!.DecorationType).ToListAsync();

    public async Task<DecorationGroup> Update(DecorationGroup decoration)
    {
        var d = _context.DecorationGroups.Update(decoration);

        await _context.SaveChangesAsync();

        return d.Entity;
    }
}
