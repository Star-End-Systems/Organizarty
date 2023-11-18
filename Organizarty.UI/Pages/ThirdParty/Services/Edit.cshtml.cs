using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.App.Services.UseCases;
using Organizarty.UI.Attributes;

namespace Organizarty.UI.Pages.ThirdParty.Services;

[Authorized("/ThirdParty/Accounts/Login", UserType.ThirdParty, UserType.Mannager)]
public class EditServiceModel : PageModel
{
    private readonly SelectServicesUseCase _selectServices;

    public ServiceInfo Service { get; set; } = default!;

    public EditServiceModel(SelectServicesUseCase selectServices)
    {
        _selectServices = selectServices;
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
}
