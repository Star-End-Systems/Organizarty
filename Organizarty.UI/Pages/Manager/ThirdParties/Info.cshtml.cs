using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TP = Organizarty.Application.App.ThirdParties.Entities.ThirdParty;
using Organizarty.Application.App.ThirdParties.UseCases;

namespace Organizarty.UI.Pages;

public class ThirdPartyInfoModel : PageModel
{
    private readonly ILogger<ThirdPartyInfoModel> _logger;
    private readonly SelectThirdPartyUseCase _selectThirdParty;

    public ThirdPartyInfoModel(ILogger<ThirdPartyInfoModel> logger, SelectThirdPartyUseCase selectThirdParty)
    {
        _logger = logger;
        _selectThirdParty = selectThirdParty;
    }

    public TP ThirdParty { get; set; } = new();

    public async Task OnGetAsync(Guid thirdPartyId)
    {
        var third = await _selectThirdParty.FindById(thirdPartyId);

        if (third is null)
        {
            _logger.LogInformation($"Third Party with id '{thirdPartyId}' not found.");
            return;
        }

        ThirdParty = third;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return Page();
    }
}
