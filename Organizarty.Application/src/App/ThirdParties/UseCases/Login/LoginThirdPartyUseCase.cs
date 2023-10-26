using Organizarty.Adapters;
using Organizarty.Application.App.ThirdParties.Data;
using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.ThirdParties.UseCases;

public class LoginThirdPartyUseCase
{
    private readonly ICryptographys _cryptographys;
    private readonly IThirdPartyRepository _thirdPartyRepository;
    private readonly ITokenProvider _tokenProvider;

    public LoginThirdPartyUseCase(ICryptographys cryptographys, IThirdPartyRepository userRepository, ITokenProvider token)
    {
        _cryptographys = cryptographys;
        _thirdPartyRepository = userRepository;
        _tokenProvider = token;
    }

    public async Task<(ThirdParty User, string Token)> Execute(LoginThirdPartyDto thirdPartyDto)
    {
        var thirdParty = await _thirdPartyRepository.FindByEmail(thirdPartyDto.Email) ?? throw new NotFoundException($"User with email '{thirdPartyDto.Email}' not found.");
        ValidCredentials(thirdPartyDto.Password, thirdParty);
        var token = _tokenProvider.GenerateToken(thirdParty.Id.ToString(), thirdPartyDto.Email);

        return (thirdParty, token);
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

