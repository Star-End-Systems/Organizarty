using Organizarty.Application.App.Locations.Entities;
using Organizarty.Application.App.Locations.UseCases;

namespace Organizarty.Tests.Samples.Locations;

public static class LocationSample
{
    public static async Task<Location> SetupLocation(CreateLocationUseCase usecase)
    {
        var data = new CreateLocationDto("Salão de festa", "Um salão básisco de festas", 50d, 250m, "69317488", "salao de festa", "rua de alguma coisa", "lat_lon", new());

        return await usecase.Execute(data);
    }
}
