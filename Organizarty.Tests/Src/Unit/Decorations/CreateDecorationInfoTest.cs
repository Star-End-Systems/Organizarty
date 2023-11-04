using Organizarty.Tests.Factories.Database;
using Organizarty.Tests.Factories.Repositories;
using Organizarty.Tests.Factories.UseCases;
using Organizarty.Tests.Samples.Decorations;

namespace Organizarty.Tests.Unit.Decorations;

public class CreateDecorationInfoTest
{
    [Fact]
    public async Task CreateDecorationInfo_Sample_ReturnCreatedDecorationInfo()
    {
        using (var context = DatabaseFactory.InMemoryDatabase())
        {
            var repos = new RepositoriesFactory(context);
            var usecases = new UseCasesFactory();

            var repoType = repos.DecorationTypeRepository();
            var repoInfo = repos.DecorationInfoRepository();

            var createDecoration = usecases.CreateDecorationTypeUseCase(repoType);
            var createDecorationInfo = usecases.CreateDecorationInfoUseCase(repoInfo);

            var decoration = await DecorationSample.SetupDecorationType(createDecoration);

            var decorationInfo = await DecorationSample.SetupDecorationInfo(createDecorationInfo, decoration.Id);

            Assert.NotEqual(Guid.Empty, decorationInfo.Id);
            Assert.Equal(decoration.Id, decorationInfo.DecorationTypeId);
        }
    }
}
