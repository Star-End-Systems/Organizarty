using Organizarty.Application.App.ThirdParties.UseCases;
using Organizarty.Application.App.ThirdParties.Data;
using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Tests.Mock.Adapters;

namespace Organizarty.Tests.Factories.UseCases;

public partial class UseCasesFactory
{
    public RegisterThirdPartyUseCase RegisterThirdPartyUseCase(IThirdPartyRepository thirdPartyRepository)
      => new RegisterThirdPartyUseCase(thirdPartyRepository, new CryptographyMock(), new ThirdPartyValidator());

    public LoginThirdPartyUseCase LoginThirdPartyUseCase(IThirdPartyRepository thirdPartyRepository)
      => new LoginThirdPartyUseCase(new CryptographyMock(), thirdPartyRepository);

    public AuthorizeThirdPartyUseCase AuthorizeThirdPartyUseCase(IThirdPartyRepository thirdPartyRepository)
      => new AuthorizeThirdPartyUseCase(thirdPartyRepository);
}
