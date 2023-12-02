using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.App.Services.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Attributes;

namespace Organizarty.UI.Pages.ThirdParty.Services;

[Authorized("/ThirdParty/Accounts/Login", UserType.ThirdParty, UserType.Mannager)]
public class EditServiceModel : PageModel
{
    private readonly SelectServicesUseCase _selectServices;
    private readonly EditServiceItemUseCase _editService;

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel : ServiceType
    {
        public string StrTags { get; set; } = "";

        public InputModel() { }

        public InputModel(ServiceType service)
        {
            Id = service.Id;
            Name = service.Name;
            Description = service.Description;
            Category = service.Category;
            Tags = service.Tags;
            StrTags = String.Join(", ", service.Tags);
        }
    }
    public EditServiceModel(SelectServicesUseCase selectServices, EditServiceItemUseCase editService)
    {
        _selectServices = selectServices;
        _editService = editService;
    }

    public async Task OnGetAsync(Guid serviceId)
    {
        Input = new InputModel(await _selectServices.FindServiceById(serviceId));
    }

    public async Task<IActionResult> OnPostAsync(Guid serviceId)
    {
        try
        {
            var tags = Input.StrTags.Split(",").ToList();
            await _editService.Execute(new(serviceId, Input.Name, Input.Description, tags));
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
