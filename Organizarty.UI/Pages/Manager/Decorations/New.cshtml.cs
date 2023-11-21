using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.DecorationTypes.UseCases;
using Organizarty.Application.Exceptions;
using System.ComponentModel.DataAnnotations;
namespace Organizarty.UI.Pages.Manager;

public class NewDecorationModel : PageModel
{
    private readonly ILogger<NewDecorationModel> _logger;

    private readonly CreateDecorationTypeUseCase _createDecoration;

    public NewDecorationModel(ILogger<NewDecorationModel> logger, CreateDecorationTypeUseCase createDecoration)
    {
        _logger = logger;
        _createDecoration = createDecoration;
    }

    public InputModel Input { get; set; } = default!;


    public class InputModel
    {
        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public string Description { get; set; } = default!;

        [Required]
        public string Size { get; set; } = default!;

        [Required]
        public string Model { get; set; } = default!;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var data = new CreateDecorationTypeDto(Input.Name, Input.Description, Input.Size, Input.Model, "https://www.google.com");

        try
        {
            await _createDecoration.Execute(data);
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
