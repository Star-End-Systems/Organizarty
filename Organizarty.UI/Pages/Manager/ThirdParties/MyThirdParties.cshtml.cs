using Microsoft.AspNetCore.Mvc.RazorPages;
using TP = Organizarty.Application.App.ThirdParties.Entities.ThirdParty;
using Organizarty.Application.App.ThirdParties.UseCases;

namespace Organizarty.UI.Pages;

public class MyThirdPartiesModel : PageModel
{
    private readonly ILogger<ThirdPartyInfoModel> _logger;
    private readonly SelectThirdPartyUseCase _selectThirdParty;

    public bool Success { get; set; } = false;

    public MyThirdPartiesModel(ILogger<ThirdPartyInfoModel> logger, SelectThirdPartyUseCase selectThirdParty)
    {
        _logger = logger;
        _selectThirdParty = selectThirdParty;
    }

    public List<TP> ThirdParties { get; set; } = new();

    public async Task OnGetAsync()
    {
        try
        {
            ThirdParties = await _selectThirdParty.GetAllPending();

            Success = true;
        }
        catch (Exception)
        {
            Success = false;
        }
    }
}
