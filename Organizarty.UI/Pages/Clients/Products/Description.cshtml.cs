using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages.Clients.Products;

public class DescriptionModel : PageModel
{
    private readonly ILogger<DescriptionModel> _logger;

    public DescriptionModel(ILogger<DescriptionModel> logger)
    {
        _logger = logger;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Display(Name = "ClientNotes")]
        public string Note { get; set; } = default!;

        [Display(Name = "ClientNotes")]
        public int Quantity { get; set; } = default!;
    }

    public async Task OnGetAsync(Guid productId)
    {

    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return Redirect("/");
    }
}
