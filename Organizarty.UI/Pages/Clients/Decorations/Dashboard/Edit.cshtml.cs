using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Adapters;
using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Application.App.Decorations.Entities;

using Organizarty.Application.App.DecorationTypes.UseCases;

using Organizarty.UI.Attributes;
using Organizarty.Application.App.DecorationInfos.UseCases;
using Organizarty.Application.App.DecorationInfos.Entities;

namespace Organizarty.UI.Pages.Clients.Decorations.Dashboard;

[Authorized("/Clients/Accounts/Login", UserType.Client)]
public class EditDashboardModel : PageModel
{
    [FromRoute]
    public DecorationCategory DecorationCategory { get; set; }

    public SelectDecorationTypeUseCase _selectDecoration {get; set;}
    public SelectDecorationItemUseCase _selectInfoDecoration {get; set;}

    public DecorationType Decoration {get; set;} = new();
    public List<DecorationInfo> Decorations {get; set;} = new();

    public EditDashboardModel(SelectDecorationTypeUseCase selectDecoration, SelectDecorationItemUseCase selectInfoDecoration)
    {
        _selectDecoration = selectDecoration;
        _selectInfoDecoration = selectInfoDecoration;
    }

    public async Task OnGetAsync(Guid decorationId)
    {
        Decoration = await _selectDecoration.FindByIdWithItems(decorationId);
        Decorations = await _selectInfoDecoration.ListFromType(decorationId);
    }
}
