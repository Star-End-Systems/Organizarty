using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages.ThirdParty.Products;

public class EditProductsModel : PageModel
{
    private readonly ILogger<EditProductsModel> _logger;

    public EditProductsModel(ILogger<EditProductsModel> logger)
    {
        _logger = logger;
    }

    public InputModel Input{get; set;} = default!;

    public class InputModel{
        [Display(Name = "Description")]
        public string Description {get; set;} = default!;

        [Display(Name = "Price")]
        public string Price {get; set;} = default!;

        [Display(Name = "Status")]
        public string Status {get; set;} = default!;

        [Display(Name = "Status")]
        public string Search {get; set;} = default!;
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

        return RedirectToPage("", new { description = Input.Description, price = Input.Price, status = Input.Status});
    }        
}
