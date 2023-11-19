using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Foods.Entities;
using Organizarty.UI.Attributes;
namespace Organizarty.UI.Pages.ThirdParty.Products;

[Authorized("/ThirdParty/Accounts/Login", UserType.ThirdParty, UserType.Mannager)]
public class IndexModel : PageModel
{
    public List<FoodType> foods { get; set; } = new();

    public IndexModel()
    {
    }

    public async Task OnGetAsync()
    {

    }

}
