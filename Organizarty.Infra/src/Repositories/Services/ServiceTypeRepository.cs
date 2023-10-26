using Organizarty.Application.App.Services.Data;
using Organizarty.Application.App.ServiceTypes.Entities;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.Services;

public class ServiceTypeRepository : IServiceTypeRepository
{
    private readonly ApplicationDbContext _context;

    public ServiceTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceType> Create(ServiceType service)
    {
        var s = await _context.ServiceTypes.AddAsync(service);
        await _context.SaveChangesAsync();

        return s.Entity;
    }
}
