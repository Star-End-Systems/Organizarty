using Organizarty.Application.App.DecorationInfos.Entities;

namespace Organizarty.Application.App.Party.Entities;

public class DecorationGroup
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }
    public string? Note { get; set; }

    public Guid DecorationInfoId { get; set; } = default!;
    public DecorationInfo DecorationInfo { get; set; } = default!;

    public Guid PartyTemplateId { get; set; } = default!;
    public PartyTemplate PartyTemplate { get; set; } = default!;
}
