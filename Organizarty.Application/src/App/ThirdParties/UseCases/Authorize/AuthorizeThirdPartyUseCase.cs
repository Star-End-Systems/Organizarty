using Organizarty.Adapters;
using Organizarty.Application.App.ThirdParties.Data;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.ThirdParties.UseCases;

public class AuthorizeThirdPartyUseCase
{
    private readonly IThirdPartyRepository _thirdPartyRepository;

    public AuthorizeThirdPartyUseCase(ICryptographys cryptographys, IThirdPartyRepository userRepository, ITokenProvider token)
    {
        _thirdPartyRepository = userRepository;
    }

    public async Task Execute(Guid thirdPartyId)
    {
        var thirdParty = await _thirdPartyRepository.FindById(thirdPartyId) ?? throw new NotFoundException($"Third party not found");
        thirdParty.Authorized = true;
        await _thirdPartyRepository.Update(thirdParty);
    }

    public async Task Execute(string email)
    {
        var thirdParty = await _thirdPartyRepository.FindByEmail(email) ?? throw new NotFoundException($"Third party with email '{email}' not found");
        await Execute(thirdParty.Id);
    }
}

