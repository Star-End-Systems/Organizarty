using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Application.App.Decorations.Entities;
using Organizarty.Application.App.Decorations.Entities;

using Organizarty.Application.App.DecorationTypes.UseCases;

using Organizarty.UI.Attributes;
namespace Organizarty.UI.Pages.Clients.Decorations.Dashboard;

[Authorized("/Clients/Accounts/Login", UserType.Client)]
public class TypeModel : PageModel
{
    [FromRoute]
    public DecorationCategory DecorationCategory { get; set; }

    public SelectDecorationTypeUseCase _selectDecoration {get; set;}

    public List<DecorationType> Decorations {get; set;} = new();

    public TypeModel(SelectDecorationTypeUseCase selectDecoration){
        _selectDecoration = selectDecoration;
    }

    public async Task OnGetAsync()
    {
        Decorations = await _selectDecoration.FindByCategory(DecorationCategory);
    }
}