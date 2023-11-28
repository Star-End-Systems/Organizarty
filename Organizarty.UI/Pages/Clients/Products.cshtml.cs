using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Foods.Entities;
using Organizarty.Application.App.Foods.UseCases;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages.Clients;

public class ProductsModel : PageModel
{
    private readonly ILogger<ProductsModel> _logger;
    private readonly SelectFoodsUseCase _foods;

    public ProductsModel(ILogger<ProductsModel> logger, SelectFoodsUseCase foods)
    {
        _logger = logger;
        _foods = foods;
    }

    public List<FoodType> Foods = new();

    public InputModel Input { get; set; } = default!;

    public class InputModel
    {

        [Display(Name = "Search")]
        public string Search { get; set; } = default!;
    }
    public async Task OnGetAsync()
    {
        Foods = await _foods.AllFoodsAvaible();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("", new { search = Input.Search });
    }
}
