using Organizarty.Application.App.DecorationInfos.Entities;
using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Tests.Mock.UseCases;

namespace Organizarty.Tests.Unit.Samples.Decorations;

public static partial class DecorationSample
{
    public static async Task<DecorationType> SetupDecorationType(UseCasesFactory usecases)
    {
        var use = usecases.CreateDecorationTypeUseCase();

        return await SetupDecorationType(use);
    }

    public static async Task<DecorationInfo> SetupDecorationInfo(UseCasesFactory usecases, Guid decorationId)
    {
        var use = usecases.CreateDecorationInfoUseCase();

        return await SetupDecorationInfo(use, decorationId);
    }
}
