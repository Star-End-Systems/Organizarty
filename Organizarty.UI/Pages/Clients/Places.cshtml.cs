using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Locations.Entities;
using Organizarty.Application.App.Locations.UseCases;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages.Clients;

public class PlacesModel : PageModel
{
    private readonly ILogger<ProductsModel> _logger;
    private readonly SelectLocationUseCase _selectLocation;

    public PlacesModel(ILogger<ProductsModel> logger, SelectLocationUseCase selectLocation)
    {
        _logger = logger;
        _selectLocation = selectLocation;
    }

    public List<Location> Locations = new();

    public InputModel Input { get; set; } = default!;

    public class InputModel
    {

        [Display(Name = "Search")]
        public string Search { get; set; } = default!;
    }
    public async Task OnGetAsync()
    {
      Locations = await _selectLocation.ListAllAvaible();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("", new { search = Input.Search });
    }
}
