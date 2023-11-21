using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Foods.Entities;
using TP = Organizarty.Application.App.ThirdParties.Entities.ThirdParty;
using Organizarty.Application.App.Foods.UseCases;
using Organizarty.UI.Attributes;
using Organizarty.UI.Helpers;

namespace Organizarty.UI.Pages.ThirdParty.Products;

[Authorized("/ThirdParty/Accounts/Login", UserType.ThirdParty, UserType.Mannager)]
public class IndexModel : PageModel
{
    private readonly SelectFoodsUseCase _selectFood;
    private readonly AuthenticationHelper _authHelper;

    public List<FoodType> Foods { get; set; } = new();
    public TP ThirdParty { get; set; } = new();

    public IndexModel(SelectFoodsUseCase selectFood, AuthenticationHelper authHelper)
    {
        _selectFood = selectFood;
        _authHelper = authHelper;
    }

    public async Task OnGetAsync()
    {
        ThirdParty = (await _authHelper.GetThirdPartyFromToken(_authHelper.GetToken() ?? ""))!;

        try
        {
            Foods = await _selectFood.AllFoodsFromThirdParty(ThirdParty.Id);
        }
        catch (Exception) { }
    }

}
