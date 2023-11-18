using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.App.Services.UseCases;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.Clients.Services;

public class DescriptionModel : PageModel
{
    private readonly SelectServicesUseCase _selectServices;
    private readonly ILogger<DescriptionModel> _logger;

    public ServiceInfo Service { get; set; } = default!;

    public DescriptionModel(ILogger<DescriptionModel> logger, SelectServicesUseCase selectServices)
    {
        _logger = logger;
        _selectServices = selectServices;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Display(Name = "ClientNotes")]
        public string Note { get; set; } = default!;

        [Display(Name = "ClientNotes")]
        public int Quantity { get; set; } = default!;
    }

    public async Task OnGetAsync(Guid serviceId)
    {
        try
        {
            Service = await _selectServices.FindSubServiceById(serviceId);
        }
        catch (Exception)
        {
            Service = new ServiceInfo
            {
                Id = serviceId,
                Price = 54.50M,
                Plan = "Sample plan",
                ServiceType = new()
                {
                    Name = "Sample service",
                    Description = "Sample Description",
                    Tags = new() { "Xiaomi", "Iphone", "Veio da lancha", "Debora" }
                }
            };
        }


    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return Redirect("/");
    }
}
