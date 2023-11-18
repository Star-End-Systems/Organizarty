using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.App.Users.Entities;
using Organizarty.UI.Attributes;
using Organizarty.UI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Shared;

[Authorized("/ThirdParty/Accounts/Login", UserType.Client, UserType.Mannager)]
public class OrganizartyclientLayoutModel : PageModel
{
    private readonly AuthenticationHelper _authHelper;

    public List<ServiceType> Services = new();

    public User Client { get; set; } = new();

    public OrganizartyclientLayoutModel(AuthenticationHelper authHelper)
    {
        _authHelper = authHelper;
    }

    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Display(Name = "Search")]
        public string Search { get; set; } = default!;
    }

    public async Task OnGet()
    {
        var token = _authHelper.GetToken()!;
        Client = await _authHelper.GetUserFromToken(token) ?? new();
    }
}
