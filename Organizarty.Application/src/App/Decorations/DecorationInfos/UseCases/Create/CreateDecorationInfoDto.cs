using Organizarty.Application.App.DecorationInfos.Entities;

namespace Organizarty.Application.App.DecorationInfos.UseCases;

public record CreateDecorationInfoDto(string color, string material, bool isAvailable, decimal price, string textureURL, string decorationTypeId)
{
    public DecorationInfo ToModel
      => new DecorationInfo
      {
          Color = color,
          Material = material,
          IsAvaible = isAvailable,
          Price = price,
          TextureURL = textureURL,
          DecorationTypeId = decorationTypeId
      };
}
