using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Organizarty.Adapters;
using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Application.App.Managers.Entities;

namespace Organizarty.UI.Attributes;

class RedirectException : Exception
{
    public string Route { get; }

    public RedirectException(string msg, string route) : base(msg)
    {
        Route = route;
    }
}

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
                        if (account is User user)
                        {
                            if (!user.EmailConfirmed)
                            {
                                throw new RedirectException("", "/Clients/Accounts/ConfirmYourAccount");
                            }

                            return;
                        }
                        break;
                    case (UserType.ThirdParty):
                        if (account is ThirdParty thirdParty)
                        {
                            if (thirdParty.AuthorizationStatus != Application.App.Utils.Enums.AuthorizationStatus.Authorized)
                            {
                                throw new RedirectException("", "/ThirdParty/Accounts/ConfirmAccount");
                            }

                            return;
                        }
                        break;
                    case (UserType.Mannager):
                        if (account is Manager manager)
                        {
                            return;
                        }
                        break;
                }
                throw new Exception("");
            }
        }
        catch (RedirectException e)
        {
            context.Result = new RedirectResult(e.Route);
        }
        catch (Exception)
        {
            context.Result = new RedirectResult(_redirectPage);
        }
    }

    public void OnPageHandlerSelected(PageHandlerSelectedContext context) { }
    public void OnPageHandlerExecuted(PageHandlerExecutedContext context) { }
}
