using Organizarty.Application.App.FoodTypes.Entities;

namespace Organizarty.Application.App.FoodTypes.UseCases;

public record CreateFoodTypeDto(string name, string description, string category, List<string> tags, Guid thirdPartyId)
{
    public FoodType ToModel
      => new FoodType
      {
          Name = name,
          Description = description,
          Category = category,
          Tags = tags,
          ThirdPartyId = thirdPartyId
      };
}
