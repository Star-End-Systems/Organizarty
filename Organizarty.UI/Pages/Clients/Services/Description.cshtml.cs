using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Services.Entities;
using TP = Organizarty.Application.App.ThirdParties.Entities.ThirdParty;
using Organizarty.Application.App.Services.UseCases;
using Organizarty.Application.App.ThirdParties.UseCases;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.Clients.Services;

public class DescriptionModel : PageModel
{
    private readonly SelectServicesUseCase _selectServices;
    private readonly SelectThirdPartyUseCase _selectThirdParty;
    private readonly ILogger<DescriptionModel> _logger;

    public DescriptionModel(ILogger<DescriptionModel> logger, SelectServicesUseCase selectServices, SelectThirdPartyUseCase selectThirdParty)
    {
        _logger = logger;
        _selectServices = selectServices;
        _selectThirdParty = selectThirdParty;
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

    public ServiceInfo Service { get; set; } = new();
    public TP ThirdParty { get; set; } = new();

    public async Task OnGetAsync(Guid serviceId)
    {
        try
        {
            Service = await _selectServices.FindSubServiceById(serviceId);
            ThirdParty = await _selectThirdParty.FindById(Service.ServiceType.ThirdPartyId) ?? throw new Exception(Service.ServiceType.ThirdPartyId.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
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
