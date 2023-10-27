using Organizarty.Application.App.Locations.Entities;

namespace Organizarty.Application.App.Locations.Data;

public interface ILocationRepository
{
    Task<Location> Create(Location location);
}
