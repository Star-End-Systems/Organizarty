using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.DecorationTypes.UseCases;
using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Attributes;
using Organizarty.Adapters;

namespace Organizarty.UI.Pages.Manager;

[Authorized("/Manager/Accounts/Login", UserType.Mannager)]
public class EditDecorationModel : PageModel
{
    private readonly ILogger<EditDecorationModel> _logger;

    private readonly EditDecorationUseCase _editDecoration;
    private readonly SelectDecorationTypeUseCase _selectDecoration;

    public EditDecorationModel(ILogger<EditDecorationModel> logger, EditDecorationUseCase editDecoration, SelectDecorationTypeUseCase selectDecoration)
    {
        _logger = logger;
        _editDecoration = editDecoration;
        _selectDecoration = selectDecoration;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public class InputModel : DecorationType
    {
        public InputModel() { }

        public InputModel(DecorationType _)
        {
            Id = _.Id;
            Name = _.Name;
            Description = _.Description;
            Category = _.Category;
            Size = _.Size;
            Model = _.Model;
            Tags = _.Tags;
            TagsStr = String.Join(", ", _.Tags);
        }

        public string TagsStr { get; set; } = "";
    }

    public async Task OnGetAsync(Guid decorationId)
    {
        try
        {
            Input = new(await _selectDecoration.FindById(decorationId));
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
        }
    }

    public async Task<IActionResult> OnPostAsync(Guid decorationId)
    {
        var tags = Input.TagsStr.Split(",").ToList();
        var data = new EditDecorationDto(decorationId, Input.Name, Input.Description, Input.Category, Input.Size, Input.Model, "https://www.google.com", tags);

        try
        {
            await _editDecoration.Execute(data);
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
