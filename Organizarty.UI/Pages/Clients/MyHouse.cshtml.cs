using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages;

public class MyHouseModel : PageModel
{
    private readonly ILogger<MyHouseModel> _logger;

    public MyHouseModel(ILogger<MyHouseModel> logger)
    {
        _logger = logger;
    }
    
    public InputModel Input{get; set;} = default!;

    public class InputModel{
        [Display(Name = "CEP")]
        public string CEP {get; set;} = default!;

        [Display(Name = "Address")]
        public string Address {get; set;} = default!;

        [Display(Name = "Complement")]
        public string Complement {get; set;} = default!;

        [Display(Name = "City")]
        public string City {get; set;} = default!;

        [Display(Name = "Number")]
        public string Number {get; set;} = default!;

        [Display(Name = "Neighbor")]
        public string Neighbor {get; set;} = default!;

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

        return RedirectToPage("", new { CEP = Input.CEP, address = Input.Address, complement = Input.Complement, city = Input.City, number = Input.Number, neighbor = Input.Neighbor});
    }        
}
