using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Organizarty.Adapters;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Application.App.Users.UseCases;

namespace Organizarty.UI.Helpers;

public class AuthenticationHelper{
    private HttpResponse _response;
    private SelectUserUseCase _selectUser;

    public AuthenticationHelper(SelectUserUseCase selectUser){
        _selectUser = selectUser;
    }

    public AuthenticationHelper AddResponse(HttpResponse response){
        _response = response;

        return this;
    }

    public void WriteToken(string token){
        Console.WriteLine(_response);
        _response.Cookies.Append(
            "JWT_TOKEN",
            token ?? "nada",
            new CookieOptions()
            {
                Path = "/"
            }
        );
    }

    public async Task<User?> GetUserFromToken(string jwtToken){
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(jwtToken);
        
        var userType = jsonToken.Claims.First(x => x.Value == UserType.Client.ToString());

        if(userType.Value != UserType.Client.ToString()){
            return null;
        }

        var id = Guid.Parse(jsonToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

        return await _selectUser.GetUserId(id);
    }
}