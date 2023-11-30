using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.UI.Attributes;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages;

[Authorized("/Manager/Accounts/Login", UserType.Mannager)]
public class NewPlaceModel : PageModel
{
    private readonly ILogger<NewPlaceModel> _logger;

    public NewPlaceModel(ILogger<NewPlaceModel> logger)
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

        [Display(Name = "Name")]
        public string Name {get; set;} = default!;

        [Display(Name = "Hire")]
        public string Hire {get; set;} = default!;

        [Display(Name = "Category")]
        public string Category {get; set;} = default!;

        [Display(Name = "Description")]
        public string Description {get; set;} = default!;
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

        return RedirectToPage("", new { CEP = Input.CEP, address = Input.Address, complement = Input.Complement, city = Input.City, number = Input.Number, neighbor = Input.Neighbor, name = Input.Name, hire = Input.Hire, category = Input.Category, description = Input.Description});
    }        
}
