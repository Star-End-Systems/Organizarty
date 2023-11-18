using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.Locations.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Attributes;

namespace Organizarty.UI.Pages.Manager.Locations;

// [Authorized("/", UserType.Mannager)]
public class NewLocationModel : PageModel
{
    private readonly CreateLocationUseCase _createLocation;

    public NewLocationModel(CreateLocationUseCase createLocation)
    {
        _createLocation = createLocation;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public string Description { get; set; } = default!;

        [Required]
        public double AreaSize { get; set; } = default!;

        [Required]
        public decimal RentPerDay { get; set; } = default!;

        [Required]
        public string CEP { get; set; } = default!;

        [Required]
        public string Category { get; set; } = default!;

        [Required]
        public string Address { get; set; } = default!;

        public string Cords { get; set; } = "";

        public string ImgUrl { get; set; } = "http://localhost:8000/Manager/Locations/new";
    }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        Console.WriteLine("aqui foi");
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var data = new CreateLocationDto(Input.Name, Input.Description, Input.AreaSize, Input.RentPerDay, Input.CEP, Input.Category, Input.Address, Input.Cords, new() { Input.ImgUrl });

        try
        {
            var user = await _createLocation.Execute(data);
            return Redirect("/Manager/Locations");
        }
        catch (ValidationFailException e)
        {
            Console.WriteLine(e);
            foreach (var err in e.Errors)
            {
                ModelState.AddModelError(string.Empty, err.message);
            }

            return Page();
        }
    }
}
