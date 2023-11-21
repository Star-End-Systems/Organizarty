using Organizarty.Application.App.Foods.Entities;

namespace Organizarty.Application.App.Foods.UseCases;

public record CreateFoodItemDto(Guid foodTypeId, bool avaible, string flavour, decimal price, List<string> images)
{
    public FoodInfo ToModel
      => new FoodInfo
      {
          FoodTypeId = foodTypeId,
          Available = avaible,
          Flavour = flavour,
          Price = price,
          Images = images
      };
}
