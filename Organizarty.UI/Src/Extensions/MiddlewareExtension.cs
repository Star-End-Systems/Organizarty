using Organizarty.UI.Middlewares.Authorization;

namespace Organizarty.UI.Extensions;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseRedirectMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<JwtMiddleware>();
    }
}
