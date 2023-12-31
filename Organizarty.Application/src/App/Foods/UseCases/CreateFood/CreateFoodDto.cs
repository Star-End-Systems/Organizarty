using Organizarty.Application.App.Foods.Entities;

namespace Organizarty.Application.App.Foods.UseCases;

public record CreateFoodDto(string name, string description, string category, List<string> tags, string thirdPartyId)
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
