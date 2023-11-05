using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Application.App.ThirdParties.UseCases;

namespace Organizarty.Tests.Unit.Samples.ThirdParties;

public static class ThirdPartySample
{
    public static async Task<ThirdParty> SetupThirdParty(RegisterThirdPartyUseCase register)
    {
        var data = new RegisterThirdPartyDto("ze coxinhas", "Eu vendo várias coxinhas", "Rua da coxinha", $"ze-{Guid.NewGuid().ToString()}@coxinhas.com", "long_password", "12345678901", "ze@coxinhas.com", "12345678901", "CNPJQUALQUERRR", "localhost:8000", new List<string>());

        return await register.Execute(data);
    }

    public static async Task<ThirdParty> SetupThirdPartyAuthorized(RegisterThirdPartyUseCase register, AuthorizeThirdPartyUseCase authorize)
    {
        var third = await ThirdPartySample.SetupThirdParty(register);

        return await authorize.Execute(third);
    }
}
