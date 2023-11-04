using Organizarty.Tests.Factories.Database;
using Organizarty.Tests.Factories.Repositories;
using Organizarty.Tests.Factories.UseCases;
using Organizarty.Tests.Samples.Decorations;

namespace Organizarty.Tests.Unit.Decorations;

public class CreateDecorationTypeTest
{
    [Fact]
    public async Task CreateDecorationType_Sample_ReturnCreatedDecorationType()
    {
        using (var context = DatabaseFactory.InMemoryDatabase())
        {
            var repos = new RepositoriesFactory(context);
            var usecases = new UseCasesFactory();

            var repo = repos.DecorationTypeRepository();

            var createDecoration = usecases.CreateDecorationTypeUseCase(repo);

            var decoration = await DecorationSample.SetupDecorationType(createDecoration);

            Assert.NotEqual(Guid.Empty, decoration.Id);
            Assert.Empty(decoration.Tags);
        }
    }
}
