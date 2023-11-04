using Organizarty.Tests.Factories.Database;
using Organizarty.Tests.Factories.Repositories;
using Organizarty.Tests.Factories.UseCases;
using Organizarty.Tests.Samples.Locations;

namespace Organizarty.Tests.Unit.Locations;

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

            try
            {
                var location = await LocationSample.SetupLocation(createLocation);
                Assert.NotEqual(Guid.Empty, location.Id);
            }
            catch (ValidationFailException e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
