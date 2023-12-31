using Organizarty.Application.App.DecorationTypes.Entities;

namespace Organizarty.Application.App.DecorationInfos.Entities;

public class DecorationInfo
{
    public string Id { get; set; } = default!;

    public string Color { get; set; } = default!;
    public string Material { get; set; } = default!;
    public bool IsAvaible { get; set; }
    public decimal Price { get; set; }
    public string TextureURL { get; set; } = default!;
    public string DecorationTypeId { get; set; } = default!;
    public DecorationType DecorationType { get; set; } = default!;
}
