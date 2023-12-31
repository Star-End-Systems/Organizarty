using Organizarty.Application.App.Decorations.Entities;

namespace Organizarty.Application.App.DecorationTypes.UseCases;

public record EditDecorationDto(string id, string name, string description, DecorationCategory category, string size, string model, string objectURL, List<string> Tags)
{
}
