using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.App.Services.UseCases;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.ThirdParty.Services;

public class EditServicesModel : PageModel
{
    private readonly ILogger<EditServicesModel> _logger;
    private readonly SelectServicesUseCase _selectServices;

    public EditServicesModel(ILogger<EditServicesModel> logger, SelectServicesUseCase selectServices)
    {
        _logger = logger;
        _selectServices = selectServices;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public ServiceInfo Service { get; set; } = default!;

    public class InputModel
    {
        [Display(Name = "Description")]
        public string Description { get; set; } = default!;

        [Display(Name = "Proucurar")]
        public string Search { get; set; } = default!;
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
                Price = 54.50M,
                Plan = "500 fotos",
                ServiceType = new()
                {
                    Name = "Fotografo",
                    Description = "Um belo fotografo com ainda mais belas fotografias.",
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

        return RedirectToPage("", new { description = Input.Description });
    }
}
