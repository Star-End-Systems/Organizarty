using Organizarty.Application.App.DecorationInfos.Entities;

namespace Organizarty.Application.App.Party.Entities;

public class DecorationGroup
{
    public string Id { get; set; } = default!;

    public int Quantity { get; set; }
    public string Note { get; set; } = "";

    public string DecorationInfoId { get; set; } = default!;
    public DecorationInfo DecorationInfo { get; set; } = default!;

    public string PartyTemplateId { get; set; } = default!;
    public PartyTemplate PartyTemplate { get; set; } = default!;
}
