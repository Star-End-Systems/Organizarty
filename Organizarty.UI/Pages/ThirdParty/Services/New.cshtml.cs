using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Services.UseCases;
using TP = Organizarty.Application.App.ThirdParties.Entities.ThirdParty;
using Organizarty.UI.Attributes;
using Organizarty.UI.Helpers;
using Organizarty.Application.Exceptions;
using Organizarty.Application.App.Services.Enums;

namespace Organizarty.UI.Pages.ThirdParty.Services;

[Authorized("/ThirdParty/Accounts/Login", UserType.ThirdParty, UserType.Mannager)]
public class NewServiceModel : PageModel
{
    private readonly CreateServiceTypeUseCase _createService;
    private readonly AuthenticationHelper _authHelper;
    public string Category { get; set; } = "";

    public TP ThirdParty { get; set; } = new();

    public NewServiceModel(CreateServiceTypeUseCase createService, AuthenticationHelper authHelper)
    {
        _createService = createService;
        _authHelper = authHelper;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();
    
    public async Task OnGetAsync(string category)
    {
        Category = category;
    }

    public class InputModel
    {
        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public string Description { get; set; } = default!;

        public string Tags { get; set; } = "";

    }

    public async Task<IActionResult> OnPostAsync(ServiceCategory category)
    {
        if(!ModelState.IsValid){
            return Page();
        }
        var thirdParty = await _authHelper.GetThirdPartyFromToken(_authHelper.GetToken() ?? "");

        if (thirdParty is null)
        {
            return Page();
        }

        try
        {
            var tags = Input.Tags.Split(",").ToList();
            await _createService.Execute(new(Input.Name, Input.Description, category, thirdParty.Id, tags));
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
