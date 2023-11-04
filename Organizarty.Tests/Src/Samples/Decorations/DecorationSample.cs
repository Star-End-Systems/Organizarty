using Organizarty.Application.App.DecorationInfos.Entities;
using Organizarty.Application.App.DecorationInfos.UseCases;
using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Application.App.DecorationTypes.UseCases;

namespace Organizarty.Tests.Samples.Decorations;

public static class DecorationSample
{
    public static async Task<DecorationType> SetupDecorationType(CreateDecorationTypeUseCase usecase)
    {
        var data = new CreateDecorationTypeDto("Caneca Organizarty", "Caneca oficial com logo da organizarty", "Grande", "Caneca", "localhost:8000");

        return await usecase.Execute(data);
    }

    public static async Task<DecorationInfo> SetupDecorationInfo(CreateDecorationInfoUseCase usecase, Guid decorationId)
    {
        var data = new CreateDecorationInfoDto("#ffffff", "Vidro", true, 12.5m, "localhost:8000", decorationId);

        return await usecase.Execute(data);
    }
}
