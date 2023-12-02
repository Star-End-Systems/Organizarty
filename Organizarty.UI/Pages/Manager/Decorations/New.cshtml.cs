using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.DecorationTypes.UseCases;
using Organizarty.Application.App.Decorations.Entities;
using Organizarty.Application.Exceptions;
using System.ComponentModel.DataAnnotations;
using Organizarty.UI.Attributes;
using Organizarty.Adapters;

namespace Organizarty.UI.Pages.Manager;

[Authorized("/Manager/Accounts/Login", UserType.Mannager)]
public class NewDecorationModel : PageModel
{
    private readonly ILogger<NewDecorationModel> _logger;

    private readonly CreateDecorationTypeUseCase _createDecoration;

    public NewDecorationModel(ILogger<NewDecorationModel> logger, CreateDecorationTypeUseCase createDecoration)
    {
        _logger = logger;
        _createDecoration = createDecoration;
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
        public DecorationCategory Category { get; set; } = default!;

        [Required]
        public string Size { get; set; } = default!;

        [Required]
        public string Model { get; set; } = default!;

        public string TagsStr { get; set; } = "";
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var tags = Input.TagsStr.Split(",").ToList();
        var data = new CreateDecorationTypeDto(Input.Name, Input.Description, Input.Category, Input.Size, Input.Model, "https://www.google.com", tags);

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
