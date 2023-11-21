namespace Organizarty.Application.App.DecorationTypes.UseCases;

public record EditDecorationDto(Guid id, string name, string description, string size, string model, string objectURL)
{
}
