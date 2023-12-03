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
public class NewServiceSubitemModel : PageModel
{
    private readonly CreateServiceInfoUseCase _createService;
    private readonly AuthenticationHelper _authHelper;

    public TP ThirdParty { get; set; } = new();

    public NewServiceSubitemModel(CreateServiceInfoUseCase createService, AuthenticationHelper authHelper)
    {
        _createService = createService;
        _authHelper = authHelper;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public class InputModel
    {
        [Required]
        public decimal Price { get; set; } = default!;

        public bool IsAvaible { get; set; } = default!;

        [Required]
        public string Plan { get; set; } = default!;

        [Required]
        public string ImgURL { get; set; } = default!;

    }

    public Guid ServiceId { get; set; }

    public void OnGet(Guid serviceId)
    {
        ServiceId = serviceId;
    }

    public async Task<IActionResult> OnPostAsync(Guid serviceId)
    {
        var thirdParty = await _authHelper.GetThirdPartyFromToken(_authHelper.GetToken() ?? "");

        if (thirdParty is null)
        {
            return Page();
        }

        try
        {
            await _createService.Execute(new(Input.Price, Input.IsAvaible, Input.Plan, new() { Input.ImgURL }, serviceId));
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
