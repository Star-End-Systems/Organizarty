using Organizarty.Adapters;
using Organizarty.Application.App.ThirdParties.Data;
using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.ThirdParties.UseCases;

public class LoginThirdPartyUseCase
{
    private readonly ICryptographys _cryptographys;
    private readonly IThirdPartyRepository _thirdPartyRepository;

    public LoginThirdPartyUseCase(ICryptographys cryptographys, IThirdPartyRepository userRepository)
    {
        _cryptographys = cryptographys;
        _thirdPartyRepository = userRepository;
    }

    public async Task<ThirdParty> Execute(LoginThirdPartyDto thirdPartyDto)
    {
        var thirdParty = await _thirdPartyRepository.FindByEmail(thirdPartyDto.Email) ?? throw new NotFoundException($"User with email '{thirdPartyDto.Email}' not found.");
        ValidCredentials(thirdPartyDto.Password, thirdParty);

        return thirdParty;
    }

    private void ValidCredentials(string password, ThirdParty user)
    {
        var valid = _cryptographys.VerifyPassword(password, user.Password ?? "", user.Salt ?? "");

        if (!valid)
        {
            throw new NotFoundException("Email or password is not valid.");
        }
    }
}

