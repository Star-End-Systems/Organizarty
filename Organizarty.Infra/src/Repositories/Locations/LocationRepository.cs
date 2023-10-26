using Organizarty.Application.App.Locations.Data;
using Organizarty.Application.App.Locations.Entities;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.Locations;

public class LocationRepository : ILocationRepository
{
    private readonly ApplicationDbContext _context;

    public LocationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Location> Create(Location location)
    {
        var d = await _context.Locations.AddAsync(location);
        await _context.SaveChangesAsync();

        return d.Entity;
    }
}
