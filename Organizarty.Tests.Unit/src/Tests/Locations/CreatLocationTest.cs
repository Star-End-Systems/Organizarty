using Organizarty.Tests.Mock.Database;
using Organizarty.Tests.Mock.Repositories;
using Organizarty.Tests.Mock.UseCases;
using Organizarty.Tests.Unit.Samples.Locations;

namespace Organizarty.Tests.Unit.Tests.Locations;

public class CreatLocationTest
{
    [Fact]
    public async Task CreateLocation_ValidInfos_ReturnCreatedLocation()
    {
        using (var context = DatabaseFactory.InMemoryDatabase())
        {
            var repos = new RepositoriesFactory(context);
            var usecases = new UseCasesFactory();

            var repo = repos.LocationRepository();

            var createLocation = usecases.CreateLocationUseCase(repo);

            var location = await LocationSample.SetupLocation(createLocation);
            Assert.NotEqual(Guid.Empty, location.Id);
        }
    }
}
