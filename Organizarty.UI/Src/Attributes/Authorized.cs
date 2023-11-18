using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Organizarty.Adapters;
using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Application.App.Managers.Entities;

namespace Organizarty.UI.Attributes;

public class Authorized : Attribute, IPageFilter
{
    private readonly string _redirectPage;
    private readonly UserType[] _userTypes;

    public Authorized(string redirectPage = "/", params UserType[] userTypes)
    {
        _redirectPage = redirectPage;
        _userTypes = userTypes;
    }

    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        var account = context.HttpContext.Items["Account"];

        Console.WriteLine(account);

        if (account is null)
        {
            context.Result = new RedirectResult(_redirectPage);
            return;
        }

        try
        {
            foreach (var type in _userTypes)
            {
                switch (type)
                {
                    case (UserType.Client):
                        if ((User?)account is not null)
                            return;
                        break;

                    case (UserType.ThirdParty):
                        if ((ThirdParty?)account is not null)
                            return;
                        break;

                    case (UserType.Mannager):
                        if ((Manager?)account is not null)
                            return;
                        break;
                    default:
                        context.Result = new RedirectResult(_redirectPage);
                        break;
                }
            }
        }
        catch (Exception)
        {
            context.Result = new RedirectResult(_redirectPage);
        }
    }

    public void OnPageHandlerSelected(PageHandlerSelectedContext context) { }
    public void OnPageHandlerExecuted(PageHandlerExecutedContext context) { }
}
