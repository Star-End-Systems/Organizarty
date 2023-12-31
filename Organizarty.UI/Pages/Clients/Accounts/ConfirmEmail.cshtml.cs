using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Users.UseCases;
using Organizarty.UI.Attributes;
using Organizarty.UI.Helpers;
using Organizarty.Adapters;


namespace Organizarty.UI.Pages.Clients.Accounts;

public class ConfirmEmailModel : PageModel
{
    private readonly ILogger<ConfirmEmailModel> _logger;
    private readonly AuthenticationHelper _authHelper;

    public ConfirmEmailModel(ILogger<ConfirmEmailModel> logger, AuthenticationHelper authHelper)
    {
        _logger = logger;
        _authHelper = authHelper;
    }

    public bool Success { get; set; } = false;

    public string MaskedEmail { get; set; } = "";

    public async Task OnGetAsync()
    {
        var user = (await _authHelper.GetUserFromToken(_authHelper.GetToken()!))!;

        var email = user.Email;

        int atSymbolIndex = email.IndexOf("@");

        string domain = email.Substring(atSymbolIndex + 1);

        int asterisksNeeded = email.Length - 2 - domain.Length - 1; // subtract 1 for the "@" symbol

        MaskedEmail = email[0] + new string('*', asterisksNeeded) + "@" + domain;
    }
}
