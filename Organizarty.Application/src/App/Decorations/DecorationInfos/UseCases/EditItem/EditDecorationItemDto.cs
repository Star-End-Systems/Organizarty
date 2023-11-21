namespace Organizarty.Application.App.DecorationInfos.UseCases;

public record EditDecorationItemDto(Guid id, string color, string material, bool isAvailable, decimal price, string textureURL) { }
