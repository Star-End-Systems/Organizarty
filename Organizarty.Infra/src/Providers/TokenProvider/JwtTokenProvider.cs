using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.IdentityModel.Tokens;

using Organizarty.Adapters;

namespace Organizarty.Infra.Providers.Token;

public class JwtTokenProvider : ITokenProvider
{
    public string GenerateToken(string userId, string username)
    {
        // TODO: Change to configuration class, so it will run when app starts
        string jwtSecretKey = Environment.GetEnvironmentVariable("JWY_SECRET_KEY") ?? throw new InvalidOperationException("\"JWT Sercret key\" Not founded. Pleace check the env variable");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(jwtSecretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.NameIdentifier, userId),
        }),
            Expires = DateTime.UtcNow.AddHours(24),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        string tokenStr = tokenHandler.WriteToken(token) ?? throw new Exception("Fail while creating token");

        return tokenStr;
    }
}
