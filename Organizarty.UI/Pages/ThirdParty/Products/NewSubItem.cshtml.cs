using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using TP = Organizarty.Application.App.ThirdParties.Entities.ThirdParty;
using Organizarty.UI.Attributes;
using Organizarty.UI.Helpers;
using Organizarty.Application.Exceptions;
using Organizarty.Application.App.Foods.UseCases;

namespace Organizarty.UI.Pages.ThirdParty.Products;

[Authorized("/ThirdParty/Accounts/Login", UserType.ThirdParty, UserType.Mannager)]
public class NewFoodSubitemModel : PageModel
{
    private readonly CreateFoodItemUseCase _createFood;
    private readonly AuthenticationHelper _authHelper;

    public TP ThirdParty { get; set; } = new();

    public NewFoodSubitemModel(CreateFoodItemUseCase createFood, AuthenticationHelper authHelper)
    {
        _createFood = createFood;
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
        public string Flavour { get; set; } = default!;

        [Required]
        public string ImgURL { get; set; } = default!;

    }

    public async Task<IActionResult> OnPostAsync(Guid foodId)
    {
        var thirdParty = await _authHelper.GetThirdPartyFromToken(_authHelper.GetToken() ?? "");

        if (thirdParty is null)
        {
            return Page();
        }

        var data = new CreateFoodItemDto(foodId, Input.IsAvaible, Input.Flavour, Input.Price, new() { Input.ImgURL });

        try
        {
            await _createFood.Execute(data);
            return RedirectToPage("./Index");
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
