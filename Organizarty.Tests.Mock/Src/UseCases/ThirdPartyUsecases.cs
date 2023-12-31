using Organizarty.Application.App.ThirdParties.UseCases;
using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Tests.Mock.Adapters;

namespace Organizarty.Tests.Mock.UseCases;

public partial class UseCasesFactory
{
    public RegisterThirdPartyUseCase RegisterThirdPartyUseCase()
    {
        var thirdPartyRepository = _repositories.ThirdPartyRepository();

        return new RegisterThirdPartyUseCase(thirdPartyRepository, new CryptographyMock(), new ThirdPartyValidator());
    }

    public LoginThirdPartyUseCase LoginThirdPartyUseCase()
    {
        var thirdPartyRepository = _repositories.ThirdPartyRepository();

        return new LoginThirdPartyUseCase(new CryptographyMock(), thirdPartyRepository);
    }

    public AuthorizeThirdPartyUseCase AuthorizeThirdPartyUseCase()
    {
        var thirdPartyRepository = _repositories.ThirdPartyRepository();

        return new AuthorizeThirdPartyUseCase(thirdPartyRepository);
    }
}
