using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Tests.Mock.UseCases;

namespace Organizarty.Tests.Unit.Samples.ThirdParties;

public static partial class ThirdPartySample
{
    public static async Task<ThirdParty> SetupThirdPartyAuthorized(UseCasesFactory usecases)
    {
        var register = usecases.RegisterThirdPartyUseCase();
        var authorize = usecases.AuthorizeThirdPartyUseCase();

        return await SetupThirdPartyAuthorized(register, authorize);
    }

    public static async Task<ThirdParty> SetupThirdParty(UseCasesFactory usecases)
      => await SetupThirdParty(usecases.RegisterThirdPartyUseCase());
}
