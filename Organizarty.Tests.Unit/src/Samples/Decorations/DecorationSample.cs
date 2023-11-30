using Organizarty.Application.App.DecorationInfos.Entities;
using Organizarty.Application.App.DecorationInfos.UseCases;
using Organizarty.Application.App.Decorations.Entities;
using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Application.App.DecorationTypes.UseCases;

namespace Organizarty.Tests.Unit.Samples.Decorations;

public static partial class DecorationSample
{
    public static async Task<DecorationType> SetupDecorationType(CreateDecorationTypeUseCase usecase)
      => await usecase.Execute(
          new("Caneca Organizarty", "Caneca oficial com logo da organizarty", DecorationCategory.Copo, "Grande", "Caneca", "localhost:8000")
        );

    public static async Task<DecorationInfo> SetupDecorationInfo(CreateDecorationInfoUseCase usecase, Guid decorationId)
    {
        var data = new CreateDecorationInfoDto("#ffffff", "Vidro", true, 12.5m, "localhost:8000", decorationId);

        return await usecase.Execute(data);
    }
}
