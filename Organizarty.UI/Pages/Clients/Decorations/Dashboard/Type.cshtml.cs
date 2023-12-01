using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Decorations.Entities;
using Organizarty.UI.Attributes;
namespace Organizarty.UI.Pages.Clients.Decorations.Dashboard;

[Authorized("/Clients/Accounts/Login", UserType.Client)]
public class TypeModel : PageModel
{
    [FromRoute]
    public DecorationCategory DecorationCategory { get; set; }
}