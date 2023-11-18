using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages;

public class ProductsListModel : PageModel
{
    private readonly ILogger<ProductsListModel> _logger;

    public ProductsListModel(ILogger<ProductsListModel> logger)
    {
        _logger = logger;
    }

    [BindProperty]
    public InputModel Input{get; set;} = default!;
    
    public class InputModel{
        [Display(Name = "ProductName")]
        public string ProductName {get; set;} = default!;

        [Display(Name="Price")]
        public string Price {get; set;} = default!;

        [Display(Name="ImageURL")]
        public string ImageURL {get; set;} = default!;
    }
    public void OnGet()
    {

    }
        public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("", new { productName = Input.ProductName, price = Input.Price, imageURL = Input.ImageURL});
    }        
}