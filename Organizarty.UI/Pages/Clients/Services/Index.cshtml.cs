using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.App.Services.UseCases;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.Clients.Services;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly SelectServicesUseCase _selectServices;

    public List<ServiceType> Services = new();

    public IndexModel(ILogger<IndexModel> logger, SelectServicesUseCase selectServices)
    {
        _selectServices = selectServices;
        _logger = logger;
    }

    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Display(Name = "Search")]
        public string Search { get; set; } = default!;
    }

    public async Task OnGetAsync()
    {
        Services = await _selectServices.GetAvaibleServices();
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
