using Organizarty.Application.App.Locations.Entities;

namespace Organizarty.Application.App.Locations.Data;

public interface ILocationRepository
{
    Task<Location> Create(Location location);

    Task<List<Location>> ListAll();
    Task<List<Location>> ListAll(bool avaible);

    Task<Location?> FindById(string id);
}
