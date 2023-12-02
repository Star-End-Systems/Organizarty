using System.IdentityModel.Tokens.Jwt;
using Organizarty.Adapters;
using Organizarty.Application.App.Managers.Entities;
using Organizarty.Application.App.Managers.UseCases;
using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Application.App.ThirdParties.UseCases;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Application.App.Users.UseCases;
using Organizarty.Application.Exceptions;

namespace Organizarty.UI.Helpers;

public class AuthenticationHelper
{
    private readonly string COOKIE_NAME = "JWT_TOKEN";

    private HttpResponse _response = default!;
    private HttpRequest _request = default!;

    private readonly SelectUserUseCase _selectUser;
    private readonly SelectThirdPartyUseCase _selectThirdParty;
    private readonly SelectManagerUseCase _selectManager;

    public AuthenticationHelper(SelectUserUseCase selectUser, SelectThirdPartyUseCase selectThirdParty, SelectManagerUseCase selectManager)
    {
        _selectUser = selectUser;
        _selectThirdParty = selectThirdParty;
        _selectManager = selectManager;
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

    public void ClaerToken()
    {
        _response.Cookies.Delete(COOKIE_NAME);
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
    {
        string? authHeader = _request.Headers["Authorization"];

        if (authHeader is not null && authHeader.StartsWith("Bearer "))
        {
            return authHeader.Substring("Bearer ".Length).Trim();
        }

        return _request.Cookies[COOKIE_NAME];
    }

    private Guid? GetIdFromToken(string token, UserType type)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new ValidationFailException("Token not found", new());
        }

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

    public async Task<User?> GetUserFromToken()
    => await GetUserFromToken(GetToken() ?? "");

    public async Task<User?> GetUserFromToken(string jwtToken)
    {
        var guid = GetIdFromToken(jwtToken, UserType.Client);

        if (guid is null)
        {
            return null;
        }

        return await _selectUser.GetUserId((Guid)guid);
    }

    public async Task<Manager?> GetManagerFromToken(string jwtToken)
    {
        var guid = GetIdFromToken(jwtToken, UserType.Mannager);

        if (guid is null)
        {
            return null;
        }

        return await _selectManager.ById((Guid)guid);
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
