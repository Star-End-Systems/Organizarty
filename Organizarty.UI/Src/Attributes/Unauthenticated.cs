using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Organizarty.UI.Attributes;

public class Unauthenticated : Attribute, IPageFilter
{
    private readonly string _redirectPage;

    public Unauthenticated() : this("/") { }

    public Unauthenticated(string redirectPage)
    {
        _redirectPage = redirectPage;
    }

    public void OnPageHandlerSelected(PageHandlerSelectedContext context) { }

    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        var account = context.HttpContext.Items["Account"];
        if (account is not null)
        {
            context.Result = new RedirectResult(_redirectPage);
        }
    }

    public void OnPageHandlerExecuted(PageHandlerExecutedContext context) { }
}
