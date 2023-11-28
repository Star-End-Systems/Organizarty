using Microsoft.EntityFrameworkCore;
using Organizarty.Application.App.Party.Data;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.PartyTemplate;

public class ServiceGroupRepository : IServiceGroupRepository
{
    private readonly ApplicationDbContext _context;

    public ServiceGroupRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceGroup> Add(ServiceGroup service)
    {
        await _context.ServiceGroups.AddAsync(service);
        await _context.SaveChangesAsync();
        return service;
    }


    public async Task<List<ServiceGroup>> ListFromParty(Guid partyId)
      => await _context.ServiceGroups.Where(x => x.PartyTemplateId == partyId).Include(x => x.ServiceInfo).Include(x => x.ServiceInfo!.ServiceType).ToListAsync();
      // => await _context.ServiceGroups.Where(x => x.PartyTemplateId == partyId).ToListAsync();
}
