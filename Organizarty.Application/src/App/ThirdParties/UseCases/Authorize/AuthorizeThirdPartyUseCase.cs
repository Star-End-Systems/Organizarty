using Organizarty.Application.App.ThirdParties.Data;
using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Application.App.Utils.Enums;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.ThirdParties.UseCases;

public class AuthorizeThirdPartyUseCase
{
    private readonly IThirdPartyRepository _thirdPartyRepository;

    public AuthorizeThirdPartyUseCase(IThirdPartyRepository userRepository)
    {
        _thirdPartyRepository = userRepository;
    }

    public async Task<ThirdParty> ExecuteFromId(string thirdPartyId)
    {
        var thirdParty = await _thirdPartyRepository.FindById(thirdPartyId) ?? throw new NotFoundException($"Third party not found");
        return await Execute(thirdParty);
    }

    public async Task<ThirdParty> Execute(string email)
    {
        var thirdParty = await _thirdPartyRepository.FindByEmail(email) ?? throw new NotFoundException($"Third party with email '{email}' not found");
        return await Execute(thirdParty);
    }

    public async Task<ThirdParty> Execute(ThirdParty thirdParty)
    {
        thirdParty.AuthorizationStatus = AuthorizationStatus.Authorized;
        return await _thirdPartyRepository.Update(thirdParty);
    }
}

