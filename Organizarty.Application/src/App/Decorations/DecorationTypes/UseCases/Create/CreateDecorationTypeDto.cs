using Organizarty.Application.App.Decorations.Entities;
using Organizarty.Application.App.DecorationTypes.Entities;

namespace Organizarty.Application.App.DecorationTypes.UseCases;

public record CreateDecorationTypeDto(string name, string description, DecorationCategory category, string size, string model, string objectURL, List<string> Tags)
{
    public DecorationType ToModel
      => new DecorationType
      {
          Name = name,
          Description = description,
          Category = category,
          Size = size,
          Model = model,
          ObjectURL = objectURL,
          Tags = Tags
      };
}
