using Microsoft.AspNetCore.Mvc.RazorPages;
using TP = Organizarty.Application.App.ThirdParties.Entities.ThirdParty;
using Organizarty.Application.App.ThirdParties.UseCases;
using Organizarty.UI.Attributes;
using Organizarty.Adapters;

namespace Organizarty.UI.Pages;

[Authorized("/Manager/Accounts/Login", UserType.Mannager)]
public class AuthorizeThirdPartyModel : PageModel
{
    private readonly ILogger<ThirdPartyInfoModel> _logger;
    private readonly SelectThirdPartyUseCase _selectThirdParty;
    private readonly AuthorizeThirdPartyUseCase _authorizeThirdParty;

    public bool Success { get; set; } = false;

    public AuthorizeThirdPartyModel(ILogger<ThirdPartyInfoModel> logger, SelectThirdPartyUseCase selectThirdParty, AuthorizeThirdPartyUseCase authorizeThirdParty)
    {
        _logger = logger;
        _selectThirdParty = selectThirdParty;
        _authorizeThirdParty = authorizeThirdParty;
    }

    public TP ThirdParty { get; set; } = new();

    public async Task OnGetAsync(Guid thirdPartyId)
    {
        try
        {
            ThirdParty = await _authorizeThirdParty.Execute(thirdPartyId);

            Success = true;
        }
        catch (Exception)
        {
            Success = false;
        }
    }
}
