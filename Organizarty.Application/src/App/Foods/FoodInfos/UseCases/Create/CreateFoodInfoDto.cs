using Organizarty.Application.App.FoodInfos.Entities;

namespace Organizarty.Application.App.FoodInfos.UseCases;

public record CreateFoodInfoDto(Guid foodTypeId, bool avaible, string flavour, decimal price, List<string> images)
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
