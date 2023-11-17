using Microsoft.EntityFrameworkCore;

using Organizarty.Application.App.Services.Data;
using Organizarty.Application.App.Services.Entities;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.Services;

public class ServiceInfoRepository : IServiceInfoRepository
{
    private readonly ApplicationDbContext _context;

    public ServiceInfoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceInfo> Create(ServiceInfo service)
    {
        var s = await _context.ServiceInfos.AddAsync(service);
        await _context.SaveChangesAsync();

        return s.Entity;
    }

    public async Task<ServiceInfo?> FindByIdWithParent(Guid id)
    => await _context.ServiceInfos.Include(x => x.ServiceType).Where(x => x.Id == id).FirstOrDefaultAsync();
}
