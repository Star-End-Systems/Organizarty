using Organizarty.Application.App.DecorationTypes.Entities;

namespace Organizarty.Application.App.DecorationInfos.Entities;

public class DecorationInfo
{
    public Guid Id { get; set; }

    public string Color { get; set; } = default!;
    public string Material { get; set; } = default!;
    public bool IsAvaible { get; set; }
    public decimal Price { get; set; }
    public string TextureURL { get; set; } = default!;

    public Guid DecorationTypeId { get; set; } = default!;
    public DecorationType DecorationType { get; set; } = default!;
}
