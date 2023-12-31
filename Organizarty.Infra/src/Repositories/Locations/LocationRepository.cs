using Microsoft.EntityFrameworkCore;
using Organizarty.Application.App.Locations.Data;
using Organizarty.Application.App.Locations.Entities;
using Organizarty.Infra.Data.Contexts;
using Organizarty.Infra.Utils;

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
        location.Id = IdGenerator.DefaultId();
        var d = await _context.Locations.AddAsync(location);
        await _context.SaveChangesAsync();

        return d.Entity;
    }

    public async Task<Location?> FindById(string id)
      => await _context.Locations.FindAsync(id);

    public async Task<List<Location>> ListAll()
      => await _context.Locations.ToListAsync();

    // TOOD: Add   Avaible field
    public async Task<List<Location>> ListAll(bool avaible)
      => await _context.Locations.Where(x => x.RentPerDay > 0).ToListAsync();
}
