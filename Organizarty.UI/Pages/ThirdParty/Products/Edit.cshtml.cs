using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Foods.Entities;
using Organizarty.Application.App.Foods.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Helpers;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages.ThirdParty.Products;

public class EditProductsModel : PageModel
{
    private readonly EditFoodUseCase _editFood;
    private readonly AuthenticationHelper _authHelper;
    private readonly SelectFoodsUseCase _selectFood;

    public EditProductsModel(EditFoodUseCase editFood, AuthenticationHelper authHelper, SelectFoodsUseCase selectFood)
    {
        _editFood = editFood;
        _authHelper = authHelper;
        _selectFood = selectFood;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel : FoodType
    {
        public string StrTags {get; set;} = "";

        public InputModel() { }

        public InputModel(FoodType food)
        {
            Id = food.Id;
            Name = food.Name;
            Description = food.Description;
            Category = food.Category;
            Tags = food.Tags;
            StrTags = String.Join(", ", food.Tags);
        }
    }

    public async Task<IActionResult> OnGetAsync(Guid foodid)
    {
        var f = await _selectFood.FindFoodById(foodid);
        if (f is null)
        {
            return Redirect("/ThirdParty/Products");
        }

        Input = new InputModel(f);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid foodid)
    {
        try
        {
            var f = (await _selectFood.FindFoodById(foodid))!;

            var tags = Input.StrTags.Split(",").ToList();
            await _editFood.Execute(new(foodid, Input.Name, Input.Description, f.Category, tags));
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
