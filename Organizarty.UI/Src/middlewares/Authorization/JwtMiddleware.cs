namespace Organizarty.UI.Middlewares.Authorization;

using Organizarty.Adapters;
using Organizarty.UI.Helpers;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, AuthenticationHelper jwtUtils)
    {
        jwtUtils.AddRequest(context.Request);

        var (token, role) = jwtUtils.GetTokenAndRole();

        if (token is null)
        {
            await _next(context);
            return;
        }

        switch (role)
        {
            case (UserType.Client):
                context.Items["Account"] = await jwtUtils.GetUserFromToken(token);
                break;
            case (UserType.ThirdParty):
                context.Items["Account"] = await jwtUtils.GetThirdPartyFromToken(token);
                break;
            case (UserType.Mannager):
                context.Items["Account"] = await jwtUtils.GetUserFromToken(token);
                break;
            default:
                context.Items["Account"] = null;
                break;
        }

        await _next(context);
    }
}
