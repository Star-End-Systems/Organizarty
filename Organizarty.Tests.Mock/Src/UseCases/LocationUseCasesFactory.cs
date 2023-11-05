using Organizarty.Application.App.Locations.UseCases;
using Organizarty.Application.App.Locations.Data;
using Organizarty.Application.App.Locations.Entities;

namespace Organizarty.Tests.Mock.UseCases;

public partial class UseCasesFactory
{
    public CreateLocationUseCase CreateLocationUseCase(ILocationRepository repo)
      => new CreateLocationUseCase(repo, new LocationValidator());
}
