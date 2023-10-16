using Organizarty.Application.App.DecorationTypes.Entities;

namespace Organizarty.Application.App.DecorationTypes.UseCases;

public record CreateDecorationTypeDto(string name, string description, string size, string model, string objectURL)
{
    public DecorationType ToModel
      => new DecorationType
      {
          Name = name,
          Description = description,
          Size = size,
          Model = model,
          ObjectURL = objectURL
      };
}
