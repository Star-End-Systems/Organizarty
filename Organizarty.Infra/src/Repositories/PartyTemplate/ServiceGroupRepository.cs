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

    public async Task Delete(Guid id)
    {
        var item = await FindById(id);

        if (item is null)
        {
            return;
        }

        _context.ServiceGroups.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task<ServiceGroup?> FindById(Guid id)
      => await _context.ServiceGroups.FindAsync(id);

    public async Task<List<ServiceGroup>> ListFromParty(Guid partyId)
      => await _context.ServiceGroups.Where(x => x.PartyTemplateId == partyId).Include(x => x.ServiceInfo).Include(x => x.ServiceInfo!.ServiceType).ToListAsync();

    public async Task<ServiceGroup> Update(ServiceGroup group)
    {
        var s = _context.ServiceGroups.Update(group);
        await _context.SaveChangesAsync();

        return s.Entity;
    }
}
