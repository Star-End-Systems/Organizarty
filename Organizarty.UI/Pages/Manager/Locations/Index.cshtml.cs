using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Locations.Entities;
using Organizarty.Application.App.Locations.UseCases;
using Organizarty.UI.Attributes;

namespace Organizarty.UI.Pages.Manager.Locations;

// [Authorized("/", UserType.Mannager)]
public class IndexModel : PageModel
{
    private readonly SelectLocationUseCase _selectLocation;

    public IndexModel(SelectLocationUseCase selectLocation)
    {
        _selectLocation = selectLocation;
    }

    public List<Location> Locations { get; set; } = new();

    public async Task OnGetAsync()
    {
        Locations = await _selectLocation.ListAll();
    }

}
