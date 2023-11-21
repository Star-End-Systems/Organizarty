using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Foods.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Attributes;
using Organizarty.UI.Helpers;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages.ThirdParty.Products;

[Authorized("/ThirdParty/Accounts/Login", UserType.ThirdParty, UserType.Mannager)]
public class NewProductsModel : PageModel
{
    private readonly CreateFoodUseCase _createFood;
    private readonly AuthenticationHelper _authHelper;

    public NewProductsModel(CreateFoodUseCase createFood, AuthenticationHelper authHelper)
    {
        _createFood = createFood;
        _authHelper = authHelper;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Display(Name = "Nome")]
        public string Name { get; set; } = default!;

        [Display(Name = "Descrição")]
        public string Description { get; set; } = default!;

        [Display(Name = "Categoria")]
        public string Category { get; set; } = default!;

        [Display(Name = "Tags")]
        public List<string> Tags { get; set; } = new();
    }
    public void OnGet()
    {

    }
    public async Task<IActionResult> OnPostAsync()
    {
        var thirdParty = await _authHelper.GetThirdPartyFromToken(_authHelper.GetToken() ?? "");

        if (thirdParty is null)
        {
            return Page();
        }

        var data = new CreateFoodDto(Input.Name, Input.Description, Input.Category, Input.Tags, thirdParty.Id);

        try
        {
            await _createFood.Execute(data);
            return RedirectToPage("/ThirdParty/Products/Index");
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
