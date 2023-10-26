using FluentValidation;
using Organizarty.Application.App.Locations.Data;
using Organizarty.Application.App.Locations.Entities;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.Locations.UseCases;

public class CreateLocationUseCase
{
    private readonly ILocationRepository _locationRepository;
    private readonly IValidator<Location> _validator;

    public CreateLocationUseCase(ILocationRepository locationRepository, IValidator<Location> validator)
    {
        _locationRepository = locationRepository;
        _validator = validator;
    }

    public async Task<Location> Execute(CreateLocationDto locationDto)
    {
        var location = locationDto.ToModel;
        ValidationUtils.Validate(_validator, location, "fail to create location.");

        return await _locationRepository.Create(location);
    }
}
