using Microsoft.EntityFrameworkCore;
using Organizarty.Application.App.Party.Data;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.PartyTemplate;

public class PartyTemplateRepository : IPartyTemplateRepository
{
    private readonly ApplicationDbContext _context;

    public PartyTemplateRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Application.App.Party.Entities.PartyTemplate> Create(Application.App.Party.Entities.PartyTemplate party)
    {
        var a = await _context.PartyTemplates.AddAsync(party);
        await _context.SaveChangesAsync();

        return a.Entity;
    }

    public async Task<Application.App.Party.Entities.PartyTemplate?> FindById(string partyId)
    => await _context.PartyTemplates.FindAsync(partyId);

    public async Task<Application.App.Party.Entities.PartyTemplate?> FromIdWithLocation(string partyId)
    => await _context.PartyTemplates
              .Include(x => x.Location)
              .Where(x => x.Id == partyId)
              .FirstOrDefaultAsync();

    public async Task<List<Application.App.Party.Entities.PartyTemplate>> FromUser(string userId)
      => await _context.PartyTemplates
                .Where(x => x.UserId == userId)
                .Select(x => new Application.App.Party.Entities.PartyTemplate
                {
                    Id = x.Id,
                    Name = x.Name,
                    ExpectedGuests = x.ExpectedGuests,
                    User = x.User,
                    Location = x.Location,
                    Type = x.Type,
                    OriginalPartyTemplate = x.OriginalPartyTemplate
                })
                .ToListAsync();

    public async Task<Application.App.Party.Entities.PartyTemplate> Update(Application.App.Party.Entities.PartyTemplate party)
    {
        var p = _context.PartyTemplates.Update(party);
        await _context.SaveChangesAsync();

        return p.Entity;
    }
}
