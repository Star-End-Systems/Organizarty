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

    public async Task<ServiceInfo?> FindById(Guid id)
    => await _context.ServiceInfos.FindAsync(id);

    public async Task<ServiceInfo?> FindByIdWithParent(Guid id)
    => await _context.ServiceInfos
            .Include(x => x.ServiceType)
            .Where(x => x.Id == id)
            .Select(x => new ServiceInfo
            {
                Id = x.Id,
                Price = x.Price,
                IsAvaible = x.IsAvaible,
                Plan = x.Plan,
                ImagesJson = x.ImagesJson,
                ServiceType = x.ServiceType,
            })
            .FirstOrDefaultAsync();

    public async Task<ServiceInfo> Update(ServiceInfo service)
    {
        var s = _context.ServiceInfos.Update(service);
        await _context.SaveChangesAsync();

        return s.Entity;
    }
}
