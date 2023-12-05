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
public class EditDashboardModel : PageModel
{
    [FromRoute]
    public DecorationCategory DecorationCategory { get; set; }

    public SelectDecorationTypeUseCase _selectDecoration {get; set;}
    public SelectDecorationInfoUseCase _selectInfoDecoration {get; set;}

    public DecorationType Decoration {get; set;} = new();
    public List<DecorationInfo> Decorations {get; set;} = new();

    public EditDashboardModel(SelectDecorationTypeUseCase selectDecoration){
        _selectDecoration = selectDecoration;
    }

    public async Task OnGetAsync(Guid decorationId)
    {
        Decoration = await _selectDecoration.FindByIdWithItems(decorationId);
        Decorations = await _selectInfoDecoration.ListFromType(decorationId);
        Console.WriteLine(Decoration.Decorations.Count);
        foreach (var item in Decoration.Decorations)
        {
            Console.WriteLine(item);
        }
    }
}