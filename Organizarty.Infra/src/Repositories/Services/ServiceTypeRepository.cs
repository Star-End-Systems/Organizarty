using Microsoft.EntityFrameworkCore;

using Organizarty.Application.App.Services.Data;
using Organizarty.Application.App.Services.Entities;
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

    public async Task<ServiceType?> FindById(Guid id)
    => await _context.ServiceTypes.FindAsync(id);

    public async Task<ServiceType?> FindByIdWithItens(Guid id)
    => await _context.ServiceTypes.Include(x => x.SubServices).Where(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<List<ServiceType>> FindByThirdParty(Guid thirdPartyId)
      => await _context.ServiceTypes
                .Include(x => x.SubServices)
                .Where(x => x.ThirdPartyId == thirdPartyId)
                .Select(x => new ServiceType
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ThirdParty = x.ThirdParty,
                    SubServices = x.SubServices,
                    TagsJSON = x.TagsJSON
                })
                .ToListAsync();

    public async Task<List<ServiceType>> GetAvaibleServices()
      => await _context.ServiceTypes
                .Include(x => x.SubServices)
                .Select(x => new ServiceType
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ThirdParty = x.ThirdParty,
                    SubServices = x.SubServices.Where(y => y.IsAvaible).ToList(),
                    TagsJSON = x.TagsJSON
                })
                .ToListAsync();

}
