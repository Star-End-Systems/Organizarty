using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.UI.Attributes;
using Organizarty.Application.Exceptions;
using Organizarty.Application.App.Foods.UseCases;
using Organizarty.Application.App.Foods.Entities;

namespace Organizarty.UI.Pages.ThirdParty.Products;

[Authorized("/ThirdParty/Accounts/Login", UserType.ThirdParty, UserType.Mannager)]
public class EditFoodSubitemModel : PageModel
{
    private readonly EditFoodSubItemUseCase _editFood;
    private readonly SelectFoodsUseCase _selectFood;

    public EditFoodSubitemModel(EditFoodSubItemUseCase editFood, SelectFoodsUseCase selectFood)
    {
        _editFood = editFood;
        _selectFood = selectFood;
    }

    [BindProperty]
    public FoodInfo Input { get; set; } = new();

    [BindProperty]
    public string ImgURL { get; set; } = "";

    public Guid FoodId { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid foodId)
    {
        FoodId = foodId;

        var f = await _selectFood.FindFoodSubItem(foodId);
        if (f is null)
        {
            return Redirect("/ThirdParty/Products");
        }

        Input = f;
        ImgURL = f.Images[0];

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid foodId)
    {
        try
        {
            await _editFood.Execute(new(foodId, Input.Available, Input.Flavour, Input.Price, new() { ImgURL }));
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
