using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Services.UseCases;
using Organizarty.UI.Attributes;
using Organizarty.Application.Exceptions;
using Organizarty.Application.App.Services.Entities;

namespace Organizarty.UI.Pages.ThirdParty.Services;

[Authorized("/ThirdParty/Accounts/Login", UserType.ThirdParty, UserType.Mannager)]
public class EditSubitemModel : PageModel
{
    private readonly EditServiceSubItemUseCase _editService;
    private readonly SelectServicesUseCase _selectService;

    public EditSubitemModel(EditServiceSubItemUseCase editService, SelectServicesUseCase selectService)
    {
        _editService = editService;
        _selectService = selectService;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public class InputModel : ServiceInfo
    {
        public string ImgURL { get; set; } = "";

        public InputModel() { }

        public InputModel(ServiceInfo service)
        {
            Price = service.Price;
            IsAvaible = service.IsAvaible;
            Plan = service.Plan;
            Images = service.Images;
            ImgURL = Images[0];
        }
    }

    public async Task OnGetAsync(Guid serviceId)
    {
        Console.WriteLine(serviceId);

        Input = new(await _selectService.FindSubServiceById(serviceId));
    }

    public async Task<IActionResult> OnPostAsync(Guid serviceId)
    {
        try
        {
            await _editService.Execute(new(serviceId, Input.Price, Input.IsAvaible, Input.Plan, new() { Input.ImgURL }));
            return RedirectToPage("/ThirdParty/Services/MyServices");
        }
        catch (ValidationFailException e)
        {
            foreach (var err in e.Errors)
            {
                ModelState.AddModelError(string.Empty, err.message);
            }

            return Page();
        }
    }
}
