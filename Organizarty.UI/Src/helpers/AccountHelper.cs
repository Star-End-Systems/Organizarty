using Microsoft.AspNetCore.Mvc.Filters;
using Organizarty.Application.App.Users.Entities;

namespace Organizarty.UI.Helpers;

public static class AccountHelper
{
    private static Object? GetAccount(PageHandlerExecutingContext context)
      => context.HttpContext.Items["Account"];

    private static Object? GetAccount(HttpRequest context)
      => context.HttpContext.Items["Account"];

    public static User? GetUser(PageHandlerExecutingContext context)
      => (User?)GetAccount(context);

    public static User? GetUser(HttpRequest context)
      => (User?)GetAccount(context);
}
