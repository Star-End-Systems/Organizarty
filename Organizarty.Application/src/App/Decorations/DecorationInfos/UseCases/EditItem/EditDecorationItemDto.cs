namespace Organizarty.Application.App.DecorationInfos.UseCases;

public record EditDecorationItemDto(string id, string color, string material, bool isAvailable, decimal price, string textureURL) { }
