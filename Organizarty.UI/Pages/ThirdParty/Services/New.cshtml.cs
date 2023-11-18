using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Services.UseCases;
using TP = Organizarty.Application.App.ThirdParties.Entities.ThirdParty;
using Organizarty.UI.Attributes;
using Organizarty.UI.Helpers;
using Organizarty.Application.Exceptions;

namespace Organizarty.UI.Pages.ThirdParty.Services;

[Authorized("/ThirdParty/Accounts/Login", UserType.ThirdParty, UserType.Mannager)]
public class NewServiceModel : PageModel
{
    private readonly CreateServiceTypeUseCase _createService;
    private readonly AuthenticationHelper _authHelper;

    public TP ThirdParty { get; set; } = new();

    public NewServiceModel(CreateServiceTypeUseCase createService, AuthenticationHelper authHelper)
    {
        _createService = createService;
        _authHelper = authHelper;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public class InputModel
    {
        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public string Description { get; set; } = default!;

    }

    public async Task<IActionResult> OnPostAsync()
    {
        var thirdParty = await _authHelper.GetThirdPartyFromToken(_authHelper.GetToken() ?? "");

        if (thirdParty is null)
        {
            return Page();
        }

        var data = new CreateServiceTypeDto(Input.Name, Input.Description, thirdParty.Id, new() { "chocolate" });

        try
        {
            await _createService.Execute(data);
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
