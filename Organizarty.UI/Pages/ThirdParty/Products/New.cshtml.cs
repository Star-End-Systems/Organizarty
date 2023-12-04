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

    public string Category { get; set; } = "";

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Required(ErrorMessage="O campo 'Nome' deve ser preenchido")]
        [Display(Name = "Nome")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage="O campo 'Descrição' deve ser preenchido")]
        [Display(Name = "Descrição")]
        public string Description { get; set; } = default!;

        [Required(ErrorMessage="O campo 'Tags' deve ser preenchido")]
        [Display(Name = "Tags")]
        public string Tags { get; set; } = "";
    }

    public async Task OnGetAsync(string category)
    {
        Category = category;
    }

    public async Task<IActionResult> OnPostAsync(string category)
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
            await _createFood.Execute(new(Input.Name, Input.Description, category, Input.Tags.Split(",").ToList(), thirdParty.Id));
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
