using Microsoft.AspNetCore.Mvc.RazorPages;
using TP = Organizarty.Application.App.ThirdParties.Entities.ThirdParty;
using Organizarty.Application.App.ThirdParties.UseCases;
using Organizarty.Adapters;
using Organizarty.UI.Attributes;

namespace Organizarty.UI.Pages;

[Authorized("/Manager/Accounts/Login", UserType.Mannager)]
public class RefuseThirdPartyModel : PageModel
{
    private readonly ILogger<ThirdPartyInfoModel> _logger;
    private readonly SelectThirdPartyUseCase _selectThirdParty;
    private readonly RefuseThirdPartyUseCase _refuseThirdParty;

    public bool Success { get; set; } = false;

    public RefuseThirdPartyModel(ILogger<ThirdPartyInfoModel> logger, SelectThirdPartyUseCase selectThirdParty, RefuseThirdPartyUseCase refuseThirdParty)
    {
        _logger = logger;
        _selectThirdParty = selectThirdParty;
        _refuseThirdParty = refuseThirdParty;
    }

    public TP ThirdParty { get; set; } = new();

    public async Task OnGetAsync(Guid thirdPartyId)
    {
        try
        {
            ThirdParty = await _refuseThirdParty.Execute(thirdPartyId);

            Success = true;
        }
        catch (Exception)
        {
            Success = false;
        }
    }
}
