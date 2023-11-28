using Organizarty.Application.App.Locations.Data;
using Organizarty.Application.App.Locations.Entities;

namespace Organizarty.Application.App.Locations.UseCases;

public class SelectLocationUseCase
{
    private readonly ILocationRepository _locationRepository;

    public SelectLocationUseCase(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<Location?> FindById(Guid id)
      => await _locationRepository.FindById(id);

    public async Task<List<Location>> ListAll()
      => await _locationRepository.ListAll();

    public async Task<List<Location>> ListAllAvaible()
      => await _locationRepository.ListAll(true);

    public async Task<List<Location>> ListAllNotAvaible()
      => await _locationRepository.ListAll(false);
}
