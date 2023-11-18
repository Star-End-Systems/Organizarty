using System.IdentityModel.Tokens.Jwt;
using Organizarty.Adapters;
using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Application.App.ThirdParties.UseCases;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Application.App.Users.UseCases;

namespace Organizarty.UI.Helpers;

public class AuthenticationHelper
{
    private readonly string COOKIE_NAME = "JWT_TOKEN";

    private HttpResponse _response = default!;
    private HttpRequest _request = default!;

    private readonly SelectUserUseCase _selectUser;
    private readonly SelectThirdPartyUseCase _selectThirdParty;

    public AuthenticationHelper(SelectUserUseCase selectUser, SelectThirdPartyUseCase selectThirdParty)
    {
        _selectUser = selectUser;
        _selectThirdParty = selectThirdParty;
    }

    public AuthenticationHelper AddResponse(HttpResponse response)
    {
        _response = response;

        return this;
    }

    public AuthenticationHelper AddRequest(HttpRequest request)
    {
        _request = request;

        return this;
    }

    public void WriteToken(string token)
    {
        _response.Cookies.Append(
            COOKIE_NAME,
            token,
            new CookieOptions()
            {
                Path = "/"
            }
        );
    }

    public (string? Token, UserType? Role) GetTokenAndRole()
    {
        var jwtToken = GetToken();

        if (jwtToken is null)
        {
            return (null, null);
        }

        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(jwtToken);

        var userType = jsonToken.Claims.FirstOrDefault(x => x.Type == "role");

        if (userType is null)
        {
            return (jwtToken, null);
        }

        return (jwtToken, (UserType)Enum.Parse(typeof(UserType), userType.Value));

    }

    public string? GetToken()
      => _request.Cookies[COOKIE_NAME];

    private Guid? GetIdFromToken(string token, UserType type)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(token);

        var userType = jsonToken.Claims.FirstOrDefault(x => x.Value == type.ToString());

        if (userType is null)
        {
            return null;
        }

        var id = jsonToken.Claims.FirstOrDefault(x => x.Type == "nameid")?.Value;

        if (id is null)
        {
            return null;
        }

        return Guid.Parse(id);
    }

    public async Task<User?> GetUserFromToken(string jwtToken)
    {
        var guid = GetIdFromToken(jwtToken, UserType.Client);

        if (guid is null)
        {
            return null;
        }

        return await _selectUser.GetUserId((Guid)guid);
    }

    public async Task<ThirdParty?> GetThirdPartyFromToken(string jwtToken)
    {
        var guid = GetIdFromToken(jwtToken, UserType.ThirdParty);

        if (guid is null)
        {
            return null;
        }

        return await _selectThirdParty.FindById((Guid)guid);
    }
}
