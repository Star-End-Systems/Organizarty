using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.App.Services.UseCases;
using Organizarty.UI.Attributes;
using Organizarty.UI.Helpers;

namespace Organizarty.UI.Pages.ThirdParty.Services;

[Authorized("/ThirdParty/Accounts/Login", UserType.ThirdParty, UserType.Mannager)]
public class MyServiceModel : PageModel
{
    private readonly SelectServicesUseCase _selectServices;
    private readonly AuthenticationHelper _authHelper;

    public List<ServiceType> Services { get; set; } = new();

    public MyServiceModel(SelectServicesUseCase selectServices, AuthenticationHelper authHelper)
    {
        _selectServices = selectServices;
        _authHelper = authHelper;
    }

    public async Task OnGetAsync(Guid serviceId)
    {
        var thirdParty = await _authHelper.GetThirdPartyFromToken(_authHelper.GetToken() ?? "");

        try
        {
            Services = await _selectServices.FindServicesByThirdParty(thirdParty?.Id ?? Guid.NewGuid());
        }
        catch (Exception)
        {
            DefaultItem();
        }
    }

    private void DefaultItem()
    {
        var service = new ServiceType
        {
            Name = "Fotografo",
            Description = "Um belo fotografo com ainda mais belas fotografias.",
            Tags = new() { "Xiaomi", "Iphone", "Veio da lancha", "Debora" },
            SubServices = new List<ServiceInfo>() {
                  new(){
                     Id = Guid.NewGuid(),
                     Price = 54.50M,
                     Plan = "1000 fotos",
                  }
                }
        };

        Services = new() { service, service, service };

    }
}
